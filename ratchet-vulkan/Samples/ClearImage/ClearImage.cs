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

namespace ClearImage
{
    public partial class ClearImage : Form
    {
        System.Drawing.Bitmap _Bitmap;


        VkImage _Image;
        VkDevice _Device;
        VkInstance _Instance;
        VkQueue _Queue;
        VkCommandBuffer _CommandBuffer;
        VkFence _Fence;
        IntPtr _ImagePtr;

        public ClearImage()
        {
            InitializeComponent();
            _Bitmap = new Bitmap(640, 480);

            // Create the VUlkan instance that we will use for this app
            _Instance = new VkInstance("ClearImage - Sample", 1, "Ratchet", 1);

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

                        // Now it is time to create the image that we will fill wih the solid color
                        _Image = _Device.CreateImage(
                            VkImageCreateFlag.NONE,
                            VkFormat.VK_FORMAT_B8G8R8A8_SRGB,
                            _Bitmap.Width, _Bitmap.Height,
                            1, 1,
                            VkSampleCountFlag.VK_SAMPLE_COUNT_1,
                            VkImageTiling.VK_IMAGE_TILING_LINEAR,
                            VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_SRC | VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_DST,
                            VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                            null,
                            VkImageLayout.VK_IMAGE_LAYOUT_GENERAL);

                        // We will back this image with Host Accessible Memomy so we can map it an copy
                        // the content from the Host.
                        // To do so we need to find the right memory type first.
                        VkMemoryType HostMemory = new VkMemoryType();
                        foreach (VkMemoryType memoryType in _Image.MemoryRequirements.memoryTypes)
                        {
                            // Pick the first memory type that can be mapped into host memory
                            if ((memoryType.propertyFlags & VkMemoryPropertyFlags.VK_MEMORY_PROPERTY_HOST_VISIBLE) != 0)
                            {
                                HostMemory = memoryType;
                                break;
                            }
                        }

                        // Allocate the backing memory for this image
                        VkDeviceMemory Memory = _Device.AllocateMemory(_Image.MemoryRequirements.size, HostMemory);
                        _Image.BindMemory(Memory, 0);
                        // Create the CPU mapping
                        _ImagePtr = Memory.Map(0, _Image.MemoryRequirements.size, VkMemoryMapFlag.NONE);

                        // Now we need to create a command buffer and we will fill it with a single command:
                        //   Fill the image with the color (0.1f, 0.75f, 1.0f, 1.0f) which is a Sky blue.
                        VkCommandPool Pool = _Device.CreateCommandPool(VkCommandPoolCreateFlag.NONE, _Queue.Family);
                        _CommandBuffer = Pool.AllocateCommandBuffer(VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY);
                        _CommandBuffer.Begin(VkCommandBufferUsageFlag.NONE);
                        _CommandBuffer.CmdClearColorImage(
                            _Image,
                            VkImageLayout.VK_IMAGE_LAYOUT_GENERAL,
                            0.1f, 0.75f, 1.0f, 1.0f,
                            new VkImageSubresourceRange[]
                                {
                                    new VkImageSubresourceRange()
                                        {
                                            aspectMask = VkImageAspectFlag.VK_IMAGE_ASPECT_COLOR_BIT,
                                            baseArrayLayer = 0,
                                            baseMipLevel = 0,
                                            layerCount = 1,
                                            levelCount = 1
                                        }
                                });
                        _CommandBuffer.End();

                        // Finally we will need a fence for our submission in order to wait on it
                        _Fence = _Device.CreateFence(VkFenceCreateFlag.NONE);

                        break;
                    }
                }
            }
        }

        private void ClearImage_Load(object sender, EventArgs e)
        {

        }

        unsafe static void Copy(IntPtr Destination, IntPtr Source, int Cb)
        {
            byte* pDst = (byte*)Destination.ToPointer();
            byte* pSrc = (byte*)Source.ToPointer();
            while (Cb > 0) { *pDst++ = *pSrc++; Cb--; }
        }

        private void ClearImage_Paint(object sender, PaintEventArgs e)
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
                Copy(bitmapData.Scan0, _ImagePtr, (int)_Image.MemoryRequirements.size);
            }
            _Bitmap.UnlockBits(bitmapData);
            e.Graphics.DrawImage(_Bitmap, new Rectangle(0, 0, Width, Height));
        }
    }
}
