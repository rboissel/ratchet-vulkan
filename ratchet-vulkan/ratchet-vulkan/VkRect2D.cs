using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VkRect2D
    {
        public VkRect2D(int x, int y, uint width, uint height)
        {
            offset = new VkOffset2D();
            offset.x = x;
            offset.y = y;
            extent = new VkExtent2D();
            extent.width = width;
            extent.height = height;
        }
        public VkOffset2D offset;
        public VkExtent2D extent;
    }
}
