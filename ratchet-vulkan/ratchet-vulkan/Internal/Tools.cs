using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    static class Tools
    {
        static unsafe internal IntPtr toUTF8ZeroTerminated(string Str)
        {
            byte[] strUTF8 = System.Text.Encoding.UTF8.GetBytes(Str);
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(strUTF8.Length + 2);
            byte* rawPtr = (byte*)ptr.ToPointer();
            for (int n = 0; n < strUTF8.Length; n++) { rawPtr[n] = strUTF8[n]; }
            rawPtr[strUTF8.Length] = 0;
            rawPtr[strUTF8.Length + 1] = 0;
            return ptr;
        }
    }
}
