using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkImageUsageFlag : UInt32
    {
        VK_IMAGE_USAGE_TRANSFER_SRC = 0x00000001,
        VK_IMAGE_USAGE_TRANSFER_DST = 0x00000002,
        VK_IMAGE_USAGE_SAMPLED = 0x00000004,
        VK_IMAGE_USAGE_STORAGE = 0x00000008,
        VK_IMAGE_USAGE_COLOR_ATTACHMENT = 0x00000010,
        VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT = 0x00000020,
        VK_IMAGE_USAGE_TRANSIENT_ATTACHMENT = 0x00000040,
        VK_IMAGE_USAGE_INPUT_ATTACHMENT = 0x00000080,
    }
}
