using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public struct VkSubpassDependency
    {
        public const UInt32 VK_SUBPASS_EXTERNAL = 0xFFFFFFFF;
        public UInt32 srcSubpass;
        public UInt32 dstSubpass;
        public VkPipelineStageFlag srcStageMask;
        public VkPipelineStageFlag dstStageMask;
        public VkAccessFlag srcAccessMask;
        public VkAccessFlag dstAccessMask;
        public VkDependencyFlag dependencyFlags;
    }
}
