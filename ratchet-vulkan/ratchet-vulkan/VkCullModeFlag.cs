using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkCullModeFlag : UInt32
    {
        VK_CULL_MODE_NONE = 0,
        VK_CULL_MODE_FRONT = 0x00000001,
        VK_CULL_MODE_BACK = 0x00000002,
        VK_CULL_MODE_FRONT_AND_BACK = 0x00000003,
    }
}
