using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkCommandPool
    {
        internal UInt64 _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }

        internal VkCommandPool(UInt64 Handle, VkDevice Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
        }

        public unsafe VkCommandBuffer[] AllocateCommandBuffers(ref VkCommandBufferAllocateInfo commandBufferAllocateInfo)
        {
            IntPtr[] commandBufferHandles = new IntPtr[commandBufferAllocateInfo.commandBufferCount];
            VkCommandBuffer[] commandBuffers = new VkCommandBuffer[commandBufferAllocateInfo.commandBufferCount];

            VkCommandBufferAllocateInfo_Native commandBufferAllocateInfo_Native = new VkCommandBufferAllocateInfo_Native();
            commandBufferAllocateInfo_Native.pNext = new IntPtr(0);
            commandBufferAllocateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO;
            commandBufferAllocateInfo_Native.commandPoolHandle = _Handle;
            commandBufferAllocateInfo_Native.level = commandBufferAllocateInfo.level;
            commandBufferAllocateInfo_Native.commandBufferCount = commandBufferAllocateInfo.commandBufferCount;
            VkResult result = VkResult.VK_SUCCESS;
            fixed (IntPtr* pCommandBufferHandles = &commandBufferHandles[0])
            {
                result = _Parent.vkAllocateCommandBuffers(_Parent._Handle, new IntPtr(&commandBufferAllocateInfo_Native), new IntPtr(pCommandBufferHandles));
            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            for (int n = 0; n< commandBuffers.Length; n++)
            {
                commandBuffers[n] = new VkCommandBuffer(commandBufferHandles[n], this);
            }

            return commandBuffers;
        }

        public VkCommandBuffer[] AllocateCommandBuffers(VkCommandBufferLevel level, UInt32 commandBufferCount)
        {
            VkCommandBufferAllocateInfo commandBufferAllocateInfo = new VkCommandBufferAllocateInfo();
            commandBufferAllocateInfo.commandBufferCount = commandBufferCount;
            commandBufferAllocateInfo.level = level;
            return AllocateCommandBuffers(ref commandBufferAllocateInfo);
        }


        public VkCommandBuffer AllocateCommandBuffer(VkCommandBufferLevel level) { return AllocateCommandBuffers(level, 1)[0]; }
    }
}
