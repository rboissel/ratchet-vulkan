using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineVertexInputStateCreateFlags : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineInputAssemblyStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineVertexInputStateCreateFlags flags;
        public UInt32 vertexBindingDescriptionCount;
        public IntPtr pVertexBindingDescriptions;
        public UInt32 vertexAttributeDescriptionCount;
        public IntPtr pVertexAttributeDescriptions;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineInputAssemblyStateCreateInfo
    {
        public VkPipelineVertexInputStateCreateFlags flags;
        public VkVertexInputBindingDescription[] vertexBindingDescriptions;
        public VkVertexInputAttributeDescription[] vertexAttributeDescriptions;
    }
}
