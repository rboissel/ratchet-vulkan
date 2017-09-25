using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    struct VkSpecializationInfo_Native
    {
        public UInt32 mapEntryCount;
        public IntPtr pMapEntries;
        public IntPtr dataSize;
        public IntPtr pData;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkSpecializationInfo
    {

    }
}
