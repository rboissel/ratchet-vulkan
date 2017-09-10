using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    static class Allocator
    {
        static IntPtr Allocation(IntPtr pUserData, IntPtr size, IntPtr alignment, VkSystemAllocationScope allocationScope)
        {
            IntPtr result = System.Runtime.InteropServices.Marshal.AllocHGlobal(size);
            if (result.ToInt64() % alignment.ToInt64() != 0)
            {
                throw new Exception("Fatal allocation error");
            }
            return result;
        }

        static IntPtr Reallocation(IntPtr pUserData, IntPtr pOriginal, IntPtr size, IntPtr alignment, VkSystemAllocationScope allocationScope)
        {
            return System.Runtime.InteropServices.Marshal.ReAllocHGlobal(pOriginal, size);
        }

        static void Free(IntPtr pUserData, IntPtr pMemory)
        {
            System.Runtime.InteropServices.Marshal.FreeHGlobal(pMemory);
        }

        static void InternalAllocation (IntPtr pUserData, IntPtr size, Ratchet.Drawing.Vulkan.VkInternalAllocationType allocationType, Ratchet.Drawing.Vulkan.VkSystemAllocationScope allocationScope)
        {
        }

        static void InternalFree(IntPtr pUserData, IntPtr size, Ratchet.Drawing.Vulkan.VkInternalAllocationType allocationType, Ratchet.Drawing.Vulkan.VkSystemAllocationScope allocationScope)
        {
        }

        public static VkAllocationCallbacks getAllocatorCallbacks()
        {
            VkAllocationCallbacks callbacks = new VkAllocationCallbacks();
            callbacks.pfnAllocation = Allocation;
            callbacks.pfnReallocation = Reallocation;
            callbacks.pfnFree = Free;
            callbacks.pfnInternalAllocation = InternalAllocation;
            callbacks.pfnInternalFree = InternalFree;

            return callbacks;
        }
    }
}
