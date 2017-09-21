using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    struct VkRenderPassBeginInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt64 renderPassHandle;
        public UInt64 framebufferHandle;
        public VkRect2D renderArea;
        public UInt32 clearValueCount;
        public IntPtr pClearValues;
    }

    public struct VkRenderPassBeginInfo
    {
        public VkRenderPass renderPass;
        public VkFramebuffer framebuffer;
        public VkRect2D renderArea;
        public VkClearValue[] clearValues;
    }
}
