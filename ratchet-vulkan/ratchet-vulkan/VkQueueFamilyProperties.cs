using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkQueueFlags : UInt32
    {
        VK_QUEUE_GRAPHICS = 0x00000001,
        VK_QUEUE_COMPUTE = 0x00000002,
        VK_QUEUE_TRANSFER = 0x00000004,
        VK_QUEUE_SPARSE_BINDING = 0x00000008,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct VkQueueFamilyProperties_Native
    {
        public VkQueueFlags queueFlags;
        public UInt32 queueCount;
        public UInt32 timestampValidBits;
        public VkExtent3D minImageTransferGranularity;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkQueueFamilyProperties
    {
        public VkQueueFlags queueFlags;
        public UInt32 queueCount;
        public UInt32 timestampValidBits;
        public VkExtent3D minImageTransferGranularity;
        public UInt32 index;
        internal VkPhysicalDevice physicalDevice;
    }
}                                                                                                                                                                                                                                                                                                                                                                   