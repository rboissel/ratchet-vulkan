using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkDevice
    {
        internal IntPtr _Handle;
        VkPhysicalDevice _PhysicalDevice;
        public VkPhysicalDevice PhysicalDevice { get { return _PhysicalDevice; } }

        internal VkQueue[] _Queues;
        public VkQueue[] Queues { get { return _Queues; } }

        internal delegate VkResult vkAllocateMemory_func(IntPtr deviceHandle, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pMemoryHandle);
        internal vkAllocateMemory_func vkAllocateMemory;
        internal delegate VkResult vkAllocateCommandBuffers_func(IntPtr deviceHandle, IntPtr pAllocateInfo, IntPtr pCommandBufferHandles);
        internal vkAllocateCommandBuffers_func vkAllocateCommandBuffers;
        internal delegate VkResult vkCreateCommandPool_func(IntPtr deviceHandle, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pCommandPoolHandle);
        internal vkCreateCommandPool_func vkCreateCommandPool;
        internal delegate VkResult vkCreateFence_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFenceHandle);
        internal vkCreateFence_func vkCreateFence;
        internal delegate VkResult vkCreateRenderPass_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pRenderPassHandle);
        internal vkCreateRenderPass_func vkCreateRenderPass;
        internal delegate VkResult vkCreateSemaphore_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pSemaphoreHandle);
        internal vkCreateSemaphore_func vkCreateSemaphore;
        internal delegate VkResult vkGetFenceStatus_func(IntPtr deviceHandle, UInt64 fenceHandle);
        internal vkGetFenceStatus_func vkGetFenceStatus;
        internal delegate VkResult vkWaitForFences_func(IntPtr device, UInt32 fenceCount, IntPtr pFences, bool waitAll, UInt64 timeout);
        internal vkWaitForFences_func vkWaitForFences;
        internal delegate void vkGetDeviceQueue_func(IntPtr device, UInt32 queueFamilyIndex, UInt32 queueIndex, ref IntPtr pQueue);
        internal vkGetDeviceQueue_func vkGetDeviceQueue;


        internal VkDevice(VkPhysicalDevice PhysicalDevice, IntPtr Handle, VkDeviceQueueCreateInfo[] queueCreateInfo)
        {
            _PhysicalDevice = PhysicalDevice;
            _Handle = Handle;
            vkAllocateMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkAllocateMemory_func>("vkAllocateMemory");
            vkAllocateCommandBuffers = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkAllocateCommandBuffers_func>("vkAllocateCommandBuffers");
            vkCreateCommandPool = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateCommandPool_func>("vkCreateCommandPool");
            vkCreateFence = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateFence_func>("vkCreateFence");
            vkCreateRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateRenderPass_func>("vkCreateRenderPass");
            vkCreateSemaphore = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateSemaphore_func>("vkCreateSemaphore");
            vkGetFenceStatus = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetFenceStatus_func>("vkGetFenceStatus");
            vkGetDeviceQueue = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetDeviceQueue_func>("vkGetDeviceQueue");
            vkWaitForFences = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkWaitForFences_func>("vkWaitForFences");

            List<VkQueue> queues = new List<VkQueue>();
            for (int n = 0; n< queueCreateInfo.Length; n++)
            {
                for (int x = 0; x < queueCreateInfo[n].queueCount; x++)
                {
                    IntPtr handle = new IntPtr(0);
                    vkGetDeviceQueue(_Handle, queueCreateInfo[n].queueFamily.index, (UInt32)x, ref handle);
                    VkQueue queue = new VkQueue(handle, this, queueCreateInfo[n].queueFamily);
                    queues.Add(queue);
                }
            }
            _Queues = queues.ToArray();
        }

        public unsafe VkDeviceMemory AllocateMemory(ref VkMemoryAllocateInfo allocateInfo)
        {
            if (vkAllocateMemory != null)
            {
                VkDeviceMemory deviceMemory = new VkDeviceMemory();
                VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                VkMemoryAllocateInfo_Native allocateInfo_native = new VkMemoryAllocateInfo_Native();
                allocateInfo_native.allocationSize = allocateInfo.allocationSize;
                allocateInfo_native.memoryTypeIndex = allocateInfo.memoryTypeIndex;
                allocateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO;
                allocateInfo_native.pNext = new IntPtr(0);
                VkResult result = vkAllocateMemory(_Handle, new IntPtr(&allocateInfo_native), ref allocator, new IntPtr(&deviceMemory.Handle));
                if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

                return deviceMemory;
            }
            else { throw new NotImplementedException(); }
        }

        public VkDeviceMemory AllocateMemory(ulong allocationSize, uint memoryTypeIndex)
        {
            VkMemoryAllocateInfo allocateInfo = new VkMemoryAllocateInfo();
            allocateInfo.allocationSize = allocationSize;
            allocateInfo.memoryTypeIndex = memoryTypeIndex;
            return AllocateMemory(ref allocateInfo);
        }

        public unsafe VkCommandPool CreateCommandPool(ref VkCommandPoolCreateInfo commandPoolCreateInfo)
        {
            UInt64 commandPoolHandle = 0;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
            VkCommandPoolCreateInfo_Native commandPoolCreateInfo_native = new VkCommandPoolCreateInfo_Native();
            commandPoolCreateInfo_native.flags = commandPoolCreateInfo.flags;
            commandPoolCreateInfo_native.queueFamilyIndex = commandPoolCreateInfo.queueFamilyIndex;
            commandPoolCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO;
            commandPoolCreateInfo_native.pNext = new IntPtr(0);

            VkResult result = vkCreateCommandPool(_Handle, new IntPtr(&commandPoolCreateInfo_native), ref allocator, new IntPtr(&commandPoolHandle));
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            VkCommandPool VkCommandPool = new VkCommandPool(commandPoolHandle, this);
            return VkCommandPool;
        }

        public VkCommandPool CreateCommandPool(VkCommandPoolCreateFlag flags, ref VkQueueFamilyProperties queueFamily)
        {
            if (_PhysicalDevice != queueFamily.physicalDevice) { throw new Exception("This queue family doesn't belong to the physical device used to create this device"); }
            VkCommandPoolCreateInfo commandPoolCreateInfo = new VkCommandPoolCreateInfo();
            commandPoolCreateInfo.flags = flags;
            commandPoolCreateInfo.queueFamilyIndex = queueFamily.index;
            return CreateCommandPool(ref commandPoolCreateInfo);
        }

        public unsafe VkFence CreateFence(ref VkFenceCreateInfo fenceCreateInfo)
        {
            UInt64 fenceHandle = 0;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
            VkFenceCreateInfo_Native fenceCreateInfo_native = new VkFenceCreateInfo_Native();
            fenceCreateInfo_native.flags = fenceCreateInfo.flags;
            fenceCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO;
            fenceCreateInfo_native.pNext = new IntPtr(0);

            VkResult result = vkCreateFence(_Handle, new IntPtr(&fenceCreateInfo_native), ref allocator, new IntPtr(&fenceHandle));
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            VkFence VkFence = new VkFence(this, fenceHandle);
            return VkFence;
        }

        public VkFence CreateFence(VkFenceCreateFlag flags)
        {
            VkFenceCreateInfo fenceCreateInfo = new VkFenceCreateInfo();
            fenceCreateInfo.flags = flags;
            return CreateFence(ref fenceCreateInfo);
        }

        public unsafe VkSemaphore CreateSemaphore(ref VkSemaphoreCreateInfo semaphoreCreateInfo)
        {
            UInt64 semaphoreHandle = 0;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
            VkSemaphoreCreateInfo_Native semaphoreCreateInfo_native = new VkSemaphoreCreateInfo_Native();
            semaphoreCreateInfo_native.flags = semaphoreCreateInfo.flags;
            semaphoreCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO;
            semaphoreCreateInfo_native.pNext = new IntPtr(0);

            VkResult result = vkCreateSemaphore(_Handle, new IntPtr(&semaphoreCreateInfo_native), ref allocator, new IntPtr(&semaphoreHandle));
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            VkSemaphore semaphore = new VkSemaphore(this, semaphoreHandle);
            return semaphore;
        }

        public VkSemaphore CreateSemaphore()
        {
            VkSemaphoreCreateInfo VkSemaphoreCreateInfo = new VkSemaphoreCreateInfo();
            return CreateSemaphore(ref VkSemaphoreCreateInfo);
        }

        public unsafe VkRenderPass CreateRenderPass(ref VkRenderPassCreateInfo renderPassCreateInfo)
        {
            for (int n = 0; n < renderPassCreateInfo.subpasses.Length; n++)
            {
                if (renderPassCreateInfo.subpasses[n].colorAttachments == null) { throw new Exception("Color attachment cannot be null"); }
                if (renderPassCreateInfo.subpasses[n].resolveAttachments != null && renderPassCreateInfo.subpasses[n].resolveAttachments.Length != renderPassCreateInfo.subpasses[n].colorAttachments.Length) { throw new Exception("Resolve Attachment must either be null or have the same length as Color Attachments"); }
            }

            UInt64 renderPassHandle =  0;
            VkRenderPassCreateInfo_Native renderPassCreateInfo_Native = new VkRenderPassCreateInfo_Native();
            renderPassCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
            renderPassCreateInfo_Native.pNext = new IntPtr(0);

            VkSubpassDependency[] dependencies = renderPassCreateInfo.dependencies;
            if (dependencies == null) { dependencies = new VkSubpassDependency[0]; }
            VkAttachmentDescription[] attachments = renderPassCreateInfo.attachments;
            if (attachments == null) { attachments = new VkAttachmentDescription[0]; }


            VkSubpassDescription[] subpasses = renderPassCreateInfo.subpasses;
            if (subpasses == null) { subpasses = new VkSubpassDescription[0]; }

            VkSubpassDescription_Native[] subpasses_native = new VkSubpassDescription_Native[subpasses.Length];
            for (int n = 0; n < subpasses.Length; n++)
            {
                subpasses_native[n].pipelineBindPoint = subpasses[n].pipelineBindPoint;

                subpasses_native[n].colorAttachmentCount = (UInt32)subpasses[n].colorAttachments.Length;
                subpasses_native[n].inputAttachmentCount = (UInt32)subpasses[n].inputAttachments.Length;

                subpasses_native[n].pColorAttachments = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkAttachmentReference) * subpasses_native[n].colorAttachmentCount));
                for (int x = 0; x < subpasses_native[n].colorAttachmentCount; x++)
                {
                    ((VkAttachmentReference*)subpasses_native[n].pColorAttachments.ToPointer())[x] = subpasses[n].colorAttachments[x];
                }
                subpasses_native[n].pInputAttachments = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkAttachmentReference) * subpasses_native[n].inputAttachmentCount));
                for (int x = 0; x < subpasses_native[n].inputAttachmentCount; x++)
                {
                    ((VkAttachmentReference*)subpasses_native[n].pInputAttachments.ToPointer())[x] = subpasses[n].inputAttachments[x];
                }

                if (subpasses[n].depthStencilAttachment == null) { subpasses_native[n].pDepthStencilAttachment = new IntPtr(0); }
                else
                {
                    subpasses_native[n].pDepthStencilAttachment = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkAttachmentReference)));
                    *(VkAttachmentReference*)subpasses_native[n].pDepthStencilAttachment.ToPointer() = subpasses[n].depthStencilAttachment.Value;
                }

                if (subpasses[n].resolveAttachments == null || subpasses[n].resolveAttachments.Length == 0) { subpasses_native[n].pResolveAttachments = new IntPtr(0); }
                else
                {
                    subpasses_native[n].pResolveAttachments = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkAttachmentReference) * subpasses_native[n].colorAttachmentCount));
                    for (int x = 0; x < subpasses_native[n].colorAttachmentCount; x++)
                    {
                        ((VkAttachmentReference*)subpasses_native[n].pResolveAttachments.ToPointer())[x] = subpasses[n].resolveAttachments[x];
                    }
                }
                if (subpasses[n].preserveAttachments == null || subpasses[n].preserveAttachments.Length == 0)
                {
                    subpasses_native[n].preserveAttachmentCount = 0;
                    subpasses_native[n].pPreserveAttachments = new IntPtr(0);
                }
                else
                {
                    subpasses_native[n].pPreserveAttachments = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(UInt32) * subpasses_native[n].preserveAttachmentCount));
                    for (int x = 0; x < subpasses_native[n].preserveAttachmentCount; x++)
                    {
                        ((UInt32*)subpasses_native[n].pResolveAttachments.ToPointer())[x] = subpasses[n].preserveAttachments[x];
                    }
                }


            }

            renderPassCreateInfo_Native.flags = VkRenderPassCreateFlags.NONE;

            renderPassCreateInfo_Native.subpassCount = (UInt32)subpasses.Length;
            renderPassCreateInfo_Native.attachmentCount = (UInt32)attachments.Length;
            renderPassCreateInfo_Native.dependencyCount = (UInt32)dependencies.Length;

            VkResult result = VkResult.VK_SUCCESS;

            fixed (VkSubpassDependency* pDependecies = &dependencies[0])
            {
                fixed (VkAttachmentDescription* pAttachment = &attachments[0])
                {
                    fixed (VkSubpassDescription_Native* pSubpasses = &subpasses_native[0])
                    {
                        renderPassCreateInfo_Native.pAttachments = new IntPtr(pAttachment);
                        renderPassCreateInfo_Native.pDependencies = new IntPtr(pDependecies);
                        renderPassCreateInfo_Native.pSubpasses = new IntPtr(pSubpasses);
                        VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                        result = vkCreateRenderPass(_Handle, new IntPtr(&renderPassCreateInfo_Native), ref allocator, new IntPtr(&renderPassHandle));
                    }
                }
            }

            for (int n = 0; n < subpasses.Length; n++)
            {
                if (subpasses_native[n].pColorAttachments.ToInt64() != 0) { System.Runtime.InteropServices.Marshal.FreeHGlobal(subpasses_native[n].pColorAttachments); }
                if (subpasses_native[n].pInputAttachments.ToInt64() != 0) { System.Runtime.InteropServices.Marshal.FreeHGlobal(subpasses_native[n].pInputAttachments); }
                if (subpasses_native[n].pDepthStencilAttachment.ToInt64() != 0) { System.Runtime.InteropServices.Marshal.FreeHGlobal(subpasses_native[n].pDepthStencilAttachment); }
                if (subpasses_native[n].pPreserveAttachments.ToInt64() != 0) { System.Runtime.InteropServices.Marshal.FreeHGlobal(subpasses_native[n].pPreserveAttachments); }
                if (subpasses_native[n].pResolveAttachments.ToInt64() != 0) { System.Runtime.InteropServices.Marshal.FreeHGlobal(subpasses_native[n].pResolveAttachments); }
            }


            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            return new VkRenderPass(renderPassHandle, this);
        }

        public VkRenderPass CreateRenderPass(VkAttachmentDescription[] attachments, VkSubpassDescription[] subpasses, VkSubpassDependency[] dependencies)
        {
            VkRenderPassCreateInfo renderPassCreateInfo = new VkRenderPassCreateInfo();
            renderPassCreateInfo.attachments = attachments;
            renderPassCreateInfo.subpasses = subpasses;
            renderPassCreateInfo.dependencies = dependencies;
            return CreateRenderPass(ref renderPassCreateInfo);
        }

        public unsafe bool WaitForFences(VkFence[] fences, bool waitAll, UInt64 timeout)
        {
            UInt64[] fencesHandles = new UInt64[fences.Length];
            for (int n = 0; n < fences.Length; n++) { fencesHandles[n] = fences[n]._Handle; }
            VkResult result = VkResult.VK_SUCCESS;
            fixed (UInt64* pfencesHandles = &fencesHandles[0])
            {
                result = vkWaitForFences(_Handle, (UInt32)fences.Length, new IntPtr(pfencesHandles), waitAll, timeout);
            }
            if (result == VkResult.VK_SUCCESS) { return true; }
            else if (result == VkResult.VK_TIMEOUT) { return false; }
            throw new Exception(result.ToString());
        }
    }
}
