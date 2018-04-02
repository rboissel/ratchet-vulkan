using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VkImageSubresourceLayers
    {
        public VkImageAspectFlag aspectMask;
        public UInt32 mipLevel;
        public UInt32 baseArrayLayer;
        public UInt32 layerCount;
    }
}
