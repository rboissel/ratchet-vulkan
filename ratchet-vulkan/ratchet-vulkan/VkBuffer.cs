using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkBuffer
    {
        internal UInt64 _Handle;
        VkDevice _Parent;
        VkMemoryRequirements _MemoryRequirements;
        public VkMemoryRequirements MemoryRequirements { get { return _MemoryRequirements; } }
        unsafe VkMemoryRequirements GetBufferMemoryRequirements()
        {
            VkMemoryRequirements_Native memoryRequirements_native;
            _Parent.vkGetBufferMemoryRequirements(_Parent._Handle, _Handle, new IntPtr(&memoryRequirements_native));
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

        public VkDevice Device { get { return _Parent; } }

        internal VkBuffer(VkDevice Parent, UInt64 Handle)
        {
            _Handle = Handle;
            _Parent = Parent;
            _MemoryRequirements = GetBufferMemoryRequirements();
        }

        public void BindMemory(VkDeviceMemory memory, UInt64 offset)
        {
            bool validMemory = false;
            for (int n = 0; n < MemoryRequirements.memoryTypes.Length; n++)
            {
                if (MemoryRequirements.memoryTypes[n].index == memory.MemoryType.index) { validMemory = true; break; }
            }
            if (!validMemory) { throw new Exception("The memory block provided for the binding doesn't match the memory requirement"); }
            VkResult result = _Parent.vkBindBufferMemory(_Parent._Handle, _Handle, memory._Handle, offset);
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }
    }
}
