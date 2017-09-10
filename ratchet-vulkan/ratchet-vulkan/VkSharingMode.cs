using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkSharingMode : UInt32
    {
        VK_SHARING_MODE_EXCLUSIVE = 0,
        VK_SHARING_MODE_CONCURRENT = 1,
    }
}
