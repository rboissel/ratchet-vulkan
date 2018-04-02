using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ratchet.Drawing.Vulkan;

namespace Triangle
{
    public partial class Triangle : Form
    {
        System.Drawing.Bitmap _Bitmap;


        VkDevice _Device;
        VkInstance _Instance;
        VkQueue _Queue;
        VkCommandBuffer _CommandBuffer;
        VkFence _Fence;
        Framebuffer _Framebuffer;
        Pipeline _GraphicsPipeline;

        VkShaderModule _VertexShader;
        VkShaderModule _FramgemtShader;


        public void InitializeVulkan()
        {
            // Create the VUlkan instance that we will use for this app
            _Instance = new VkInstance("Triangle - Sample", 1, "Ratchet", 1);


            // Now lets walk all physical device and find the first one that supports graphics queue
            foreach (VkPhysicalDevice physicalDevice in _Instance.vkEnumeratePhysicalDevices())
            {
                foreach (VkQueueFamilyProperties queueFamilly in physicalDevice.QueueFamilies)
                {
                    if ((queueFamilly.queueFlags & VkQueueFlags.VK_QUEUE_GRAPHICS) != 0)
                    {
                        // We have a physical device that supports graphics queue, we can now create a Device on it
                        // with one queue and use it as our main device for this sample
                        _Device = physicalDevice.CreateDevice(new VkDeviceQueueCreateInfo[] { new VkDeviceQueueCreateInfo() { queueCount = 1, queueFamily = queueFamilly, queuePriorities = new float[] { 1.0f } } });

                        // Ok now lets grab the graphics queue back. Technically there should only be one
                        // But just to be clean we do an iteration and look for the queue that matches our
                        // need
                        foreach (VkQueue queue in _Device.Queues)
                        {
                            if (queue.Family.queueFlags == queueFamilly.queueFlags)
                            {
                                _Queue = queue;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public Triangle()
        {
            InitializeComponent();
            InitializeVulkan();
            _Bitmap = new Bitmap(640, 480);

            _Framebuffer = new Framebuffer(_Device, 640, 480);

            VkPipelineLayout dummyLayout = _Device.CreatePipelineLayout(VkPipelineLayoutCreateFlag.NONE, null, null);

            _VertexShader = _Device.CreateShaderModule(VkShaderModuleCreateFlag.NONE, System.IO.File.ReadAllBytes("./Shaders/vertexShader.spv"));
            _FramgemtShader = _Device.CreateShaderModule(VkShaderModuleCreateFlag.NONE, System.IO.File.ReadAllBytes("./Shaders/fragmentShader.spv"));


            _GraphicsPipeline = new Pipeline(_Framebuffer, dummyLayout, _VertexShader, "main", _FramgemtShader, "main");

            // Finally we will need a fence for our submission in order to wait on it
            _Fence = _Device.CreateFence(VkFenceCreateFlag.NONE);

            // VkBuffer indexBuffer = _Device.CreateBuffer(0, 3 * sizeof(Int32), VkBufferUsageFlag.VK_BUFFER_USAGE_INDEX_BUFFER, VkSharingMode.VK_SHARING_MODE_CONCURRENT, new VkQueueFamilyProperties[] { _Queue.Family });
            // VkBuffer vertexBuffer = _Device.CreateBuffer(0, 3 * sizeof(float), VkBufferUsageFlag.VK_BUFFER_USAGE_VERTEX_BUFFER, VkSharingMode.VK_SHARING_MODE_CONCURRENT, new VkQueueFamilyProperties[] { _Queue.Family });


            // Now we need to create a command buffer and we will fill it with a single command:
            //   Fill the image with the color (0.1f, 0.75f, 1.0f, 1.0f) which is a Sky blue.
            VkClearValue.VkClearColorValue.Float color = new VkClearValue.VkClearColorValue.Float();
            color.float32[0] = 0.1f; color.float32[1] = 0.75f; color.float32[2] = 1.0f; color.float32[3] = 1.0f;
            VkCommandPool Pool = _Device.CreateCommandPool(VkCommandPoolCreateFlag.NONE, _Queue.Family);

            _CommandBuffer = Pool.AllocateCommandBuffer(VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY);
            _CommandBuffer.Begin(VkCommandBufferUsageFlag.NONE);
            _CommandBuffer.CmdBeginRenderPass(_Framebuffer.RenderPass,
                                              new VkRect2D(0, 0, (uint)640, (uint)480),
                                              _Framebuffer.GetFramebuffer(),
                                              new VkClearValue[] {  color  },
                                              VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);

            _GraphicsPipeline.BindPipeline(_CommandBuffer);
            _CommandBuffer.CmdDraw(3, 1, 0, 0);
            _CommandBuffer.CmdEndRenderPass();
            _CommandBuffer.cmdCopyImageToBuffer(_Framebuffer.FrameBufferColor,
                                                VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                                                _Framebuffer._TransferBuffer,
                                                new VkBufferImageCopy[] 
                                                {
                                                    new VkBufferImageCopy()
                                                    {
                                                        bufferImageHeight = (uint)_Framebuffer.Height,
                                                        bufferOffset = 0,
                                                        bufferRowLength = (uint)_Framebuffer.Width,
                                                        imageExtent = new VkExtent3D() { depth = 1, width = (uint)_Framebuffer.Width, height = (uint)_Framebuffer.Height },
                                                        imageSubresource = new VkImageSubresourceLayers() { aspectMask = VkImageAspectFlag.VK_IMAGE_ASPECT_COLOR_BIT, baseArrayLayer = 0, layerCount = 1, mipLevel = 0  }
                                                    }
                                                });
            _CommandBuffer.End();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Triangle_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Imaging.BitmapData bitmapData = _Bitmap.LockBits(new Rectangle(0, 0, _Bitmap.Width, _Bitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            _Queue.Submit(new VkSubmitInfo[]
                {
                    new VkSubmitInfo()
                    {
                        commandBuffers = new VkCommandBuffer[] { _CommandBuffer }
                    }
                }, _Fence);

            if (_Fence.WaitForFence(1000))
            {
                // If the submission completed we copy the image data into the bitmap data
                _Framebuffer.BlitFramebufferToPointer(_Queue, bitmapData.Scan0);
            }
            else
            {
                this.Invalidate();
            }
            _Bitmap.UnlockBits(bitmapData);
            e.Graphics.DrawImage(_Bitmap, new Rectangle(0, 0, Width, Height));
        }

        private void Triangle_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
