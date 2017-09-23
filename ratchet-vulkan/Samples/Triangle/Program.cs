using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ratchet.Drawing.Vulkan;

namespace Triangle
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static unsafe void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VkInstanceCreateInfo InstanceCreateInfo = new VkInstanceCreateInfo();
            InstanceCreateInfo.applicationInfo.apiVersion = 0;
            InstanceCreateInfo.applicationInfo.applicationName = "myApp";
            InstanceCreateInfo.applicationInfo.applicationVersion = 1;
            InstanceCreateInfo.applicationInfo.engineName = "Ratchet";
            InstanceCreateInfo.applicationInfo.engineVersion = 1;
            VkInstance Instance = new VkInstance(ref InstanceCreateInfo);
            VkPhysicalDevice physicalDevice = null;
            VkQueueFamilyProperties graphicsQueueFamily = new VkQueueFamilyProperties();

            foreach (VkPhysicalDevice physicalDeviceIt in Instance.vkEnumeratePhysicalDevices())
            {
                foreach (VkQueueFamilyProperties QueueFamilyPropertyIt in physicalDeviceIt.QueueFamilies)
                {
                    if ((QueueFamilyPropertyIt.queueFlags & VkQueueFlags.VK_QUEUE_GRAPHICS) != 0)
                    {
                        physicalDevice = physicalDeviceIt;
                        graphicsQueueFamily = QueueFamilyPropertyIt;
                        break;
                    }
                }
            }

            VkDeviceCreateInfo DeviceCreateInfo = new VkDeviceCreateInfo();
            DeviceCreateInfo.queueCreateInfos = new VkDeviceQueueCreateInfo[]
            {
                new VkDeviceQueueCreateInfo() { queueCount = 0x1, queueFamily = graphicsQueueFamily, queuePriorities = new float[]{ 1.0f } }
            };
            VkDevice device = physicalDevice.CreateDevice(ref DeviceCreateInfo);
            VkMemoryType hostMemory = new VkMemoryType();
            for (int n = 0; n < device.PhysicalDevice.Memories.memoryTypes.Length; n++)
            {
                if ((device.PhysicalDevice.Memories.memoryTypes[n].propertyFlags & VkMemoryPropertyFlags.VK_MEMORY_PROPERTY_HOST_VISIBLE) != 0)
                { hostMemory = device.PhysicalDevice.Memories.memoryTypes[n];  }
            }


            VkCommandPool commandPool = device.CreateCommandPool(VkCommandPoolCreateFlag.NONE, ref graphicsQueueFamily);
            VkCommandBuffer commandBuffer = commandPool.AllocateCommandBuffer(VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY);
            commandBuffer.Begin(VkCommandBufferUsageFlag.NONE);
            VkImage image = device.CreateImage(
                0,
                VkFormat.VK_FORMAT_A8B8G8R8_UINT_PACK32,
                256, 256,
                1, 1,
                VkSampleCountFlag.VK_SAMPLE_COUNT_1,
                VkImageTiling.VK_IMAGE_TILING_LINEAR,
                VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_SRC | VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_DST, VkSharingMode.VK_SHARING_MODE_EXCLUSIVE, null, VkImageLayout.VK_IMAGE_LAYOUT_GENERAL);
            VkDeviceMemory memoryBlock = device.AllocateMemory(image.MemoryRequirements.size, ref hostMemory);
            image.BindMemory(memoryBlock, 0);

            VkRenderPass renderPass = device.CreateRenderPass(
            new VkAttachmentDescription[]
            {
                new VkAttachmentDescription()
                {
                    samples = VkSampleCountFlag.VK_SAMPLE_COUNT_1,
                    loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR,
                    storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE,
                    stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE,
                    stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
                    format = VkFormat.VK_FORMAT_A8B8G8R8_UINT_PACK32,
                    initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                    finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                }
            },
            new VkSubpassDescription[]
            {
                new VkSubpassDescription()
                {
                    pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS,
                    colorAttachments = new VkAttachmentReference[] { new VkAttachmentReference() { attachment = 0, layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL  } }
                }
            }, null);

            VkImageView imageView = device.CreateImageView(image, VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, VkFormat.VK_FORMAT_A8B8G8R8_UINT_PACK32, new VkComponentMapping() { a = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY, b = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY, g = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY, r = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY }, new VkImageSubresourceRange() { levelCount = 1, layerCount = 1, baseMipLevel = 0, baseArrayLayer = 0, aspectMask = VkImageAspectFlag.VK_IMAGE_ASPECT_COLOR_BIT });
            VkFramebuffer frameBuffer = device.CreateFramebuffer(renderPass, new VkImageView[] { imageView }, 256, 256, 1);
            //commandBuffer.CmdClearColorImage(image, VkImageLayout.VK_IMAGE_LAYOUT_GENERAL, 1.0f, 1.0f, 0.0f, 1.0f, new VkImageSubresourceRange[] { new VkImageSubresourceRange() { aspectMask = VkImageAspectFlag.VK_IMAGE_ASPECT_COLOR_BIT, baseArrayLayer = 0, baseMipLevel = 0, layerCount = 1, levelCount = 1 } });
            commandBuffer.CmdBeginRenderPass(renderPass, new VkRect2D(0, 0, 256, 256), frameBuffer, new VkClearValue[] { new VkClearValue.VkClearColorValue.Float() {  float32 = new float[] { 1.0f, 0.0f, 0.0f, 1.0f } } }, VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);
            commandBuffer.CmdEndRenderPass();
            commandBuffer.End();

            VkFence fence = device.CreateFence(0);
            VkSemaphore semaphore = device.CreateSemaphore();
            device.Queues[0].Submit(new VkSubmitInfo[] { new VkSubmitInfo()
            {
                commandBuffers = new VkCommandBuffer[] { commandBuffer },
                signalSemaphores = new VkSemaphore[] { semaphore }
            } },
            fence
            );
            fence.WaitForFence(100000000000);

            IntPtr map = memoryBlock.Map(0, image.MemoryRequirements.size, VkMemoryMapFlag.NONE);

            Application.Run(new Form1());
        }
    }
}
