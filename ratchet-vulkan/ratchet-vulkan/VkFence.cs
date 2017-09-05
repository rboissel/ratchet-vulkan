using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkFence
    {
        internal IntPtr _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }

        internal VkFence(VkDevice Parent, IntPtr Handle)
        {
            _Handle = Handle;
            _Parent = Parent;
            if (_Parent.vkGetFenceStatus == null) { throw new NotImplementedException("Fences are not fully supported on this device"); }
        }

        public VkResult GetFenceStatus() { return _Parent.vkGetFenceStatus(_Parent._Handle, _Handle); }
        public unsafe bool WaitForFence(UInt64 timeout)
        {
            fixed (IntPtr* pHandle = &_Handle)
            {
                VkResult result = _Parent.vkWaitForFences(_Parent._Handle, 1, new IntPtr(pHandle), true, timeout);
                if (result == VkResult.VK_SUCCESS) { return true; }
                else if (result == VkResult.VK_TIMEOUT) { return false; }
                throw new Exception(result.ToString());
            }
        }
    }
}
