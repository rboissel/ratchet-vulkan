using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    struct VkMemoryRequirements_Native
    {
        public UInt64 size;
        public  UInt64 alignment;
        public UInt32 memoryTypeBits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkMemoryRequirements
    {
        public UInt64 size;
        public UInt64 alignment;
        public VkMemoryType[] memoryTypes;
    }
}
