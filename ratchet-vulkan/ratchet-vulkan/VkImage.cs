using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkImage
    {
        internal IntPtr _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }


        internal VkImage(IntPtr Handle, VkDevice Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
        }
    }
}
