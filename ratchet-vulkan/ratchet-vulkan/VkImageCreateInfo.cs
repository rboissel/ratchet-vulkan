using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkImageCreateFlag : UInt32
    {
        NONE = 0x00000000,
        VK_IMAGE_CREATE_SPARSE_BINDING = 0x00000001,
        VK_IMAGE_CREATE_SPARSE_RESIDENCY = 0x00000002,
        VK_IMAGE_CREATE_SPARSE_ALIASED = 0x00000004,
        VK_IMAGE_CREATE_MUTABLE_FORMAT = 0x00000008,
        VK_IMAGE_CREATE_CUBE_COMPATIBLE = 0x00000010,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkImageCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageCreateFlag flags;
        public VkImageType imageType;
        public VkFormat format;
        public VkExtent3D extent;
        public UInt32 mipLevels;
        public UInt32 arrayLayers;
        public VkSampleCountFlag samples;
        public VkImageTiling tiling;
        public VkImageUsageFlag usage;
        public VkSharingMode sharingMode;
        public UInt32 queueFamilyIndexCount;
        public IntPtr pQueueFamilyIndices;
        public VkImageLayout initialLayout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkImageCreateInfo
    {
        public VkImageCreateFlag flags;
        public VkImageType imageType;
        public VkFormat format;
        public VkExtent3D extent;
        public UInt32 mipLevels;
        public UInt32 arrayLayers;
        public VkSampleCountFlag samples;
        public VkImageTiling tiling;
        public VkImageUsageFlag usage;
        public VkSharingMode sharingMode;
        public VkQueueFamilyProperties[] queueFamilies;
        public VkImageLayout initialLayout;
    }
}
