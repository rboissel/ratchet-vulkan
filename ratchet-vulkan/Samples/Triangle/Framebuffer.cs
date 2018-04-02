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
        VkImage _FrameBufferColor;
        public VkImage FrameBufferColor { get { return _FrameBufferColor; } }
        public VkBuffer _TransferBuffer;
        public IntPtr _TransferBufferPtr;
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
            _FrameBufferColor = _Device.CreateImage(VkImageCreateFlag.NONE,
                                                    VkFormat.VK_FORMAT_B8G8R8A8_SRGB,
                                                    Width, Height,
                                                    1, 1,
                                                    VkSampleCountFlag.VK_SAMPLE_COUNT_1,
                                                    VkImageTiling.VK_IMAGE_TILING_OPTIMAL,
                                                    VkImageUsageFlag.VK_IMAGE_USAGE_COLOR_ATTACHMENT,
                                                    VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                                                    null,
                                                    VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED);

            _ImageSize = _FrameBufferColor.MemoryRequirements.size;


            // We will back this image with Device Accessible Memomy so we can map it an copy
            // the content from the Host.
            // To do so we need to find the right memory type first.
            VkMemoryType deviceMemory = new VkMemoryType();
            foreach (VkMemoryType memoryType in _FrameBufferColor.MemoryRequirements.memoryTypes)
            {
                // Pick the first memory type that can be mapped into host memory
                if ((memoryType.propertyFlags & VkMemoryPropertyFlags.VK_MEMORY_PROPERTY_DEVICE_LOCAL) != 0)
                {
                    deviceMemory = memoryType;
                    break;
                }
            }

            VkDeviceMemory FrameBufferMemory = _Device.AllocateMemory(_FrameBufferColor.MemoryRequirements.size, deviceMemory);
            _FrameBufferColor.BindMemory(FrameBufferMemory, 0);

            // Allocate the host visible memory to transfer the framebuffer
            _TransferBuffer = _Device.CreateBuffer(0, _FrameBufferColor.MemoryRequirements.size, VkBufferUsageFlag.VK_BUFFER_USAGE_TRANSFER_DST, VkSharingMode.VK_SHARING_MODE_EXCLUSIVE, new VkQueueFamilyProperties[] { _Device.Queues[0].Family });

            // We will use a host visible buffer so we can map it an copy
            // the content from the Host.
            // To do so we need to find the right memory type first.
            VkMemoryType hostMemory = new VkMemoryType();
            foreach (VkMemoryType memoryType in _TransferBuffer.MemoryRequirements.memoryTypes)
            {
                // Pick the first memory type that can be mapped into host memory
                if ((memoryType.propertyFlags & VkMemoryPropertyFlags.VK_MEMORY_PROPERTY_HOST_VISIBLE) != 0)
                {
                    hostMemory = memoryType;
                    break;
                }
            }

            VkDeviceMemory TransferBufferMemory = _Device.AllocateMemory(_ImageSize, hostMemory);
            _TransferBuffer.BindMemory(TransferBufferMemory, 0);
            _TransferBufferPtr = TransferBufferMemory.Map(0, _ImageSize, VkMemoryMapFlag.NONE);


            VkImageView imageView = _FrameBufferColor.CreateImageView(VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, new VkImageSubresourceRange() { aspectMask = VkImageAspectFlag.VK_IMAGE_ASPECT_COLOR_BIT, baseArrayLayer = 0, baseMipLevel = 0, layerCount = 1, levelCount = 1 });


            VkAttachmentDescription colorAttachment = new VkAttachmentDescription();
            colorAttachment.format = _FrameBufferColor.Format;
            colorAttachment.samples = VkSampleCountFlag.VK_SAMPLE_COUNT_1;
            colorAttachment.loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR;
            colorAttachment.storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE;
            colorAttachment.stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE;
            colorAttachment.stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE;
            colorAttachment.initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;
            colorAttachment.finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

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

        public void BlitFramebufferToPointer(VkQueue Queue, IntPtr pointer)
        {
            Queue.WaitIdle();
            Copy(pointer, _TransferBufferPtr, Width * Height * 4);
        }
    }
}
