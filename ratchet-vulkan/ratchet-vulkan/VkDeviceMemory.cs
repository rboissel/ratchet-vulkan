using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VkDeviceMemory
    {
        internal UInt64 _Handle;
        internal VkDevice _Parent;
        internal VkDeviceMemory(UInt64 Handle, VkDevice Device)
        {
            _Parent = Device;
            _Handle = Handle;
        }
        public unsafe IntPtr Map(UInt64 offset, UInt64 size, VkMemoryMapFlag flags)
        {
            IntPtr ptr = new IntPtr(0);
            _Parent.vkMapMemory(_Parent._Handle, _Handle, offset, size, flags, new IntPtr(&ptr));
            return ptr;
        }
    }
}
