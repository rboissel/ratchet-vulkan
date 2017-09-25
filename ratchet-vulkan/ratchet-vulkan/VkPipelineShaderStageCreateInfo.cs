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
        VK_SHADER_STAGE_VERTEX_BIT = 0x00000001,
        VK_SHADER_STAGE_TESSELLATION_CONTROL_BIT = 0x00000002,
        VK_SHADER_STAGE_TESSELLATION_EVALUATION_BIT = 0x00000004,
        VK_SHADER_STAGE_GEOMETRY_BIT = 0x00000008,
        VK_SHADER_STAGE_FRAGMENT_BIT = 0x00000010,
        VK_SHADER_STAGE_COMPUTE_BIT = 0x00000020,
        VK_SHADER_STAGE_ALL_GRAPHICS = 0x0000001F,
        VK_SHADER_STAGE_ALL = 0x7FFFFFFF,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineShaderStageCreateInfo_Native
    {
        VkStructureType sType;
        IntPtr pNext;
        VkPipelineShaderStageCreateFlag flags;
        VkShaderStageFlag stage;
        UInt64 module;
        IntPtr pName;
        IntPtr pSpecializationInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineShaderStageCreateInfo
    {
        VkPipelineShaderStageCreateFlag flags;
        VkShaderStageFlag stage;
        VkShaderModule module;
        string pName;
        VkSpecializationInfo? pSpecializationInfo;
    }
}
