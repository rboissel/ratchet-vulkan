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


            Ratchet.Drawing.Vulkan.VkPhysicalDevice[] PhysicalDevices = Instance.vkEnumeratePhysicalDevices();

            Ratchet.Drawing.Vulkan.VkDeviceCreateInfo DeviceCreateInfo = new Ratchet.Drawing.Vulkan.VkDeviceCreateInfo();
            DeviceCreateInfo.queueCreateInfos = new Ratchet.Drawing.Vulkan.VkDeviceQueueCreateInfo[]
            {
                new Ratchet.Drawing.Vulkan.VkDeviceQueueCreateInfo() { queueCount = 0x11, queueFamily = PhysicalDevices[0].QueueFamilies[1], queuePriorities = new float[]{ 0.0f } }
            };
            Ratchet.Drawing.Vulkan.VkDevice Device = PhysicalDevices[0].CreateDevice(ref DeviceCreateInfo);
            
            Ratchet.Drawing.Vulkan.VkCommandPool commandPool = Device.CreateCommandPool(Ratchet.Drawing.Vulkan.VkCommandPoolCreateFlag.NONE, ref Device.PhysicalDevice.QueueFamilies[1]);
            commandPool.AllocateCommandBuffers(Ratchet.Drawing.Vulkan.VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY, 1);
            Application.Run(new Form1());
        }
    }
}
