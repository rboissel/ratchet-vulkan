using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkMemoryHeapFlag : UInt32
    {
        VK_MEMORY_HEAP_DEVICE_LOCAL_BIT = 0x00000001,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkMemoryHeap
    {
        UInt64 size;
        VkMemoryHeapFlag flags;
    }
}
