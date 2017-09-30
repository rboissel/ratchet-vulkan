using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineRasterizationStateCreateFlag : UInt32
    {
        NONE = 0x0
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineRasterizationStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRasterizationStateCreateFlag flags;
        public UInt32 depthClampEnable;
        public UInt32 rasterizerDiscardEnable;
        public VkPolygonMode polygonMode;
        public VkCullModeFlag cullMode;
        public VkFrontFace frontFace;
        public UInt32 depthBiasEnable;
        public float depthBiasConstantFactor;
        public float depthBiasClamp;
        public float depthBiasSlopeFactor;
        public float lineWidth;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineRasterizationStateCreateInfo
    {
        public VkPipelineRasterizationStateCreateFlag flags;
        public bool depthClampEnable;
        public bool rasterizerDiscardEnable;
        public VkPolygonMode polygonMode;
        public VkCullModeFlag cullMode;
        public VkFrontFace frontFace;
        public bool depthBiasEnable;
        public float depthBiasConstantFactor;
        public float depthBiasClamp;
        public float depthBiasSlopeFactor;
        public float lineWidth;
    }
}
