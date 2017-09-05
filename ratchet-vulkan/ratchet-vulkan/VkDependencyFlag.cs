using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkDependencyFlag : UInt32
    {
        NONE = 0,
        VK_DEPENDENCY_BY_REGION = 0x00000001,
    }
}
