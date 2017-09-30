using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineMultisampleStateCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineMultisampleStateCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineMultisampleStateCreateFlag flags;
        public VkSampleCountFlag rasterizationSamples;
        public UInt32 sampleShadingEnable;
        public float minSampleShading;
        public IntPtr pSampleMask;
        public UInt32 alphaToCoverageEnable;
        public UInt32 alphaToOneEnable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineMultisampleStateCreateInfo
    {
        public VkPipelineMultisampleStateCreateFlag flags;
        public VkSampleCountFlag rasterizationSamples;
        public bool sampleShadingEnable;
        public float minSampleShading;
        public UInt32[] sampleMask;
        public bool alphaToCoverageEnable;
        public bool alphaToOneEnable;
    }
}
