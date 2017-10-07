using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkImageView
    {
        internal UInt64 _Handle;
        VkDevice _Parent;
        VkImage _Image;

        public VkDevice Device { get { return _Parent; } }
        public VkImage Image { get { return _Image; } }

        internal VkImageView(UInt64 Handle, VkDevice Parent, VkImage Image)
        {
            _Parent = Parent;
            _Handle = Handle;
            _Image = Image;
        }
    }
}
