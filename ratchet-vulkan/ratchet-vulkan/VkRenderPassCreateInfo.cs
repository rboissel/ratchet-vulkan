using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    enum VkRenderPassCreateFlags : UInt32
    {
        NONE = 0,
    }

    [StructLayout(LayoutKind.Sequential)]
    struct VkRenderPassCreateInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPassCreateFlags flags;
        public UInt32 attachmentCount;
        public IntPtr pAttachments;
        public UInt32 subpassCount;
        public IntPtr pSubpasses;
        public UInt32 dependencyCount;
        public IntPtr pDependencies;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkRenderPassCreateInfo
    {
        public VkAttachmentDescription[] attachments;
        public VkSubpassDescription[] subpasses;
        public VkSubpassDependency[] dependencies;
    }
}
