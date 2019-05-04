using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    class win32Loader
    {
        IntPtr _VkDriverLibrary = new IntPtr(0);
        IntPtr _VkGetInstanceProcAddr_ptr = new IntPtr(0);
        delegate IntPtr vkGetInstanceProcAddr_func(IntPtr vkInstance, string Name);
        vkGetInstanceProcAddr_func _vkGetInstanceProcAddr_del;

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string libraryName);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr library, string functionName);

        public DelegateType vkGetInstanceProcAddr<DelegateType>(IntPtr vkInstance, string functionName)
        {
            lock (this)
            {
                if (_VkDriverLibrary.ToInt64() == 0) { _VkDriverLibrary = LoadLibrary("vulkan-1.dll"); }
                if (_VkDriverLibrary.ToInt64() == 0) { _VkDriverLibrary = LoadLibrary("vulkan.dll"); }

                if (_VkDriverLibrary.ToInt64() == 0)
                {
                    return default(DelegateType);
                }

                if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0)
                {
                    _VkGetInstanceProcAddr_ptr = GetProcAddress(_VkDriverLibrary, "vkGetInstanceProcAddr");
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0) { _VkGetInstanceProcAddr_ptr = GetProcAddress(_VkDriverLibrary, "vk_GetInstanceProcAddr"); }
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0) { _VkGetInstanceProcAddr_ptr = GetProcAddress(_VkDriverLibrary, "vk_icdGetInstanceProcAddr"); }
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() != 0)
                    {
                        _vkGetInstanceProcAddr_del = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<vkGetInstanceProcAddr_func>(_VkGetInstanceProcAddr_ptr);
                    }
                }
                return System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<DelegateType>(_vkGetInstanceProcAddr_del(vkInstance, functionName));
            }
        }

    }
}
