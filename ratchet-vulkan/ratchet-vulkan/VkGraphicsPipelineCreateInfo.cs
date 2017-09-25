using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    struct VkGraphicsPipelineCreateInfo_Native
    {
        VkStructureType sType;
        IntPtr pNext;
        VkPipelineCreateFlags flags;
        UInt32 stageCount;
        IntPtr pStages;
        IntPtr pVertexInputState;
        IntPtr pInputAssemblyState;
        IntPtr pTessellationState;
        IntPtr pViewportState;
        IntPtr pRasterizationState;
        IntPtr pMultisampleState;
        IntPtr pDepthStencilState;
        IntPtr pColorBlendState;
        IntPtr pDynamicState;
        UInt64 layout;
        UInt64 renderPass;
        UInt32 subpass;
        UInt64 basePipelineHandle;
        UInt32 basePipelineIndex;
    }

    struct VkGraphicsPipelineCreateInfo
    {
        VkPipelineCreateFlags flags;
        VkPipelineShaderStageCreateInfo[] stages;
        VkPipelineVertexInputStateCreateInfo vertexInputState;
        VkPipelineInputAssemblyStateCreateInfo inputAssemblyState;
        VkPipelineTessellationStateCreateInfo? pTessellationState;
        VkPipelineViewportStateCreateInfo? pViewportState;
        VkPipelineRasterizationStateCreateInfo? pRasterizationState;
        //VkPipelineMultisampleStateCreateInfo* pMultisampleState;
        //VkPipelineDepthStencilStateCreateInfo* pDepthStencilState;
        //VkPipelineColorBlendStateCreateInfo* pColorBlendState;
        //VkPipelineDynamicStateCreateInfo* pDynamicState;
        VkPipelineLayout layout;
        VkRenderPass renderPass;
        UInt32 subpass;
        UInt64 basePipelineHandle;
        UInt32 basePipelineIndex;
    }
}
