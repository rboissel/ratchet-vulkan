using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkQueue
    {
        internal IntPtr _Handle;
        VkDevice _Parent;
        VkQueueFamilyProperties _QueueFamily;

        public VkDevice Device { get { return _Parent; } }
        public VkQueueFamilyProperties Family { get { return _QueueFamily; } }


        internal VkQueue(IntPtr Handle, VkDevice Parent, VkQueueFamilyProperties QueueFamily)
        {
            _Parent = Parent;
            _Handle = Handle;
            _QueueFamily = QueueFamily;
        }

        public unsafe void WaitIdle()
        {
            VkResult  result = _Parent.vkQueueWaitIdle(_Handle);
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }

        public unsafe void Submit(VkSubmitInfo[] submitInfo, VkFence Fence)
        {
            if (submitInfo == null || submitInfo.Length == 0) { return; }
            for (int n = 0; n < submitInfo.Length; n++)
            {
                int waitSemaphoreCount = submitInfo[n].waitSemaphores == null ? 0 : submitInfo[n].waitSemaphores.Length;
                int waitDstStageMaskCount = submitInfo[n].waitDstStageMask == null ? 0 : submitInfo[n].waitDstStageMask.Length;
                if (waitSemaphoreCount != waitDstStageMaskCount) { throw new Exception("There must be the same number of semaphore in waitSemaphores than the number of PipelineStageFlag in waitDstStageMask"); }
            }

            VkSubmitInfo_Native[] submitInfo_Native = new VkSubmitInfo_Native[submitInfo.Length];
            for (int n = 0; n < submitInfo.Length; n++)
            {
                submitInfo_Native[n].pNext = new IntPtr(0);
                submitInfo_Native[n].sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO;
                submitInfo_Native[n].commandBufferCount = submitInfo[n].commandBuffers == null ? (uint)0 : (uint)submitInfo[n].commandBuffers.Length;
                submitInfo_Native[n].signalSemaphoreCount = submitInfo[n].signalSemaphores == null ? (uint)0 : (uint)submitInfo[n].signalSemaphores.Length;
                submitInfo_Native[n].waitSemaphoreCount = submitInfo[n].waitSemaphores == null ? (uint)0 : (uint)submitInfo[n].waitSemaphores.Length;
                submitInfo_Native[n].pCommandBuffers = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(submitInfo_Native[n].commandBufferCount * sizeof(void*)));
                // Ok this is extremely bad for perf. Especially because it will be called often.
                // Ultimatly we need speciallized method to do that quickly
                for (int x = 0; x < submitInfo_Native[n].commandBufferCount; x++)
                { ((IntPtr*)submitInfo_Native[n].pCommandBuffers)[x] = submitInfo[n].commandBuffers[x]._Handle; }
                submitInfo_Native[n].pWaitSemaphores = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(submitInfo_Native[n].waitSemaphoreCount * sizeof(UInt64)));
                submitInfo_Native[n].pWaitDstStageMask = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(submitInfo_Native[n].waitSemaphoreCount * sizeof(VkPipelineStageFlag)));
                for (int x = 0; x < submitInfo_Native[n].waitSemaphoreCount; x++)
                {
                    ((UInt64*)submitInfo_Native[n].pWaitSemaphores)[x] = submitInfo[n].waitSemaphores[x]._Handle;
                    ((VkPipelineStageFlag*)submitInfo_Native[n].pWaitDstStageMask)[x] = submitInfo[n].waitDstStageMask[x];
                }
                submitInfo_Native[n].pSignalSemaphores = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(submitInfo_Native[n].signalSemaphoreCount * sizeof(UInt64)));
                for (int x = 0; x < submitInfo_Native[n].signalSemaphoreCount; x++)
                { ((UInt64*)submitInfo_Native[n].pSignalSemaphores)[x] = submitInfo[n].signalSemaphores[x]._Handle; }
            }

            VkResult result = VkResult.VK_SUCCESS;
            fixed (VkSubmitInfo_Native* pSubmitInfo = &submitInfo_Native[0])
            {
                result = _Parent.vkQueueSubmit(_Handle, (uint)submitInfo_Native.Length, new IntPtr(pSubmitInfo), Fence._Handle);
            }

            for (int n = 0; n < submitInfo.Length; n++)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(submitInfo_Native[n].pWaitDstStageMask);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(submitInfo_Native[n].pWaitSemaphores);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(submitInfo_Native[n].pCommandBuffers);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(submitInfo_Native[n].pSignalSemaphores);
            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }
    }
}
