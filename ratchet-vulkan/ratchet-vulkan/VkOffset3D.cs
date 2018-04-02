using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VkOffset3D
    {
        public Int32 x;
        public Int32 y;
        public Int32 z;
    }
}
