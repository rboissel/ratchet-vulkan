using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineLayoutCreateFlag
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineLayoutCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineLayoutCreateFlag flags;
        public UInt32 setLayoutCount;
        public IntPtr pSetLayouts;
        public UInt32 pushConstantRangeCount;
        public IntPtr pPushConstantRanges;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineLayoutCreateInfo
    {
        public VkPipelineLayoutCreateFlag flags;
        public VkDescriptorSetLayout[] setLayouts;
        public VkPushConstantRange[] pushConstantRanges;
    }
}
