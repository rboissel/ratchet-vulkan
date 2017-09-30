using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineColorBlendStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineColorBlendAttachmentState
    {
        public UInt32 blendEnable;
        public VkBlendFactor srcColorBlendFactor;
        public VkBlendFactor dstColorBlendFactor;
        public VkBlendOp colorBlendOp;
        public VkBlendFactor srcAlphaBlendFactor;
        public VkBlendFactor dstAlphaBlendFactor;
        public VkBlendOp alphaBlendOp;
        public VkColorComponentFlag colorWriteMask;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineColorBlendStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineColorBlendStateCreateFlag flags;
        public UInt32 logicOpEnable;
        public VkLogicOp logicOp;
        public UInt32 attachmentCount;
        public IntPtr pAttachments;
        public float blendConstants_R;
        public float blendConstants_G;
        public float blendConstants_B;
        public float blendConstants_A;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineColorBlendStateCreateInfo
    {
        public VkPipelineColorBlendStateCreateFlag flags;
        public bool logicOpEnable;
        public VkLogicOp logicOp;
        public VkPipelineColorBlendAttachmentState[] attachments;
        public float blendConstants_R;
        public float blendConstants_G;
        public float blendConstants_B;
        public float blendConstants_A;
    }
}
