using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct VkApplicationInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public IntPtr applicationName;
        public Int32 applicationVersion;
        public IntPtr engineName;
        public Int32 engineVersion;
        public Int32 apiVersion;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkApplicationInfo
    {
        public string applicationName;
        public Int32 applicationVersion;
        public string engineName;
        public Int32 engineVersion;
        public Int32 apiVersion;
    }
}
