using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineViewportStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    struct VkPipelineViewportStateCreateInfo_Native
    {
        VkStructureType sType;
        IntPtr pNext;
        VkPipelineViewportStateCreateFlag flags;
        UInt32 viewportCount;
        IntPtr pViewports;
        UInt32 scissorCount;
        IntPtr pScissors;
    }

    struct VkPipelineViewportStateCreateInfo
    {
        VkPipelineViewportStateCreateFlag flags;
        VkViewport[] pViewports;
        VkRect2D[] pScissors;
    }
}
