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
        delegate void vkGetPhysicalDeviceMemoryProperties_func(IntPtr physicalDeviceHandle, ref VkPhysicalDeviceMemoryProperties_Native pMemoryProperties);
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
        public VkPhysicalDeviceMemoryProperties Memories { get { return _PhysicalDeviceMemoryProperty; } }

        unsafe VkPhysicalDeviceMemoryProperties GetPhysicalDeviceMemoryProperties()
        {
            VkPhysicalDeviceMemoryProperties_Native properties_native = new VkPhysicalDeviceMemoryProperties_Native();
            vkGetPhysicalDeviceMemoryProperties(_Handle, ref properties_native);
            VkPhysicalDeviceMemoryProperties properties = new VkPhysicalDeviceMemoryProperties();
            properties.memoryHeaps = new VkMemoryHeap[properties_native.memoryHeapCount];
            properties.memoryTypes = new VkMemoryType[properties_native.memoryTypeCount];
            for (int n = 0; n < properties.memoryHeaps.Length; n++) { properties.memoryHeaps[n] = properties_native.memoryHeaps[n]; }
            for (int n = 0; n < properties.memoryTypes.Length; n++) { properties.memoryTypes[n] = properties_native.memoryTypes[n]; }
            return properties;
        }

        VkQueueFamilyProperties[] _PhysicalDeviceQueueFamilyProperties;
        public VkQueueFamilyProperties[] QueueFamilies { get { return _PhysicalDeviceQueueFamilyProperties; } }
        unsafe VkQueueFamilyProperties[] GetPhysicalDeviceQueueFamilyProperties()
        {
            List<VkQueueFamilyProperties> result = new List<VkQueueFamilyProperties>();
            if (vkGetPhysicalDeviceQueueFamilyProperties != null)
            {
                UInt32 count = 0;
                vkGetPhysicalDeviceQueueFamilyProperties(_Handle, new IntPtr(&count), new IntPtr(0));
                if (count > 0)
                {
                    VkQueueFamilyProperties_Native* pVkQueueFamilyProperties = (VkQueueFamilyProperties_Native*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(count * sizeof(VkQueueFamilyProperties_Native))).ToPointer();
                    vkGetPhysicalDeviceQueueFamilyProperties(_Handle, new IntPtr(&count), new IntPtr(pVkQueueFamilyProperties));
                    for (int n = 0; n < count; n++)
                    {
                        VkQueueFamilyProperties vkQueueFamily = new VkQueueFamilyProperties();
                        vkQueueFamily.minImageTransferGranularity = pVkQueueFamilyProperties[n].minImageTransferGranularity;
                        vkQueueFamily.queueCount = pVkQueueFamilyProperties[n].queueCount;
                        vkQueueFamily.queueFlags = pVkQueueFamilyProperties[n].queueFlags;
                        vkQueueFamily.timestampValidBits = pVkQueueFamilyProperties[n].timestampValidBits;
                        vkQueueFamily.index = (UInt32)n;
                        vkQueueFamily.physicalDevice = this;
                        result.Add(vkQueueFamily);
                    }
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(new IntPtr(pVkQueueFamilyProperties));
                }
            }
            return result.ToArray();
        }

        public unsafe VkDevice CreateDevice(ref VkDeviceCreateInfo deviceCreateInfo)
        {
            if (vkCreateDevice != null)
            {
                VkDeviceCreateInfo_Native deviceQueueCreateInfo_native = new VkDeviceCreateInfo_Native();
                deviceQueueCreateInfo_native.pNext = new IntPtr(0);
                deviceQueueCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO;
                deviceQueueCreateInfo_native.flags = 0;
                deviceQueueCreateInfo_native.pEnabledFeatures = new IntPtr(0); // For now it will stay unset
                deviceQueueCreateInfo_native.queueCreateInfoCount = deviceCreateInfo.queueCreateInfos == null ? 0 : (uint)deviceCreateInfo.queueCreateInfos.Length;
                deviceQueueCreateInfo_native.pQueueCreateInfos = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkDeviceQueueCreateInfo_Native) * deviceQueueCreateInfo_native.queueCreateInfoCount));
                if (deviceQueueCreateInfo_native.pQueueCreateInfos == null) { throw new OutOfMemoryException(); }
                VkDeviceQueueCreateInfo_Native* pQueueCreateInfos = (VkDeviceQueueCreateInfo_Native*)deviceQueueCreateInfo_native.pQueueCreateInfos.ToPointer();
                for (int n = 0; n < deviceQueueCreateInfo_native.queueCreateInfoCount; n++)
                {
                    pQueueCreateInfos[n].flags = 0;
                    pQueueCreateInfos[n].pNext = new IntPtr(0);
                    pQueueCreateInfos[n].sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO;
                    pQueueCreateInfos[n].queueCount = deviceCreateInfo.queueCreateInfos[n].queueCount;
                    if (deviceCreateInfo.queueCreateInfos[n].queueFamily.physicalDevice != this) { throw new Exception("The queue family specified doesn't belong to this physical device"); }
                    pQueueCreateInfos[n].queueFamilyIndex = deviceCreateInfo.queueCreateInfos[n].queueFamily.index;
                    pQueueCreateInfos[n].pQueuePriorities = (float*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(float) * deviceCreateInfo.queueCreateInfos[n].queuePriorities.Length)).ToPointer();
                    for (int  x = 0; x < deviceCreateInfo.queueCreateInfos[n].queuePriorities.Length; x++)
                    {
                        pQueueCreateInfos[n].pQueuePriorities[x] = deviceCreateInfo.queueCreateInfos[n].queuePriorities[x];
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
                return new VkDevice(this, deviceHandle, deviceCreateInfo.queueCreateInfos);
            }
            else { throw new Exception("The method vkCreateDevice can't be accessed"); }
        }
    }
}
