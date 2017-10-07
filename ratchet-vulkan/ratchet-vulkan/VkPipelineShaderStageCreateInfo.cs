using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineShaderStageCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    public enum VkShaderStageFlag : UInt32
    {
        NONE = 0x0,
        VK_SHADER_STAGE_VERTEX = 0x00000001,
        VK_SHADER_STAGE_TESSELLATION_CONTROL = 0x00000002,
        VK_SHADER_STAGE_TESSELLATION_EVALUATION = 0x00000004,
        VK_SHADER_STAGE_GEOMETRY = 0x00000008,
        VK_SHADER_STAGE_FRAGMENT = 0x00000010,
        VK_SHADER_STAGE_COMPUTE = 0x00000020,
        VK_SHADER_STAGE_ALL_GRAPHICS = 0x0000001F,
        VK_SHADER_STAGE_ALL = 0x7FFFFFFF,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineShaderStageCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineShaderStageCreateFlag flags;
        public VkShaderStageFlag stage;
        public UInt64 module;
        public IntPtr pName;
        public IntPtr pSpecializationInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineShaderStageCreateInfo
    {
        public VkPipelineShaderStageCreateFlag flags;
        public VkShaderStageFlag stage;
        public VkShaderModule module;
        public string name;
        public VkSpecializationInfo? specializationInfo;

        public VkPipelineShaderStageCreateInfo(VkShaderModule module, string entryPoint, VkShaderStageFlag stage)
        {
            this.module = module;
            name = entryPoint;
            flags = VkPipelineShaderStageCreateFlag.NONE;
            this.stage = stage;
            specializationInfo = null;
        }
    }
}
