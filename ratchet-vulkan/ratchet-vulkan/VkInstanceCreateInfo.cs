using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct VkInstanceCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt32 flags;
        public IntPtr applicationInfo;
        public UInt32 enabledLayerCount;
        public IntPtr ppEnabledLayerNames;
        public UInt32 enabledExtensionCount;
        public IntPtr ppEnabledExtensionNames;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkInstanceCreateInfo
    {
        public VkApplicationInfo applicationInfo;
        public string[] enabledLayerNames;
        public string[] enabledExtensionNames;
    }
}
