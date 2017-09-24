using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkFenceCreateFlag : UInt32
    {
        NONE = 0,
        VK_FENCE_CREATE_SIGNALED = 0x00000001,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkFenceCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFenceCreateFlag flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkFenceCreateInfo
    {
        public VkFenceCreateFlag flags;
    }
}
