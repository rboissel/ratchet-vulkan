using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Ratchet.Drawing.Vulkan.VkInstanceCreateInfo InstanceCreateInfo = new Ratchet.Drawing.Vulkan.VkInstanceCreateInfo();
            InstanceCreateInfo.applicationInfo.apiVersion = 0;
            InstanceCreateInfo.applicationInfo.applicationName = "myApp";
            InstanceCreateInfo.applicationInfo.applicationVersion = 1;
            InstanceCreateInfo.applicationInfo.engineName = "Ratchet";
            InstanceCreateInfo.applicationInfo.engineVersion = 1;
            Ratchet.Drawing.Vulkan.VkInstance Instance = new Ratchet.Drawing.Vulkan.VkInstance(ref InstanceCreateInfo);
            Ratchet.Drawing.Vulkan.VkPhysicalDevice physicalDevice = null;
            Ratchet.Drawing.Vulkan.VkQueueFamilyProperties graphicsQueueFamily = new Ratchet.Drawing.Vulkan.VkQueueFamilyProperties();

            foreach (Ratchet.Drawing.Vulkan.VkPhysicalDevice physicalDeviceIt in Instance.vkEnumeratePhysicalDevices())
            {
                foreach (Ratchet.Drawing.Vulkan.VkQueueFamilyProperties QueueFamilyPropertyIt in physicalDeviceIt.QueueFamilies)
                {
                    if ((QueueFamilyPropertyIt.queueFlags & Ratchet.Drawing.Vulkan.VkQueueFlags.VK_QUEUE_GRAPHICS) != 0)
                    {
                        physicalDevice = physicalDeviceIt;
                        graphicsQueueFamily = QueueFamilyPropertyIt;
                        break;
                    }
                }
            }

            Ratchet.Drawing.Vulkan.VkDeviceCreateInfo DeviceCreateInfo = new Ratchet.Drawing.Vulkan.VkDeviceCreateInfo();
            DeviceCreateInfo.queueCreateInfos = new Ratchet.Drawing.Vulkan.VkDeviceQueueCreateInfo[]
            {
                new Ratchet.Drawing.Vulkan.VkDeviceQueueCreateInfo() { queueCount = 0x1, queueFamily = graphicsQueueFamily, queuePriorities = new float[]{ 1.0f } }
            };
            Ratchet.Drawing.Vulkan.VkDevice device = physicalDevice.CreateDevice(ref DeviceCreateInfo);
            
            Ratchet.Drawing.Vulkan.VkCommandPool commandPool = device.CreateCommandPool(Ratchet.Drawing.Vulkan.VkCommandPoolCreateFlag.NONE, ref graphicsQueueFamily);
            Ratchet.Drawing.Vulkan.VkCommandBuffer commandBuffer = commandPool.AllocateCommandBuffer(Ratchet.Drawing.Vulkan.VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY);

            Ratchet.Drawing.Vulkan.VkImage image = device.CreateImage(
                0,
                Ratchet.Drawing.Vulkan.VkFormat.VK_FORMAT_A8B8G8R8_UINT_PACK32,
                256, 256,
                1, 1,
                Ratchet.Drawing.Vulkan.VkSampleCountFlag.VK_SAMPLE_COUNT_1,
                Ratchet.Drawing.Vulkan.VkImageTiling.VK_IMAGE_TILING_LINEAR,
                Ratchet.Drawing.Vulkan.VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_SRC | Ratchet.Drawing.Vulkan.VkImageUsageFlag.VK_IMAGE_USAGE_TRANSFER_DST, Ratchet.Drawing.Vulkan.VkSharingMode.VK_SHARING_MODE_EXCLUSIVE, null, Ratchet.Drawing.Vulkan.VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED);

            Ratchet.Drawing.Vulkan.VkRenderPass renderPass = device.CreateRenderPass(
                new Ratchet.Drawing.Vulkan.VkAttachmentDescription[]
                {
                },
                new Ratchet.Drawing.Vulkan.VkSubpassDescription[]
                {
                },
                new Ratchet.Drawing.Vulkan.VkSubpassDependency[]
                {
                });

            Application.Run(new Form1());
        }
    }
}
