using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineDepthStencilStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineDepthStencilStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineDepthStencilStateCreateFlag flags;
        public UInt32 depthTestEnable;
        public UInt32 depthWriteEnable;
        public VkCompareOp depthCompareOp;
        public UInt32 depthBoundsTestEnable;
        public UInt32 stencilTestEnable;
        public VkStencilOpState front;
        public VkStencilOpState back;
        public float minDepthBounds;
        public float maxDepthBounds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineDepthStencilStateCreateInfo
    {
        public VkPipelineDepthStencilStateCreateFlag flags;
        public bool depthTestEnable;
        public bool depthWriteEnable;
        public VkCompareOp depthCompareOp;
        public bool depthBoundsTestEnable;
        public bool stencilTestEnable;
        public VkStencilOpState front;
        public VkStencilOpState back;
        public float minDepthBounds;
        public float maxDepthBounds;
    }
}
