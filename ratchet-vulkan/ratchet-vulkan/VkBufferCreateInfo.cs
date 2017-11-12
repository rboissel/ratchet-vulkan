using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkBufferCreateFlag : UInt32
    {
        VK_BUFFER_CREATE_SPARSE_BINDING = 0x00000001,
        VK_BUFFER_CREATE_SPARSE_RESIDENCY = 0x00000002,
        VK_BUFFER_CREATE_SPARSE_ALIASED = 0x00000004,
    }

    public enum VkBufferUsageFlag : UInt32
    {
        VK_BUFFER_USAGE_TRANSFER_SRC = 0x00000001,
        VK_BUFFER_USAGE_TRANSFER_DST = 0x00000002,
        VK_BUFFER_USAGE_UNIFORM_TEXEL_BUFFER = 0x00000004,
        VK_BUFFER_USAGE_STORAGE_TEXEL_BUFFER = 0x00000008,
        VK_BUFFER_USAGE_UNIFORM_BUFFER = 0x00000010,
        VK_BUFFER_USAGE_STORAGE_BUFFER = 0x00000020,
        VK_BUFFER_USAGE_INDEX_BUFFER = 0x00000040,
        VK_BUFFER_USAGE_VERTEX_BUFFER = 0x00000080,
        VK_BUFFER_USAGE_INDIRECT_BUFFER = 0x00000100,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkBufferCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBufferCreateFlag flags;
        public UInt64 size;
        public VkBufferUsageFlag usage;
        public VkSharingMode sharingMode;
        public UInt32 queueFamilyIndexCount;
        public IntPtr pQueueFamilyIndices;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkBufferCreateInfo
    {
        public VkBufferCreateFlag flags;
        public UInt64 size;
        public VkBufferUsageFlag usage;
        public VkSharingMode sharingMode;
        public VkQueueFamilyProperties[] queueFamilies;
    }
}
