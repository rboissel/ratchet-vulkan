using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    enum VkSubpassDescriptionFlags
    {
        NONE = 0
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkSubpassDescription_Native
    {
        public VkSubpassDescriptionFlags flags;
        public VkPipelineBindPoint pipelineBindPoint;
        public UInt32 inputAttachmentCount;
        public IntPtr pInputAttachments;
        public UInt32 colorAttachmentCount;
        public IntPtr pColorAttachments;
        public IntPtr pResolveAttachments;
        public IntPtr pDepthStencilAttachment;
        public UInt32 preserveAttachmentCount;
        public IntPtr pPreserveAttachments;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkSubpassDescription
    {
        public VkPipelineBindPoint pipelineBindPoint;
        public VkAttachmentReference[] inputAttachments;
        public VkAttachmentReference[] colorAttachments;
        public VkAttachmentReference[] resolveAttachments;
        public VkAttachmentReference? depthStencilAttachment;
        public UInt32[] preserveAttachments;
    }
}
