using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    enum VkFramebufferCreateFlag : UInt32
    {
        NONE = 0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkFramebufferCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFramebufferCreateFlag flags;
        public UInt64 renderPass;
        public UInt32 attachmentCount;
        public IntPtr pAttachments;
        public UInt32 width;
        public UInt32 height;
        public UInt32 layers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkFramebufferCreateInfo
    {
        public VkRenderPass renderPass;
        public VkImageView[] attachments;
        public UInt32 width;
        public UInt32 height;
        public UInt32 layers;
    }
}
