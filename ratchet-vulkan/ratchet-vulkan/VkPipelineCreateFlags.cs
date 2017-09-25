using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineCreateFlags : UInt32
    {
        NONE = 0x0,
        VK_PIPELINE_CREATE_DISABLE_OPTIMIZATION = 0x00000001,
        VK_PIPELINE_CREATE_ALLOW_DERIVATIVES = 0x00000002,
        VK_PIPELINE_CREATE_DERIVATIVE = 0x00000004,
    }
}
