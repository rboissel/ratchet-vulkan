using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ratchet.Drawing.Vulkan;

namespace Triangle
{
    class Pipeline
    {
        VkPipeline _Pipeline;

        public Pipeline(Framebuffer Framebuffer, VkPipelineLayout PipelineLayout, VkShaderModule VertexShader, string VertexShaderEntryPoint, VkShaderModule FragmentShader, string FragmentShaderEntryPoint)
        {
            VkPipelineVertexInputStateCreateInfo vertexInputInfo = new VkPipelineVertexInputStateCreateInfo();
            vertexInputInfo.flags = VkPipelineVertexInputStateCreateFlag.NONE;
            vertexInputInfo.vertexAttributeDescriptions = null;
            vertexInputInfo.vertexBindingDescriptions = null;

            VkPipelineInputAssemblyStateCreateInfo inputAssemblyInfo = new VkPipelineInputAssemblyStateCreateInfo();
            inputAssemblyInfo.flags = VkPipelineInputAssemblyStateCreateFlag.NONE;
            inputAssemblyInfo.primitiveRestartEnable = false;
            inputAssemblyInfo.topology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST;

            VkPipelineViewportStateCreateInfo viewportInfo = new VkPipelineViewportStateCreateInfo();
            viewportInfo.flags = VkPipelineViewportStateCreateFlag.NONE;
            viewportInfo.scissors = new VkRect2D[] { new VkRect2D(0, 0, (uint)Framebuffer.Width, (uint)Framebuffer.Height) };
            viewportInfo.viewports = new VkViewport[] { new VkViewport(0.0f, 0.0f, (float)(Framebuffer.Width), (float)(Framebuffer.Height), 0.0f, 1.0f) };

            VkPipelineRasterizationStateCreateInfo rasterizationInfo = new VkPipelineRasterizationStateCreateInfo();
            rasterizationInfo.flags = VkPipelineRasterizationStateCreateFlag.NONE;
            rasterizationInfo.depthClampEnable = false;
            rasterizationInfo.rasterizerDiscardEnable = false;
            rasterizationInfo.polygonMode = VkPolygonMode.VK_POLYGON_MODE_FILL;
            rasterizationInfo.lineWidth = 1.0f;
            rasterizationInfo.cullMode = VkCullModeFlag.VK_CULL_MODE_BACK;
            rasterizationInfo.frontFace = VkFrontFace.VK_FRONT_FACE_CLOCKWISE;
            rasterizationInfo.depthBiasEnable = false;

            VkPipelineMultisampleStateCreateInfo multisamplingInfo = new VkPipelineMultisampleStateCreateInfo();
            multisamplingInfo.flags = VkPipelineMultisampleStateCreateFlag.NONE;
            multisamplingInfo.sampleShadingEnable = false;
            multisamplingInfo.rasterizationSamples = VkSampleCountFlag.VK_SAMPLE_COUNT_1;

            VkPipelineColorBlendStateCreateInfo colorBlendingInfo = new VkPipelineColorBlendStateCreateInfo();
            colorBlendingInfo.flags = VkPipelineColorBlendStateCreateFlag.NONE;
            colorBlendingInfo.logicOpEnable = false;
            colorBlendingInfo.logicOp = VkLogicOp.VK_LOGIC_OP_COPY;
            colorBlendingInfo.attachments = new VkPipelineColorBlendAttachmentState[] { new VkPipelineColorBlendAttachmentState() { colorWriteMask = VkColorComponentFlag.VK_COLOR_COMPONENT_R | VkColorComponentFlag.VK_COLOR_COMPONENT_G | VkColorComponentFlag.VK_COLOR_COMPONENT_B | VkColorComponentFlag.VK_COLOR_COMPONENT_A, blendEnable = 0 } };
            _Pipeline = Framebuffer.Device.CreateGraphicsPipeline(null, VkPipelineCreateFlags.NONE,
                                                                  new VkPipelineShaderStageCreateInfo[] { new VkPipelineShaderStageCreateInfo(VertexShader, VertexShaderEntryPoint, VkShaderStageFlag.VK_SHADER_STAGE_VERTEX), new VkPipelineShaderStageCreateInfo(FragmentShader, FragmentShaderEntryPoint, VkShaderStageFlag.VK_SHADER_STAGE_FRAGMENT) },
                                                                  vertexInputInfo,
                                                                  inputAssemblyInfo,
                                                                  null,
                                                                  viewportInfo,
                                                                  rasterizationInfo,
                                                                  multisamplingInfo,
                                                                  null,
                                                                  colorBlendingInfo,
                                                                  null,
                                                                  PipelineLayout,
                                                                  Framebuffer.RenderPass,
                                                                  0,
                                                                  null, 
                                                                  -1
                                                                  );
        }

        public void BindPipeline(VkCommandBuffer CommandBuffer)
        {
            CommandBuffer.CmdBindPipeline(VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS, _Pipeline);
        }
    }
}
