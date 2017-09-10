using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkQueue
    {
        internal IntPtr _Handle;
        VkDevice _Parent;
        VkQueueFamilyProperties _QueueFamily;

        public VkDevice Device { get { return _Parent; } }
        public VkQueueFamilyProperties Family { get { return _QueueFamily; } }


        internal VkQueue(IntPtr Handle, VkDevice Parent, VkQueueFamilyProperties QueueFamily)
        {
            _Parent = Parent;
            _Handle = Handle;
            _QueueFamily = QueueFamily;
        }

        public void Submit(VkSubmitInfo[] submitInfo)
        {

        }
    }
}
