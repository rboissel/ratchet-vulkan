using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineDynamicStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    public enum VkDynamicState : UInt32
    {
        VK_DYNAMIC_STATE_VIEWPORT = 0,
        VK_DYNAMIC_STATE_SCISSOR = 1,
        VK_DYNAMIC_STATE_LINE_WIDTH = 2,
        VK_DYNAMIC_STATE_DEPTH_BIAS = 3,
        VK_DYNAMIC_STATE_BLEND_CONSTANTS = 4,
        VK_DYNAMIC_STATE_DEPTH_BOUNDS = 5,
        VK_DYNAMIC_STATE_STENCIL_COMPARE_MASK = 6,
        VK_DYNAMIC_STATE_STENCIL_WRITE_MASK = 7,
        VK_DYNAMIC_STATE_STENCIL_REFERENCE = 8,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineDynamicStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineDynamicStateCreateFlag flags;
        public UInt32 dynamicStateCount;
        public IntPtr pDynamicStates;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineDynamicStateCreateInfo
    {
        public VkPipelineDynamicStateCreateFlag flags;
        public VkDynamicState[] dynamicStates;
    }
}
