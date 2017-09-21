using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkMemoryPropertyFlags : UInt32
    {
        VK_MEMORY_PROPERTY_DEVICE_LOCAL = 0x00000001,
        VK_MEMORY_PROPERTY_HOST_VISIBLE = 0x00000002,
        VK_MEMORY_PROPERTY_HOST_COHERENT = 0x00000004,
        VK_MEMORY_PROPERTY_HOST_CACHED = 0x00000008,
        VK_MEMORY_PROPERTY_LAZILY_ALLOCATED = 0x00000010,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkMemoryType_Native
    {
        public VkMemoryPropertyFlags propertyFlags;
        public UInt32 heapIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkMemoryType
    {
        public VkMemoryPropertyFlags propertyFlags;
        public UInt32 heapIndex;
        internal int index;
    }
}
