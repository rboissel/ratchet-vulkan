using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public struct VkCommandBufferInheritanceInfo_Native
    {
        VkStructureType sType;
        IntPtr pNext;
        IntPtr renderPass;
        Int32 subpass;
        IntPtr framebuffer;
        Int32 occlusionQueryEnable;
        VkQueryControlFlag queryFlags;
        VkQueryPipelineStatisticFlag pipelineStatistics;
    }

    public struct VkCommandBufferInheritanceInfo
    {
        VkRenderPass renderPass;
        Int32 subpass;
        VkFramebuffer framebuffer;
        Int32 occlusionQueryEnable;
        VkQueryControlFlag queryFlags;
        VkQueryPipelineStatisticFlag pipelineStatistics;
    }
}
