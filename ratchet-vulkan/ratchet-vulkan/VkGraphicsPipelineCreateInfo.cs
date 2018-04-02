using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    struct VkGraphicsPipelineCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCreateFlags flags;
        public UInt32 stageCount;
        public IntPtr pStages;
        public IntPtr pVertexInputState;
        public IntPtr pInputAssemblyState;
        public IntPtr pTessellationState;
        public IntPtr pViewportState;
        public IntPtr pRasterizationState;
        public IntPtr pMultisampleState;
        public IntPtr pDepthStencilState;
        public IntPtr pColorBlendState;
        public IntPtr pDynamicState;
        public UInt64 layout;
        public UInt64 renderPass;
        public UInt32 subpass;
        public UInt64 basePipelineHandle;
        public Int32 basePipelineIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkGraphicsPipelineCreateInfo
    {
        public VkPipelineCreateFlags flags;
        public VkPipelineShaderStageCreateInfo[] stages;
        public VkPipelineVertexInputStateCreateInfo vertexInputState;
        public VkPipelineInputAssemblyStateCreateInfo inputAssemblyState;
        public VkPipelineTessellationStateCreateInfo? tessellationState;
        public VkPipelineViewportStateCreateInfo? viewportState;
        public VkPipelineRasterizationStateCreateInfo rasterizationState;
        public VkPipelineMultisampleStateCreateInfo? multisampleState;
        public VkPipelineDepthStencilStateCreateInfo? depthStencilState;
        public VkPipelineColorBlendStateCreateInfo? colorBlendState;
        public VkPipelineDynamicStateCreateInfo? dynamicState;
        public VkPipelineLayout layout;
        public VkRenderPass renderPass;
        public UInt32 subpass;
        public VkPipeline basePipeline;
        public Int32 basePipelineIndex;
    }
}
