using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkCommandBuffer
    {
        internal IntPtr _Handle;
        VkCommandPool _Parent;

        public VkCommandPool CommandPool { get { return _Parent; } }

        internal VkCommandBuffer(IntPtr Handle, VkCommandPool Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
        }

    }
}
