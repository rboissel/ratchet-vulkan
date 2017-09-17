using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Ratchet.Drawing.Vulkan
{
    public class VkClearColorValue
    {
        internal VkClearColorValue() { /* Prevent instanciation */ }
        [StructLayout(LayoutKind.Sequential)]
        public struct Float { [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] float32; }

        [StructLayout(LayoutKind.Sequential)]
        public struct Int32_t {[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public Int32[] int32; }

        [StructLayout(LayoutKind.Sequential)]
        public struct UInt32_t {[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public UInt32[] uint32; }
    }
}
