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
        VkStructureType sType;
        IntPtr pNext;
        VkPipelineRasterizationStateCreateFlag flags;
        UInt32 depthClampEnable;
        UInt32 rasterizerDiscardEnable;
        VkPolygonMode polygonMode;
        VkCullModeFlag cullMode;
        VkFrontFace frontFace;
        UInt32 depthBiasEnable;
        float depthBiasConstantFactor;
        float depthBiasClamp;
        float depthBiasSlopeFactor;
        float lineWidth;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineRasterizationStateCreateInfo
    {
        VkPipelineRasterizationStateCreateFlag flags;
        bool depthClampEnable;
        bool rasterizerDiscardEnable;
        VkPolygonMode polygonMode;
        VkCullModeFlag cullMode;
        VkFrontFace frontFace;
        bool depthBiasEnable;
        float depthBiasConstantFactor;
        float depthBiasClamp;
        float depthBiasSlopeFactor;
        float lineWidth;
    }
}
