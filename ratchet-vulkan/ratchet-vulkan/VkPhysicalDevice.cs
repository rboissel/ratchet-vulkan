using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkPhysicalDevice
    {
        IntPtr _Handle;
        internal VkInstance.VkSubInstance _ParentInstance;
        delegate VkResult vkCreateDevice_func(IntPtr physicalDeviceHandle, ref VkDeviceCreateInfo_Native createInfo, ref VkAllocationCallbacks allocator, ref IntPtr deviceHandle);
        vkCreateDevice_func vkCreateDevice;
        delegate void vkGetPhysicalDeviceQueueFamilyProperties_func(IntPtr physicalDeviceHandle, IntPtr pQueueFamilyPropertyCount, IntPtr pQueueFamilyProperties);
        vkGetPhysicalDeviceQueueFamilyProperties_func vkGetPhysicalDeviceQueueFamilyProperties;
        delegate void vkGetPhysicalDeviceMemoryProperties_func(IntPtr physicalDeviceHandle, ref VkPhysicalDeviceMemoryProperties pMemoryProperties);
        vkGetPhysicalDeviceMemoryProperties_func vkGetPhysicalDeviceMemoryProperties;

        internal VkPhysicalDevice(IntPtr Handle, VkInstance.VkSubInstance ParentInstance)
        {
            _Handle = Handle;
            _ParentInstance = ParentInstance;
            vkCreateDevice = _ParentInstance.vkGetInstanceProcAddr<vkCreateDevice_func>("vkCreateDevice");
            vkGetPhysicalDeviceQueueFamilyProperties = _ParentInstance.vkGetInstanceProcAddr<vkGetPhysicalDeviceQueueFamilyProperties_func>("vkGetPhysicalDeviceQueueFamilyProperties");
            vkGetPhysicalDeviceMemoryProperties = _ParentInstance.vkGetInstanceProcAddr<vkGetPhysicalDeviceMemoryProperties_func>("vkGetPhysicalDeviceMemoryProperties");
            _PhysicalDeviceMemoryProperty = GetPhysicalDeviceMemoryProperties();
            _PhysicalDeviceQueueFamilyProperties = GetPhysicalDeviceQueueFamilyProperties();
        }

        VkPhysicalDeviceMemoryProperties _PhysicalDeviceMemoryProperty;
        public VkPhysicalDeviceMemoryProperties MemoryProperty { get { return _PhysicalDeviceMemoryProperty; } }

        unsafe VkPhysicalDeviceMemoryProperties GetPhysicalDeviceMemoryProperties()
        {
            VkPhysicalDeviceMemoryProperties properties = new VkPhysicalDeviceMemoryProperties();
            vkGetPhysicalDeviceMemoryProperties(_Handle, ref properties);
            return properties;
        }

        VkQueueFamilyProperties[] _PhysicalDeviceQueueFamilyProperties;
        public VkQueueFamilyProperties[] QueueFamilyProperties { get { return _PhysicalDeviceQueueFamilyProperties; } }
        unsafe VkQueueFamilyProperties[] GetPhysicalDeviceQueueFamilyProperties()
        {
            List<VkQueueFamilyProperties> result = new List<VkQueueFamilyProperties>();
            if (vkGetPhysicalDeviceQueueFamilyProperties != null)
            {
                UInt32 count = 0;
                vkGetPhysicalDeviceQueueFamilyProperties(_Handle, new IntPtr(&count), new IntPtr(0));
                if (count > 0)
                {
                    VkQueueFamilyProperties* pVkQueueFamilyProperties = (VkQueueFamilyProperties*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(count * sizeof(VkQueueFamilyProperties))).ToPointer();
                    vkGetPhysicalDeviceQueueFamilyProperties(_Handle, new IntPtr(&count), new IntPtr(pVkQueueFamilyProperties));
                    for (int n = 0; n < count; n++)
                    {
                        result.Add(pVkQueueFamilyProperties[n]);
                    }
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(new IntPtr(pVkQueueFamilyProperties));
                }
            }
            return result.ToArray();
        }

        public unsafe VkDevice CreateDevice(ref VkDeviceCreateInfo deviceQueueCreateInfo)
        {
            if (vkCreateDevice != null)
            {
                VkDeviceCreateInfo_Native deviceQueueCreateInfo_native = new VkDeviceCreateInfo_Native();
                deviceQueueCreateInfo_native.pNext = new IntPtr(0);
                deviceQueueCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO;
                deviceQueueCreateInfo_native.flags = 0;
                deviceQueueCreateInfo_native.pEnabledFeatures = new IntPtr(0); // For now it will stay unset
                deviceQueueCreateInfo_native.queueCreateInfoCount = deviceQueueCreateInfo.queueCreateInfos == null ? 0 : (uint)deviceQueueCreateInfo.queueCreateInfos.Length;
                deviceQueueCreateInfo_native.pQueueCreateInfos = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkDeviceQueueCreateInfo_Native) * deviceQueueCreateInfo_native.queueCreateInfoCount));
                if (deviceQueueCreateInfo_native.pQueueCreateInfos == null) { throw new OutOfMemoryException(); }
                VkDeviceQueueCreateInfo_Native* pQueueCreateInfos = (VkDeviceQueueCreateInfo_Native*)deviceQueueCreateInfo_native.pQueueCreateInfos.ToPointer();
                for (int n = 0; n < deviceQueueCreateInfo_native.queueCreateInfoCount; n++)
                {
                    pQueueCreateInfos[n].flags = 0;
                    pQueueCreateInfos[n].pNext = new IntPtr(0);
                    pQueueCreateInfos[n].sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO;
                    pQueueCreateInfos[n].queueCount = deviceQueueCreateInfo.queueCreateInfos[n].queueCount;
                    pQueueCreateInfos[n].queueFamilyIndex = deviceQueueCreateInfo.queueCreateInfos[n].queueFamilyIndex;
                    pQueueCreateInfos[n].pQueuePriorities = (float*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(float) * deviceQueueCreateInfo.queueCreateInfos[n].queuePriorities.Length)).ToPointer();
                    for (int  x = 0; x < deviceQueueCreateInfo.queueCreateInfos[n].queuePriorities.Length; x++)
                    {
                        pQueueCreateInfos[n].pQueuePriorities[x] = deviceQueueCreateInfo.queueCreateInfos[n].queuePriorities[x];
                    }
                }

                VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                IntPtr deviceHandle = new IntPtr();

                VkResult result = vkCreateDevice(_Handle, ref deviceQueueCreateInfo_native, ref allocator, ref deviceHandle);

                for (int n = 0; n < deviceQueueCreateInfo_native.queueCreateInfoCount; n++)
                {
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(new IntPtr(pQueueCreateInfos[n].pQueuePriorities));
                }

                System.Runtime.InteropServices.Marshal.FreeHGlobal(deviceQueueCreateInfo_native.pQueueCreateInfos);
                if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
                return new VkDevice(this, deviceHandle);
            }
            else { throw new Exception("The method vkCreateDevice can't be accessed"); }
        }
    }
}
