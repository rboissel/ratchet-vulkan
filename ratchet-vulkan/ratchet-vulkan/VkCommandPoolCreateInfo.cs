using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkCommandPoolCreateFlag : UInt32
    {
        NONE = 0,
        VK_COMMAND_POOL_CREATE_TRANSIENT = 0x00000001,
        VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER = 0x00000002,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkCommandPoolCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCommandPoolCreateFlag flags;
        public UInt32 queueFamilyIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkCommandPoolCreateInfo
    {
        public VkCommandPoolCreateFlag flags;
        public UInt32 queueFamilyIndex;
    }
}
