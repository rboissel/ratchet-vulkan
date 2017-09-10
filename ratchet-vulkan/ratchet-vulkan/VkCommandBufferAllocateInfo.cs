using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkCommandBufferLevel : UInt32
    {
        VK_COMMAND_BUFFER_LEVEL_PRIMARY = 0,
        VK_COMMAND_BUFFER_LEVEL_SECONDARY = 1,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkCommandBufferAllocateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt64 commandPoolHandle;
        public VkCommandBufferLevel level;
        public UInt32 commandBufferCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkCommandBufferAllocateInfo
    {
        public VkCommandBufferLevel level;
        public UInt32 commandBufferCount;
    }
}
