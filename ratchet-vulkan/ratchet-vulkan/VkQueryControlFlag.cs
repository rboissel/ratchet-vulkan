using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkQueryControlFlag : UInt32
    {
        NONE = 0,
        VK_QUERY_CONTROL_PRECISE = 0x00000001,
    }
}
