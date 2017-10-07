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
        VkFormat _Format;

        public VkDevice Device { get { return _Parent; } }
        public VkFormat Format { get { return _Format; } }
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

        internal VkImage(UInt64 Handle, VkDevice Parent, VkFormat Format)
        {
            _Parent = Parent;
            _Handle = Handle;
            _MemoryRequirements = GetImageMemoryRequirements();
            _Format = Format;
        }

        public void BindMemory(VkDeviceMemory memory, UInt64 offset)
        {
            VkResult result = _Parent.vkBindImageMemory(_Parent._Handle, _Handle, memory._Handle, offset);
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }

        public VkImageView CreateImageView(VkImageViewType viewType, VkFormat format, VkComponentMapping componentMapping, VkImageSubresourceRange subressourceRange)
        {
            return _Parent.CreateImageView(this, viewType, format, componentMapping, subressourceRange);
        }


        public VkImageView CreateImageView(VkImageViewType viewType, VkComponentMapping componentMapping, VkImageSubresourceRange subressourceRange)
        {
            return _Parent.CreateImageView(this, viewType, _Format, componentMapping, subressourceRange);
        }

        public VkImageView CreateImageView(VkImageViewType viewType, VkImageSubresourceRange subressourceRange)
        {
            return _Parent.CreateImageView(this, viewType, _Format, new VkComponentMapping(VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY, VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY, VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY, VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY), subressourceRange);
        }
    }
}
