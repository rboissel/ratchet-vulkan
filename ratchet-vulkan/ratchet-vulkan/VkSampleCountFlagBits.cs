using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkSampleCountFlagBits : UInt32
    {
        VK_SAMPLE_COUNT_1 = 0x00000001,
        VK_SAMPLE_COUNT_2 = 0x00000002,
        VK_SAMPLE_COUNT_4 = 0x00000004,
        VK_SAMPLE_COUNT_8 = 0x00000008,
        VK_SAMPLE_COUNT_16 = 0x00000010,
        VK_SAMPLE_COUNT_32 = 0x00000020,
        VK_SAMPLE_COUNT_64 = 0x00000040,
    }
}
