using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkSemaphoreCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkSemaphoreCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphoreCreateFlag flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkSemaphoreCreateInfo
    {
        public VkSemaphoreCreateFlag flags;
    }
}
