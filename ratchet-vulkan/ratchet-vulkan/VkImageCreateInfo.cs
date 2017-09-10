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
        VK_IMAGE_CREATE_SPARSE_BINDING = 0x00000001,
        VK_IMAGE_CREATE_SPARSE_RESIDENCY = 0x00000002,
        VK_IMAGE_CREATE_SPARSE_ALIASED = 0x00000004,
        VK_IMAGE_CREATE_MUTABLE_FORMAT = 0x00000008,
        VK_IMAGE_CREATE_CUBE_COMPATIBLE = 0x00000010,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkImageCreateInfo_Native
    {
        VkStructureType sType;
        IntPtr pNext;
        VkImageCreateFlag flags;
        VkImageType imageType;
        VkFormat format;
        VkExtent3D extent;
        UInt32 mipLevels;
        UInt32 arrayLayers;
        VkSampleCountFlagBits samples;
        VkImageTiling tiling;
        VkImageUsageFlag usage;
        VkSharingMode sharingMode;
        UInt32 queueFamilyIndexCount;
        IntPtr pQueueFamilyIndices;
        VkImageLayout initialLayout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkImageCreateInfo
    {
        VkImageCreateFlag flags;
        VkImageType imageType;
        VkFormat format;
        VkExtent3D extent;
        UInt32 mipLevels;
        UInt32 arrayLayers;
        VkSampleCountFlagBits samples;
        VkImageTiling tiling;
        VkImageUsageFlag usage;
        VkSharingMode sharingMode;
        VkQueueFamilyProperties[] queueFamilyIndices;
        VkImageLayout initialLayout;
    }
}
