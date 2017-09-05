using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkRenderPass
    {
        internal IntPtr _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }

        internal VkRenderPass(IntPtr Handle, VkDevice Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
        }
    }
}
