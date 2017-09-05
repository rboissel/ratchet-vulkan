using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    public unsafe delegate IntPtr PFN_vkAllocationFunction(IntPtr pUserData, IntPtr size, IntPtr alignment, VkSystemAllocationScope allocationScope);
    public unsafe delegate IntPtr PFN_vkReallocationFunction(IntPtr pUserData, IntPtr pOriginal, IntPtr size, IntPtr alignment, VkSystemAllocationScope allocationScope);
    public unsafe delegate void PFN_vkFreeFunction(IntPtr pUserData, IntPtr pMemory);
    public unsafe delegate void PFN_vkInternalAllocationNotification(IntPtr pUserData, IntPtr size, VkInternalAllocationType allocationType, VkSystemAllocationScope allocationScope);
    public unsafe delegate void PFN_vkInternalFreeNotification(IntPtr pUserData, IntPtr size, VkInternalAllocationType allocationType, VkSystemAllocationScope allocationScope);

    [StructLayout(LayoutKind.Sequential)]
    public struct VkAllocationCallbacks
    {
        public IntPtr pUserData;
        public PFN_vkAllocationFunction pfnAllocation;
        public PFN_vkReallocationFunction pfnReallocation;
        public PFN_vkFreeFunction pfnFree;
        public PFN_vkInternalAllocationNotification pfnInternalAllocation;
        public PFN_vkInternalFreeNotification pfnInternalFree;
    }
}
