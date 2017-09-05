using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    internal abstract class VkLibrary
    {
        public abstract IntPtr vkGetInstanceProcAddr(IntPtr vkInstance, string Proc);
    }
}
