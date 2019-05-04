using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkInstance
    {
        delegate VkResult vkCreateInstance_func(ref VkInstanceCreateInfo_Native createInfo, ref VkAllocationCallbacks allocationCallbacks, IntPtr pInstance);
        List<VkSubInstance> VkSubInstances = new List<VkSubInstance>();

        abstract internal unsafe class VkSubInstance
        {
            public abstract IntPtr vkInstanceHandle { get; }
            public abstract T vkGetInstanceProcAddr<T>(string Name);

            public delegate VkResult vkEnumeratePhysicalDevices_func(IntPtr instance, UInt32* pPhysicalDeviceCount, IntPtr pPhysicalDevices);
            vkEnumeratePhysicalDevices_func _vkEnumeratePhysicalDevices = null;

            public VkPhysicalDevice[] vkEnumeratePhysicalDevices()
            {
                lock (this)
                {
                    if (_vkEnumeratePhysicalDevices == null)
                    {
                        _vkEnumeratePhysicalDevices = vkGetInstanceProcAddr<vkEnumeratePhysicalDevices_func>("vkEnumeratePhysicalDevices");
                    }
                    List<VkPhysicalDevice> list = new List<VkPhysicalDevice>();
                    if (_vkEnumeratePhysicalDevices != null)
                    {
                        uint deviceCount = 1;
                        IntPtr pPhysicalDevices = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(IntPtr) * deviceCount));
                        if (pPhysicalDevices.ToInt64() == 0) { throw new OutOfMemoryException(); }
                        VkResult result = _vkEnumeratePhysicalDevices(vkInstanceHandle, &deviceCount, pPhysicalDevices);


                        while (result == VkResult.VK_INCOMPLETE)
                        {
                            deviceCount *= 2;
                            pPhysicalDevices = System.Runtime.InteropServices.Marshal.ReAllocHGlobal(pPhysicalDevices, new IntPtr(sizeof(IntPtr) * deviceCount));
                            if (pPhysicalDevices.ToInt64() == 0)
                            {
                                System.Runtime.InteropServices.Marshal.FreeHGlobal(pPhysicalDevices);
                                throw new OutOfMemoryException();
                            }
                            result = _vkEnumeratePhysicalDevices(vkInstanceHandle, &deviceCount, pPhysicalDevices);
                        }

                        IntPtr* pHandle = (IntPtr*)pPhysicalDevices.ToPointer();

                        for (int n = 0; n < deviceCount; n++)
                        {
                            list.Add(new VkPhysicalDevice(pHandle[n], this));
                        }

                        System.Runtime.InteropServices.Marshal.FreeHGlobal(pPhysicalDevices);
                    }
                    return list.ToArray();
                }
            }
        }

        unsafe class VkWin32SubInstance : VkSubInstance
        {
            internal win32Loader _Win32Loader;
            internal IntPtr _VkInstanceHandle;

            public override IntPtr vkInstanceHandle { get { return _VkInstanceHandle; } }

            public VkWin32SubInstance(IntPtr VkInstanceHandle, win32Loader win32Loader)
            {
                _VkInstanceHandle = VkInstanceHandle;
                _Win32Loader = win32Loader;
            }

            public override T vkGetInstanceProcAddr<T>(string Name)
            {
                return _win32Loader.vkGetInstanceProcAddr<T>(_VkInstanceHandle, Name);
            }
        }

        static win32Loader _win32Loader = null;

        static VkInstance()
        {
            if (System.Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                _win32Loader = new win32Loader();
            }
        }

        unsafe void InitVkInstance(ref VkInstanceCreateInfo createInfo)
        {
            VkAllocationCallbacks allocationCallbacks = Allocator.getAllocatorCallbacks();
            VkInstanceCreateInfo_Native createInfo_native = new VkInstanceCreateInfo_Native();
            VkApplicationInfo_Native applicationInfo_native = new VkApplicationInfo_Native();

            applicationInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO;
            applicationInfo_native.pNext = new IntPtr(0);
            applicationInfo_native.engineVersion = createInfo.applicationInfo.engineVersion;
            applicationInfo_native.apiVersion = createInfo.applicationInfo.apiVersion;
            applicationInfo_native.applicationName = Tools.toUTF8ZeroTerminated(createInfo.applicationInfo.applicationName);
            applicationInfo_native.engineName = Tools.toUTF8ZeroTerminated(createInfo.applicationInfo.engineName);

            createInfo_native.flags = 0;
            createInfo_native.pNext = new IntPtr(0);
            createInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
            createInfo_native.enabledExtensionCount = (UInt32)(createInfo.enabledExtensionNames != null ? createInfo.enabledExtensionNames.Length : 0);
            createInfo_native.enabledLayerCount = (UInt32)(createInfo.enabledLayerNames != null ? createInfo.enabledLayerNames.Length : 0);
            createInfo_native.applicationInfo = new IntPtr(&applicationInfo_native);

            if (_win32Loader != null)
            {
                IntPtr VkInstanceHandle;

                vkCreateInstance_func vkCreateInstance = _win32Loader.vkGetInstanceProcAddr<vkCreateInstance_func>(new IntPtr(0), "vkCreateInstance");
                VkResult result = vkCreateInstance(ref createInfo_native, ref allocationCallbacks, new IntPtr(&VkInstanceHandle));
                if (result == VkResult.VK_SUCCESS)
                {
                    VkSubInstance VkSubInstance = new VkWin32SubInstance(VkInstanceHandle, _win32Loader);
                    VkSubInstances.Add(VkSubInstance);
                }
            }

            System.Runtime.InteropServices.Marshal.FreeHGlobal(applicationInfo_native.applicationName);
            System.Runtime.InteropServices.Marshal.FreeHGlobal(applicationInfo_native.engineName);
        }

        public unsafe VkInstance(ref VkInstanceCreateInfo createInfo)
        {
            InitVkInstance(ref createInfo);
        }

        public unsafe VkInstance(string ApplicationName, int ApplicationVersion, string EngineName, int EngineVersion)
        {
            VkInstanceCreateInfo createInfo;
            createInfo.applicationInfo.apiVersion = 0;
            createInfo.applicationInfo.applicationName = ApplicationName;
            createInfo.applicationInfo.applicationVersion = ApplicationVersion;
            createInfo.applicationInfo.engineName = EngineName;
            createInfo.applicationInfo.engineVersion = EngineVersion;
            createInfo.enabledExtensionNames = new string[0];
            createInfo.enabledLayerNames = new string[0];
            InitVkInstance(ref createInfo);
        }

        public VkPhysicalDevice[] vkEnumeratePhysicalDevices()
        {
            List<VkPhysicalDevice> list = new List<VkPhysicalDevice>();
            foreach (VkSubInstance subInstance in VkSubInstances)
            {
                list.AddRange(subInstance.vkEnumeratePhysicalDevices());
            }
            return list.ToArray();
        }
    }
}
