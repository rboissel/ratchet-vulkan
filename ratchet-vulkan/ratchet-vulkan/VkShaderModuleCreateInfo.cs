using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkShaderModuleCreateFlag : UInt32
    {
        NONE = 0x0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkShaderModuleCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkShaderModuleCreateFlag flags;
        public IntPtr codeSize;
        public IntPtr pCode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkShaderModuleCreateInfo
    {
        public VkShaderModuleCreateFlag flags;
        public byte[] code;
    }
}
