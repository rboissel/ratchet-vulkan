using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public class VkClearValue
    {
        internal VkClearValue() { /* Prevent instanciation */ }
        public class VkClearColorValue : VkClearValue
        {
            internal VkClearColorValue() { /* Prevent instanciation */ }
            public class Float : VkClearColorValue { public float[] float32 = new float[4]; }
            public class Int32_t : VkClearColorValue { public Int32[] int32 = new Int32[4]; }
            public class UInt32_t : VkClearColorValue { public UInt32[] uint32 = new UInt32[4]; }

            [StructLayout(LayoutKind.Sequential)]
            internal struct Float_s {[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] float32; }

            [StructLayout(LayoutKind.Sequential)]
            internal struct Int32_t_s {[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public Int32[] int32; }

            [StructLayout(LayoutKind.Sequential)]
            internal struct UInt32_t_s {[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public UInt32[] uint32; }

        }

        public class VkClearDepthStencilValue : VkClearValue
        {
            public float depth;
            public UInt32 stencil;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct VkClearDepthStencilValue_s
        {
            public float depth;
            public UInt32 stencil;
        }

    }
}
