using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    struct VkSubmitInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public UInt32 waitSemaphoreCount;
        public IntPtr pWaitSemaphores;
        public IntPtr pWaitDstStageMask;
        public UInt32 commandBufferCount;
        public IntPtr pCommandBuffers;
        public UInt32 signalSemaphoreCount;
        public IntPtr pSignalSemaphores;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkSubmitInfo
    {
        public VkSemaphore[] waitSemaphores;
        public VkPipelineStageFlag[] waitDstStageMask;
        public VkCommandBuffer[] commandBuffers;
        public VkSemaphore[] signalSemaphores;
    }
}
