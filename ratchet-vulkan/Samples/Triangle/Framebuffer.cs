using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ratchet.Drawing.Vulkan;

namespace Triangle
{
    class Framebuffer
    {
        VkDevice _Device;
        public VkDevice Device { get { return _Device; } }

        VkRenderPass _RenderPass;
        public VkRenderPass RenderPass { get { return _RenderPass; } }

        VkFramebuffer _Framebuffer;
        IntPtr _ImagePtr;
        UInt64 _ImageSize = 0;

        int _Width;
        public int Width { get { return _Width; } }
        int _Height;
        public int Height { get { return _Height; } }


        public Framebuffer(VkDevice Device, int Width, int Height)
        {
            _Device = Device;
            _Width = Width;
            _Height = Height;
            VkImage image = _Device.CreateImage(VkImageCreateFlag.NONE,
                                         VkFormat.VK_FORMAT_B8G8R8A8_SRGB,
                                         Width, Height,
                                         1, 1,
                                         VkSampleCountFlag.VK_SAMPLE_COUNT_1,
                                         VkImageTiling.VK_IMAGE_TILING_LINEAR,
                                         VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_SRC | VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_DST,
                                         VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                                         null,
                                         VkImageLayout.VK_IMAGE_LAYOUT_GENERAL);

            _ImageSize = image.MemoryRequirements.size;

            // We will back this image with Host Accessible Memomy so we can map it an copy
            // the content from the Host.
            // To do so we need to find the right memory type first.
            VkMemoryType hostMemory = new VkMemoryType();
            foreach (VkMemoryType memoryType in image.MemoryRequirements.memoryTypes)
            {
                // Pick the first memory type that can be mapped into host memory
                if ((memoryType.propertyFlags & VkMemoryPropertyFlags.VK_MEMORY_PROPERTY_HOST_VISIBLE) != 0)
                {
                    hostMemory = memoryType;
                    break;
                }
            }

            // Allocate the backing memory for this image
            VkDeviceMemory Memory = _Device.AllocateMemory(image.MemoryRequirements.size, hostMemory);
            image.BindMemory(Memory, 0);
            // Create the CPU mapping
            _ImagePtr = Memory.Map(0, image.MemoryRequirements.size, VkMemoryMapFlag.NONE);


            VkImageView imageView = image.CreateImageView(VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, new VkImageSubresourceRange() { aspectMask = VkImageAspectFlag.VK_IMAGE_ASPECT_COLOR_BIT, baseArrayLayer = 0, baseMipLevel = 0, layerCount = 1, levelCount = 1 });


            VkAttachmentDescription colorAttachment = new VkAttachmentDescription();
            colorAttachment.format = image.Format;
            colorAttachment.samples = VkSampleCountFlag.VK_SAMPLE_COUNT_1;
            colorAttachment.loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR;
            colorAttachment.storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE;
            colorAttachment.stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE;
            colorAttachment.stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE;
            colorAttachment.initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;
            colorAttachment.finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;

            VkAttachmentReference colorAttachmentReference = new VkAttachmentReference();
            colorAttachmentReference.attachment = 0;
            colorAttachmentReference.layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

            VkSubpassDescription subpass = new VkSubpassDescription();
            subpass.pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS;
            subpass.colorAttachments = new VkAttachmentReference[] { colorAttachmentReference };
            subpass.depthStencilAttachment = null;
            subpass.inputAttachments = null;
            subpass.preserveAttachments = null;
            subpass.resolveAttachments = null;

            VkSubpassDependency dependency = new VkSubpassDependency();
            dependency.srcSubpass = VkSubpassDependency.VK_SUBPASS_EXTERNAL;
            dependency.dstSubpass = 0;
            dependency.srcStageMask = VkPipelineStageFlag.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT;
            dependency.srcAccessMask = 0;
            dependency.dstStageMask = VkPipelineStageFlag.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT;
            dependency.dstAccessMask = VkAccessFlag.VK_ACCESS_COLOR_ATTACHMENT_READ | VkAccessFlag.VK_ACCESS_COLOR_ATTACHMENT_WRITE;

            _RenderPass = _Device.CreateRenderPass(new VkAttachmentDescription[] { colorAttachment },
                                                    new VkSubpassDescription[] { subpass },
                                                    new VkSubpassDependency[] { dependency });

            _Framebuffer = _Device.CreateFramebuffer(_RenderPass, new VkImageView[] { imageView }, (uint)Width, (uint)Height, 1);
        }


        unsafe static void Copy(IntPtr Destination, IntPtr Source, int Cb)
        {
            byte* pDst = (byte*)Destination.ToPointer();
            byte* pSrc = (byte*)Source.ToPointer();
            while (Cb > 0) { *pDst++ = *pSrc++; Cb--; }
        }


        public VkFramebuffer GetFramebuffer() { return _Framebuffer; }

        public void BlitFramebufferToPointer(IntPtr pointer)
        {
            Copy(pointer, _ImagePtr, (int)_ImageSize);
        }
    }
}
