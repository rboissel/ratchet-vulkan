using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineVertexInputStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineVertexInputStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineVertexInputStateCreateFlag flags;
        public UInt32 vertexBindingDescriptionCount;
        public IntPtr pVertexBindingDescriptions;
        public UInt32 vertexAttributeDescriptionCount;
        public IntPtr pVertexAttributeDescriptions;
    }

    public enum VkVertexInputRate : UInt32
    {
        VK_VERTEX_INPUT_RATE_VERTEX = 0,
        VK_VERTEX_INPUT_RATE_INSTANCE = 1,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkVertexInputBindingDescription
    {
        public UInt32 binding;
        public UInt32 stride;
        public VkVertexInputRate inputRate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkVertexInputAttributeDescription
    {
        UInt32 location;
        UInt32 binding;
        VkFormat format;
        UInt32 offset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineVertexInputStateCreateInfo_Native
    {
        public VkPipelineVertexInputStateCreateFlag flags;
        public VkVertexInputBindingDescription[] vertexBindingDescriptions;
        public VkVertexInputAttributeDescription[] vertexAttributeDescriptions;
    }
}
