using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    struct VkMemoryAllocateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt64 allocationSize;
        public UInt32 memoryTypeIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkMemoryAllocateInfo
    {
        public UInt64 allocationSize;
        public UInt32 memoryTypeIndex;
    }
}
