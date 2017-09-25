using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkPipelineTessellationStateCreateFlag : UInt32
    {
        NONE = 0x0
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkPipelineTessellationStateCreateInfo_Native
    {
        VkStructureType sType;
        IntPtr pNext;
        VkPipelineTessellationStateCreateFlag flags;
        UInt32 patchControlPoints;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPipelineTessellationStateCreateInfo
    {
        VkPipelineTessellationStateCreateFlag flags;
        UInt32 patchControlPoints;
    }
}
