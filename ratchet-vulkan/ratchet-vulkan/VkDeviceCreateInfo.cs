using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    struct VkDeviceCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt32 flags;
        public UInt32 queueCreateInfoCount;
        public IntPtr pQueueCreateInfos;
        public UInt32 enabledLayerCount;
        public IntPtr ppEnabledLayerNames;
        public UInt32 enabledExtensionCount;
        public IntPtr ppEnabledExtensionNames;
        public IntPtr pEnabledFeatures;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkDeviceCreateInfo
    {
        public List<VkDeviceQueueCreateInfo> queueCreateInfos;
        public List<string> enabledLayerNames;
        public List<string> enabledExtensionNames;
        // public IntPtr pEnabledFeatures;
    }
}
