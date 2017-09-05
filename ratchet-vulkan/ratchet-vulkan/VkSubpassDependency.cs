using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public struct VkSubpassDependency
    {
        UInt32 srcSubpass;
        UInt32 dstSubpass;
        VkPipelineStageFlag srcStageMask;
        VkPipelineStageFlag dstStageMask;
        VkAccessFlag srcAccessMask;
        VkAccessFlag dstAccessMask;
        VkDependencyFlag dependencyFlags;
    }
}
