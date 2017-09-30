using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineViewportStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineViewportStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineViewportStateCreateFlag flags;
        public UInt32 viewportCount;
        public IntPtr pViewports;
        public UInt32 scissorCount;
        public IntPtr pScissors;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineViewportStateCreateInfo
    {
        public VkPipelineViewportStateCreateFlag flags;
        public VkViewport[] viewports;
        public VkRect2D[] scissors;
    }
}
