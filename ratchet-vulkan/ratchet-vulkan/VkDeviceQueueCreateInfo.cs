using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct VkDeviceQueueCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt32 flags;
        public UInt32 queueFamilyIndex;
        public UInt32 queueCount;
        public float* pQueuePriorities;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkDeviceQueueCreateInfo
    {
        public UInt32 queueFamilyIndex;
        public UInt32 queueCount;
        public List<float> queuePriorities;
    }
}
