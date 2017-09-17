using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VkImageSubresourceRange
    {
        VkImageAspectFlag aspectMask;
        UInt32 baseMipLevel;
        UInt32 levelCount;
        UInt32 baseArrayLayer;
        UInt32 layerCount;
    }
}
