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
        VkStructureType sType;
        IntPtr pNext;
        UInt32 waitSemaphoreCount;
        IntPtr pWaitSemaphores;
        IntPtr pWaitDstStageMask;
        UInt32 commandBufferCount;
        IntPtr pCommandBuffers;
        UInt32 signalSemaphoreCount;
        IntPtr pSignalSemaphores;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VkSubmitInfo
    {
        VkSemaphore[] waitSemaphores;
        VkPipelineStageFlag[] waitDstStageMask;
        VkCommandBuffer[] commandBuffers;
        VkSemaphore[] signalSemaphores;
    }
}
