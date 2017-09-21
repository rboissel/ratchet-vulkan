using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkImage
    {
        internal UInt64 _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }
        VkMemoryRequirements _MemoryRequirements;
        public VkMemoryRequirements MemoryRequirements { get { return _MemoryRequirements; } }
        unsafe VkMemoryRequirements GetImageMemoryRequirements()
        {
            VkMemoryRequirements_Native memoryRequirements_native;
            _Parent.vkGetImageMemoryRequirements(_Parent._Handle, _Handle, new IntPtr(&memoryRequirements_native));
            VkMemoryRequirements memoryRequirements;
            memoryRequirements.size = memoryRequirements_native.size;
            memoryRequirements.alignment = memoryRequirements_native.alignment;
            int bitCount = 0;
            for (int n = 0; n < 32; n++) { if ((memoryRequirements_native.memoryTypeBits & (1 << n)) != 0) { bitCount++; } }
            memoryRequirements.memoryTypes = new VkMemoryType[bitCount];
            for (int n = 0, x = 0; n < 32; n++)
            {
                if ((memoryRequirements_native.memoryTypeBits & (1 << n)) != 0)
                {
                    memoryRequirements.memoryTypes[x] = _Parent.PhysicalDevice.Memories.memoryTypes[n];
                    x++;
                }
            }
            return memoryRequirements;
        }

        internal VkImage(UInt64 Handle, VkDevice Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
            _MemoryRequirements = GetImageMemoryRequirements();
        }

        public void BindMemory(VkDeviceMemory memory, UInt64 offset)
        {
            VkResult result = _Parent.vkBindImageMemory(_Parent._Handle, _Handle, memory._Handle, offset);
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }
    }
}
