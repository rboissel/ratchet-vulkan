using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkImageAspectFlag
    {
        NONE = 0x00000000,
        VK_IMAGE_ASPECT_COLOR_BIT = 0x00000001,
        VK_IMAGE_ASPECT_DEPTH_BIT = 0x00000002,
        VK_IMAGE_ASPECT_STENCIL_BIT = 0x00000004,
        VK_IMAGE_ASPECT_METADATA_BIT = 0x00000008,
    }
}
