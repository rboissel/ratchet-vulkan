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
        internal delegate VkResult vkBeginCommandBuffer_func(IntPtr commandBufferHandle, IntPtr pBeginInfo);
        internal vkBeginCommandBuffer_func vkBeginCommandBuffer;
        internal delegate VkResult vkBindImageMemory_func(IntPtr deviceHandle, UInt64 imageHandle, UInt64 memoryHandle, UInt64 memoryOffset);
        internal vkBindImageMemory_func vkBindImageMemory;
        internal delegate VkResult vkBindBufferMemory_func(IntPtr deviceHandle, UInt64 bufferHandle, UInt64 memoryHandle, UInt64 memoryOffset);
        internal vkBindBufferMemory_func vkBindBufferMemory;
        internal delegate VkResult vkCmdBindVertexBuffers_func(IntPtr commandBuffer, UInt32 firstBinding, UInt32 bindingCount, IntPtr pBuffers, IntPtr pOffsets);
        internal vkCmdBindVertexBuffers_func vkCmdBindVertexBuffers;

        internal delegate VkResult vkCmdClearColorImage_Float_func(IntPtr commandBuffer, UInt64 image, VkImageLayout imageLayout, ref VkClearValue.VkClearColorValue.Float_s pColor, UInt32 rangeCount, IntPtr pRanges);
        internal vkCmdClearColorImage_Float_func vkCmdClearColorImage_Float;
        internal delegate VkResult vkCmdClearColorImage_Int32_func(IntPtr commandBuffer, UInt64 image, VkImageLayout imageLayout, ref VkClearValue.VkClearColorValue.Int32_t_s pColor, UInt32 rangeCount, IntPtr pRanges);
        internal vkCmdClearColorImage_Int32_func vkCmdClearColorImage_Int32;
        internal delegate VkResult vkCmdClearColorImage_UInt32_func(IntPtr commandBuffer, UInt64 image, VkImageLayout imageLayout, ref VkClearValue.VkClearColorValue.UInt32_t_s pColor, UInt32 rangeCount, IntPtr pRanges);
        internal vkCmdClearColorImage_UInt32_func vkCmdClearColorImage_UInt32;
        internal delegate VkResult vkCmdCopyImageToBuffer_func(IntPtr commandBuffer, UInt64 srcImage, VkImageLayout imageLayout, UInt64 dstBuffer, UInt32 regionCount, IntPtr pRegions);
        internal vkCmdCopyImageToBuffer_func vkCmdCopyImageToBuffer;
        internal delegate void vkCmdBeginRenderPass_func(IntPtr commandBuffer, IntPtr pRenderPassBegin, VkSubpassContents contents);
        internal vkCmdBeginRenderPass_func vkCmdBeginRenderPass;
        internal delegate void vkCmdBindPipeline_func(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, UInt64 pipeline);
        internal vkCmdBindPipeline_func vkCmdBindPipeline;
        internal delegate void vkCmdEndRenderPass_func(IntPtr commandBuffer);
        internal vkCmdEndRenderPass_func vkCmdEndRenderPass;
        internal delegate void vkCmdDraw_func(IntPtr commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);
        internal vkCmdDraw_func vkCmdDraw;
        internal delegate void vkCmdSetViewport_func(IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, IntPtr pViewports);
        internal vkCmdSetViewport_func vkCmdSetViewport;
        internal delegate VkResult vkCreateBuffer_func(IntPtr deviceHandle, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pBuffer);
        internal vkCreateBuffer_func vkCreateBuffer;
        internal delegate VkResult vkCreateCommandPool_func(IntPtr deviceHandle, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pCommandPoolHandle);
        internal vkCreateCommandPool_func vkCreateCommandPool;
        internal delegate VkResult vkCreateFence_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFenceHandle);
        internal vkCreateFence_func vkCreateFence;
        internal delegate VkResult vkCreateFramebuffer_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFramebufferHandle);
        internal vkCreateFramebuffer_func vkCreateFramebuffer;
        internal delegate VkResult vkCreateGraphicsPipelines_func(IntPtr deviceHandle, UInt64 pipelineChache, UInt32 createInfoCount, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pPipelines);
        internal vkCreateGraphicsPipelines_func vkCreateGraphicsPipelines;
        internal delegate VkResult vkCreateImageView_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pImageBufferHandle);
        internal vkCreateImageView_func vkCreateImageView;
        internal delegate VkResult vkCreateImage_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pImageHandle);
        internal vkCreateImage_func vkCreateImage;
        internal delegate VkResult vkCreateRenderPass_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pRenderPassHandle);
        internal vkCreateRenderPass_func vkCreateRenderPass;
        internal delegate VkResult vkCreateSemaphore_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pSemaphoreHandle);
        internal vkCreateSemaphore_func vkCreateSemaphore;
        internal delegate VkResult vkCreateShaderModule_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pShaderModuleHandle);
        internal vkCreateShaderModule_func vkCreateShaderModule;
        internal delegate VkResult vkCreatePipelineLayout_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pShaderModuleHandle);
        internal vkCreatePipelineLayout_func vkCreatePipelineLayout;
        internal delegate VkResult vkEndCommandBuffer_func(IntPtr commandBufferHandle);
        internal vkEndCommandBuffer_func vkEndCommandBuffer;
        internal delegate VkResult vkGetFenceStatus_func(IntPtr deviceHandle, UInt64 fenceHandle);
        internal vkGetFenceStatus_func vkGetFenceStatus;
        internal delegate VkResult vkGetBufferMemoryRequirements_func(IntPtr deviceHandle, UInt64 bufferHandle, IntPtr pMemoryRequirements);
        internal vkGetBufferMemoryRequirements_func vkGetBufferMemoryRequirements;
        internal delegate VkResult vkGetImageMemoryRequirements_func(IntPtr deviceHandle, UInt64 imageHandle, IntPtr pMemoryRequirements);
        internal vkGetImageMemoryRequirements_func vkGetImageMemoryRequirements;
        internal delegate VkResult vkMapMemory_func(IntPtr deviceHandle, UInt64 memory, UInt64 offset, UInt64 size, VkMemoryMapFlag flags, IntPtr ppData);
        internal vkMapMemory_func vkMapMemory;
        internal delegate VkResult vkQueueSubmit_func(IntPtr queueHandle, UInt32 submitCount, IntPtr pSubmits, UInt64 fenceHandle);
        internal vkQueueSubmit_func vkQueueSubmit;
        internal delegate VkResult vkWaitForFences_func(IntPtr device, UInt32 fenceCount, IntPtr pFences, bool waitAll, UInt64 timeout);
        internal vkWaitForFences_func vkWaitForFences;
        internal delegate void vkGetDeviceQueue_func(IntPtr device, UInt32 queueFamilyIndex, UInt32 queueIndex, ref IntPtr pQueue);
        internal vkGetDeviceQueue_func vkGetDeviceQueue;
        internal delegate VkResult vkQueueWaitIdle_func(IntPtr pQueue);
        internal vkQueueWaitIdle_func vkQueueWaitIdle;
        internal delegate VkResult vkDeviceWaitIdle_func(IntPtr pQueue);
        internal vkDeviceWaitIdle_func vkDeviceWaitIdle;

        internal VkDevice(VkPhysicalDevice PhysicalDevice, IntPtr Handle, VkDeviceQueueCreateInfo[] queueCreateInfo)
        {
            _PhysicalDevice = PhysicalDevice;
            _Handle = Handle;
            vkAllocateMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkAllocateMemory_func>("vkAllocateMemory");
            vkAllocateCommandBuffers = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkAllocateCommandBuffers_func>("vkAllocateCommandBuffers");
            vkBeginCommandBuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkBeginCommandBuffer_func>("vkBeginCommandBuffer");
            vkBindBufferMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkBindBufferMemory_func>("vkBindBufferMemory");
            vkBindImageMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkBindImageMemory_func>("vkBindImageMemory");
            vkCmdBeginRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdBeginRenderPass_func>("vkCmdBeginRenderPass");
            vkCmdBindPipeline = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdBindPipeline_func>("vkCmdBindPipeline");
            vkCmdClearColorImage_Float = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdClearColorImage_Float_func>("vkCmdClearColorImage");
            vkCmdClearColorImage_Int32 = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdClearColorImage_Int32_func>("vkCmdClearColorImage");
            vkCmdClearColorImage_UInt32 = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdClearColorImage_UInt32_func>("vkCmdClearColorImage");
            vkCmdCopyImageToBuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdCopyImageToBuffer_func>("vkCmdCopyImageToBuffer");
            vkCmdEndRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdEndRenderPass_func>("vkCmdEndRenderPass");
            vkCmdDraw = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdDraw_func>("vkCmdDraw");
            vkCmdSetViewport = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdSetViewport_func>("vkCmdSetViewport");
            vkCreateBuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateBuffer_func>("vkCreateBuffer");
            vkCreateCommandPool = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateCommandPool_func>("vkCreateCommandPool");
            vkCreateFence = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateFence_func>("vkCreateFence");
            vkCreateFramebuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateFramebuffer_func>("vkCreateFramebuffer");
            vkCreateGraphicsPipelines = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateGraphicsPipelines_func>("vkCreateGraphicsPipelines");
            vkCreateImage = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateImage_func>("vkCreateImage");
            vkCreateImageView = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateImageView_func>("vkCreateImageView");
            vkCreateRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateRenderPass_func>("vkCreateRenderPass");
            vkCreateSemaphore = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateSemaphore_func>("vkCreateSemaphore");
            vkCreateShaderModule = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateShaderModule_func>("vkCreateShaderModule");
            vkCreatePipelineLayout = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreatePipelineLayout_func>("vkCreatePipelineLayout");
            vkEndCommandBuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkEndCommandBuffer_func>("vkEndCommandBuffer");
            vkGetFenceStatus = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetFenceStatus_func>("vkGetFenceStatus");
            vkGetDeviceQueue = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetDeviceQueue_func>("vkGetDeviceQueue");
            vkGetBufferMemoryRequirements = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetBufferMemoryRequirements_func>("vkGetBufferMemoryRequirements");
            vkGetImageMemoryRequirements = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetImageMemoryRequirements_func>("vkGetImageMemoryRequirements");
            vkMapMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkMapMemory_func>("vkMapMemory");
            vkQueueSubmit = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkQueueSubmit_func>("vkQueueSubmit");
            vkWaitForFences = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkWaitForFences_func>("vkWaitForFences");
            vkQueueWaitIdle = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkQueueWaitIdle_func>("vkQueueWaitIdle");
            vkDeviceWaitIdle = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkDeviceWaitIdle_func>("vkDeviceWaitIdle");


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
                UInt64 deviceMemoryHandle = 0;
                VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                VkMemoryAllocateInfo_Native allocateInfo_native = new VkMemoryAllocateInfo_Native();
                allocateInfo_native.allocationSize = allocateInfo.allocationSize;
                allocateInfo_native.memoryTypeIndex = (uint)allocateInfo.memoryType.index;
                allocateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO;
                allocateInfo_native.pNext = new IntPtr(0);
                VkResult result = vkAllocateMemory(_Handle, new IntPtr(&allocateInfo_native), ref allocator, new IntPtr(&deviceMemoryHandle));
                if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
                VkDeviceMemory deviceMemory = new VkDeviceMemory(allocateInfo.memoryType, deviceMemoryHandle, this);
                return deviceMemory;
            }
            else { throw new NotImplementedException(); }
        }

        public VkDeviceMemory AllocateMemory(ulong allocationSize, ref VkMemoryType memoryType)
        {
            VkMemoryAllocateInfo allocateInfo = new VkMemoryAllocateInfo();
            allocateInfo.allocationSize = allocationSize;
            allocateInfo.memoryType = memoryType;
            return AllocateMemory(ref allocateInfo);
        }

        public VkDeviceMemory AllocateMemory(ulong allocationSize, VkMemoryType memoryType)
        {
            VkMemoryAllocateInfo allocateInfo = new VkMemoryAllocateInfo();
            allocateInfo.allocationSize = allocationSize;
            allocateInfo.memoryType = memoryType;
            return AllocateMemory(ref allocateInfo);
        }

        public unsafe VkBuffer CreateBuffer(ref VkBufferCreateInfo createInfo)
        {
            UInt64 handle;
            VkBufferCreateInfo_Native createInfo_Native = new VkBufferCreateInfo_Native();
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            createInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            createInfo_Native.pNext = new IntPtr(0);
            createInfo_Native.flags = createInfo.flags;
            createInfo_Native.size = createInfo.size;
            createInfo_Native.sharingMode = createInfo.sharingMode;
            createInfo_Native.usage = createInfo.usage;
            createInfo_Native.queueFamilyIndexCount = (UInt32)createInfo.queueFamilies.Length;

            UInt32[] queueFamilyIndices = new UInt32[createInfo.queueFamilies.Length];
            for (int n = 0; n < queueFamilyIndices.Length; n++)
            {
                queueFamilyIndices[n] = createInfo.queueFamilies[n].index;
            }
            VkResult result = VkResult.VK_SUCCESS;
            fixed (UInt32* pQueueFamilyIndices = &queueFamilyIndices[0])
            {
                createInfo_Native.pQueueFamilyIndices = new IntPtr(pQueueFamilyIndices);
                result = vkCreateBuffer(_Handle, new IntPtr(&createInfo_Native),ref allocator, new IntPtr(&handle));
            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            VkBuffer VkBuffer = new VkBuffer(this, handle);
            return VkBuffer;
        }
 
        public VkBuffer CreateBuffer(VkBufferCreateFlag flags, UInt64 size, VkBufferUsageFlag usage, VkSharingMode sharingMode, VkQueueFamilyProperties[] queueFamilies)
        {
            VkBufferCreateInfo createInfo = new VkBufferCreateInfo();
            createInfo.flags = flags;
            createInfo.size = size;
            createInfo.sharingMode = sharingMode;
            createInfo.queueFamilies = queueFamilies;
            createInfo.usage = usage;
            return CreateBuffer(ref createInfo);
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

        public VkCommandPool CreateCommandPool(VkCommandPoolCreateFlag flags, VkQueueFamilyProperties queueFamily)
        {
            return CreateCommandPool(flags, ref queueFamily);
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

        public unsafe VkFramebuffer CreateFramebuffer(ref VkFramebufferCreateInfo framebufferCreateInfo)
        {
            if (framebufferCreateInfo.attachments == null || framebufferCreateInfo.attachments.Length == 0) { throw new Exception("There must be at least one attachement"); }
            if (framebufferCreateInfo.width == 0) { throw new Exception("width must be greater than 0"); }
            if (framebufferCreateInfo.height == 0) { throw new Exception("height must be greater than 0"); }
            if (framebufferCreateInfo.layers == 0) { throw new Exception("layers must be greater than 0"); }

            UInt64 framebufferHandle = 0;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            VkFramebufferCreateInfo_Native framebufferCreateInfo_native = new VkFramebufferCreateInfo_Native();
            framebufferCreateInfo_native.pNext = new IntPtr(0);
            framebufferCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO;
            framebufferCreateInfo_native.flags = VkFramebufferCreateFlag.NONE;
            framebufferCreateInfo_native.width = framebufferCreateInfo.width;
            framebufferCreateInfo_native.height = framebufferCreateInfo.height;
            framebufferCreateInfo_native.layers = framebufferCreateInfo.layers;
            framebufferCreateInfo_native.renderPass = framebufferCreateInfo.renderPass._Handle;
            framebufferCreateInfo_native.attachmentCount = (uint)framebufferCreateInfo.attachments.Length;

            UInt64[] attachments = new UInt64[framebufferCreateInfo_native.attachmentCount];
            for (int n = 0; n < attachments.Length; n++) { attachments[n] = framebufferCreateInfo.attachments[n]._Handle; }

            VkResult result;
            fixed (UInt64* pAttachments = &attachments[0])
            {
                framebufferCreateInfo_native.pAttachments = new IntPtr(pAttachments);
                result = vkCreateFramebuffer(_Handle, new IntPtr(&framebufferCreateInfo_native), ref allocator, new IntPtr(&framebufferHandle));
            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            return new VkFramebuffer(framebufferHandle, this);
        }

        public VkFramebuffer CreateFramebuffer(VkRenderPass renderPass, VkImageView[] attachments, UInt32 width, UInt32 height, UInt32 layers)
        {
            VkFramebufferCreateInfo framebufferCreateInfo = new VkFramebufferCreateInfo();
            framebufferCreateInfo.renderPass = renderPass;
            framebufferCreateInfo.width = width;
            framebufferCreateInfo.height = height;
            framebufferCreateInfo.layers = layers;
            framebufferCreateInfo.attachments = attachments;
            return CreateFramebuffer(ref framebufferCreateInfo);
        }

        public unsafe VkImageView CreateImageView(ref VkImageViewCreateInfo createImageViewInfo)
        {
            UInt64 imageViewHandle = 0;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            VkImageViewCreateInfo_Native createImageViewInfo_native = new VkImageViewCreateInfo_Native();
            createImageViewInfo_native.pNext = new IntPtr(0);
            createImageViewInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO;
            createImageViewInfo_native.components = createImageViewInfo.components;
            createImageViewInfo_native.flags = VkImageViewCreateFlags.NONE;
            createImageViewInfo_native.format = createImageViewInfo.format;
            createImageViewInfo_native.image = createImageViewInfo.image._Handle;
            createImageViewInfo_native.subresourceRange = createImageViewInfo.subresourceRange;
            createImageViewInfo_native.viewType = createImageViewInfo.viewType;

            VkResult result = vkCreateImageView(_Handle, new IntPtr(&createImageViewInfo_native), ref allocator, new IntPtr(&imageViewHandle));
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            return new VkImageView(imageViewHandle, this, createImageViewInfo.image);
        }

        public VkImageView CreateImageView(VkImage image, VkImageViewType viewType, VkFormat format, VkComponentMapping components, VkImageSubresourceRange subresourceRange)
        {

            VkImageViewCreateInfo createImageViewInfo = new VkImageViewCreateInfo();
            createImageViewInfo.image = image;
            createImageViewInfo.viewType = viewType;
            createImageViewInfo.format = format;
            createImageViewInfo.components = components;
            createImageViewInfo.subresourceRange = subresourceRange;

            return CreateImageView(ref createImageViewInfo);
        }

        public unsafe VkSemaphore CreateSemaphore(ref VkSemaphoreCreateInfo semaphoreCreateInfo)
        {
            UInt64 semaphoreHandle = 0;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
            VkSemaphoreCreateInfo_Native semaphoreCreateInfo_native = new VkSemaphoreCreateInfo_Native();
            semaphoreCreateInfo_native.flags = semaphoreCreateInfo.flags;
            semaphoreCreateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO;
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

        public unsafe VkImage CreateImage(ref VkImageCreateInfo imageCreateInfo)
        {
            UInt64 imageHandle = 0;

            if (imageCreateInfo.initialLayout != VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED && imageCreateInfo.initialLayout != VkImageLayout.VK_IMAGE_LAYOUT_PREINITIALIZED)
            {
                throw new Exception("with CreateImage initialLayout must be VK_IMAGE_LAYOUT_UNDEFINED or VK_IMAGE_LAYOUT_PREINITIALIZED");
            }

           VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            VkImageCreateInfo_Native imageCreateInfo_Native = new VkImageCreateInfo_Native();
            imageCreateInfo_Native.pNext = new IntPtr(0);
            imageCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO;
            imageCreateInfo_Native.usage = imageCreateInfo.usage;
            imageCreateInfo_Native.tiling = imageCreateInfo.tiling;
            imageCreateInfo_Native.sharingMode = imageCreateInfo.sharingMode;
            imageCreateInfo_Native.samples = imageCreateInfo.samples;
            if (imageCreateInfo.queueFamilies == null || imageCreateInfo.queueFamilies.Length == 0)
            {
                imageCreateInfo_Native.queueFamilyIndexCount = 0;
                imageCreateInfo_Native.pQueueFamilyIndices = new IntPtr(0);
            }
            else
            {
                imageCreateInfo_Native.queueFamilyIndexCount = (uint)imageCreateInfo.queueFamilies.Length;
                imageCreateInfo_Native.pQueueFamilyIndices = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(imageCreateInfo_Native.queueFamilyIndexCount * sizeof(UInt32)));
                for (int n = 0; n < imageCreateInfo_Native.queueFamilyIndexCount; n++) { ((uint*)imageCreateInfo_Native.pQueueFamilyIndices.ToPointer())[n] = imageCreateInfo.queueFamilies[n].index; }
            }
            imageCreateInfo_Native.mipLevels = imageCreateInfo.mipLevels;
            imageCreateInfo_Native.initialLayout = imageCreateInfo.initialLayout;
            imageCreateInfo_Native.imageType = imageCreateInfo.imageType;
            imageCreateInfo_Native.format = imageCreateInfo.format;
            imageCreateInfo_Native.flags = imageCreateInfo.flags;
            imageCreateInfo_Native.extent = imageCreateInfo.extent;
            imageCreateInfo_Native.arrayLayers = imageCreateInfo.arrayLayers;

            VkResult result = vkCreateImage(_Handle, new IntPtr(&imageCreateInfo_Native), ref allocator, new IntPtr(&imageHandle));


            if (imageCreateInfo.queueFamilies != null && imageCreateInfo.queueFamilies.Length != 0)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(imageCreateInfo_Native.pQueueFamilyIndices);
            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            return new VkImage(imageHandle, this, imageCreateInfo.format);
        }

        public unsafe VkImage CreateImage(VkImageCreateFlag flags, VkImageType imageType, VkFormat format, VkExtent3D extent, int mipLevel, int arrayLayers, VkSampleCountFlag samples, VkImageTiling tiling, VkImageUsageFlag usage, VkSharingMode sharingMode, VkQueueFamilyProperties[] queueFamilies, VkImageLayout initialLayout)
        {
            VkImageCreateInfo imageCreateInfo = new VkImageCreateInfo();
            imageCreateInfo.flags = flags;
            imageCreateInfo.imageType = imageType;
            imageCreateInfo.format = format;
            imageCreateInfo.extent = extent;
            imageCreateInfo.mipLevels = (uint)mipLevel;
            imageCreateInfo.arrayLayers = (uint)arrayLayers;
            imageCreateInfo.samples = samples;
            imageCreateInfo.tiling = tiling;
            imageCreateInfo.usage = usage;
            imageCreateInfo.sharingMode = sharingMode;
            imageCreateInfo.queueFamilies = queueFamilies;
            imageCreateInfo.initialLayout = initialLayout;
            return CreateImage(ref imageCreateInfo);
        }

        public unsafe VkImage CreateImage(VkImageCreateFlag flags, VkFormat format, int width, int height, int mipLevel, int arrayLayers, VkSampleCountFlag samples, VkImageTiling tiling, VkImageUsageFlag usage, VkSharingMode sharingMode, VkQueueFamilyProperties[] queueFamilies, VkImageLayout initialLayout)
        {
            return CreateImage(flags, VkImageType.VK_IMAGE_TYPE_2D, format, new VkExtent3D() { width = (uint)width, height = (uint)height, depth = 1 }, mipLevel, arrayLayers, samples, tiling, usage, sharingMode, queueFamilies, initialLayout);
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
            if (subpasses == null || subpasses.Length == 0) { throw new Exception("A Render pass must at least have one subpass"); }

            VkSubpassDescription_Native[] subpasses_native = new VkSubpassDescription_Native[subpasses.Length];
            for (int n = 0; n < subpasses.Length; n++)
            {
                subpasses_native[n].pipelineBindPoint = subpasses[n].pipelineBindPoint;

                if (subpasses[n].colorAttachments == null) { subpasses_native[n].colorAttachmentCount = 0; }
                else { subpasses_native[n].colorAttachmentCount = (UInt32)subpasses[n].colorAttachments.Length; }

                if (subpasses[n].inputAttachments == null) { subpasses_native[n].inputAttachmentCount = 0; }
                else { subpasses_native[n].inputAttachmentCount = (UInt32)subpasses[n].inputAttachments.Length; }

                if (subpasses_native[n].colorAttachmentCount != 0)
                {
                    subpasses_native[n].pColorAttachments = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkAttachmentReference) * subpasses_native[n].colorAttachmentCount));
                    for (int x = 0; x < subpasses_native[n].colorAttachmentCount; x++)
                    {
                        ((VkAttachmentReference*)subpasses_native[n].pColorAttachments.ToPointer())[x] = subpasses[n].colorAttachments[x];
                    }
                }
                else { subpasses_native[n].pColorAttachments = new IntPtr(0); }

                if (subpasses_native[n].inputAttachmentCount != 0)
                {
                    subpasses_native[n].pInputAttachments = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkAttachmentReference) * subpasses_native[n].inputAttachmentCount));
                    for (int x = 0; x < subpasses_native[n].inputAttachmentCount; x++)
                    {
                        ((VkAttachmentReference*)subpasses_native[n].pInputAttachments.ToPointer())[x] = subpasses[n].inputAttachments[x];
                    }
                }
                else { subpasses_native[n].pInputAttachments = new IntPtr(0); }

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

            fixed (VkSubpassDescription_Native* pSubpasses = &subpasses_native[0])
            {
                if (attachments.Length > 0 && dependencies.Length > 0)
                {
                    fixed (VkAttachmentDescription* pAttachment = &attachments[0])
                    {
                        fixed (VkSubpassDependency* pDependecies = &dependencies[0])
                        {
                            renderPassCreateInfo_Native.pAttachments = new IntPtr(pAttachment);
                            renderPassCreateInfo_Native.pDependencies = new IntPtr(pDependecies);
                            renderPassCreateInfo_Native.pSubpasses = new IntPtr(pSubpasses);
                            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                            result = vkCreateRenderPass(_Handle, new IntPtr(&renderPassCreateInfo_Native), ref allocator, new IntPtr(&renderPassHandle));
                        }
                    }
                }
                else if (attachments.Length > 0)
                {
                    fixed (VkAttachmentDescription* pAttachment = &attachments[0])
                    {

                        renderPassCreateInfo_Native.pAttachments = new IntPtr(pAttachment);
                        renderPassCreateInfo_Native.pDependencies = new IntPtr(0);
                        renderPassCreateInfo_Native.pSubpasses = new IntPtr(pSubpasses);
                        VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                        result = vkCreateRenderPass(_Handle, new IntPtr(&renderPassCreateInfo_Native), ref allocator, new IntPtr(&renderPassHandle));
                    }
                }
                else
                {
                    fixed (VkSubpassDependency* pDependecies = &dependencies[0])
                    {
                        renderPassCreateInfo_Native.pAttachments = new IntPtr(0);
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

        public unsafe VkShaderModule CreateShaderModule(ref VkShaderModuleCreateInfo shaderModuleCreateInfo)
        {
            VkResult result = VkResult.VK_SUCCESS;
            UInt64 handle;
            VkShaderModuleCreateInfo_Native shaderModuleCreateInfo_Native = new VkShaderModuleCreateInfo_Native();
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            shaderModuleCreateInfo_Native.pNext = new IntPtr(0);
            shaderModuleCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
            shaderModuleCreateInfo_Native.flags = shaderModuleCreateInfo.flags;
            shaderModuleCreateInfo_Native.codeSize = new IntPtr(shaderModuleCreateInfo.code.Length);
            fixed (byte* pCode = &shaderModuleCreateInfo.code[0])
            {
                shaderModuleCreateInfo_Native.pCode = new IntPtr(pCode);
                result = vkCreateShaderModule(_Handle, new IntPtr(&shaderModuleCreateInfo_Native), ref allocator, new IntPtr(&handle));
            }
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
            return new VkShaderModule(this, handle);
        }

        public unsafe VkPipelineLayout CreatePipelineLayout(ref VkPipelineLayoutCreateInfo pipelineLayoutCreateInfo)
        {
            VkResult result = VkResult.VK_SUCCESS;
            UInt64 handle;
            VkPipelineLayoutCreateInfo_Native pipelineLayoutCreateInfo_Native = new VkPipelineLayoutCreateInfo_Native();
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            pipelineLayoutCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO;
            pipelineLayoutCreateInfo_Native.pNext = new IntPtr(0);
            pipelineLayoutCreateInfo_Native.flags = pipelineLayoutCreateInfo.flags;
            pipelineLayoutCreateInfo_Native.pushConstantRangeCount = (uint)(pipelineLayoutCreateInfo.pushConstantRanges == null ? 0 : pipelineLayoutCreateInfo.pushConstantRanges.Length);
            pipelineLayoutCreateInfo_Native.setLayoutCount = (uint)(pipelineLayoutCreateInfo.setLayouts == null ? 0 : pipelineLayoutCreateInfo.setLayouts.Length);

            if (pipelineLayoutCreateInfo_Native.setLayoutCount > 0)
            {
                pipelineLayoutCreateInfo_Native.pSetLayouts = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(pipelineLayoutCreateInfo_Native.setLayoutCount * sizeof(UInt64)));
                for (int n = 0; n < pipelineLayoutCreateInfo_Native.setLayoutCount; n++)
                {
                    ((UInt64*)(pipelineLayoutCreateInfo_Native.pSetLayouts.ToPointer()))[n] = pipelineLayoutCreateInfo.setLayouts[n]._Handle;
                }
            }
            else
            {
                pipelineLayoutCreateInfo_Native.pSetLayouts = new IntPtr(0);
            }


            if (pipelineLayoutCreateInfo_Native.pushConstantRangeCount > 0)
            {
                fixed (VkPushConstantRange* pPushConstRange = &pipelineLayoutCreateInfo.pushConstantRanges[0])
                {
                    pipelineLayoutCreateInfo_Native.pPushConstantRanges = new IntPtr(pPushConstRange);
                    result = vkCreatePipelineLayout(_Handle, new IntPtr(&pipelineLayoutCreateInfo_Native), ref allocator, new IntPtr(&handle));
                }
            }
            else
            {
                pipelineLayoutCreateInfo_Native.pPushConstantRanges = new IntPtr(0);
                result = vkCreatePipelineLayout(_Handle, new IntPtr(&pipelineLayoutCreateInfo_Native), ref allocator, new IntPtr(&handle));
            }

            System.Runtime.InteropServices.Marshal.FreeHGlobal(pipelineLayoutCreateInfo_Native.pSetLayouts);

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            return new VkPipelineLayout(this, handle);
        }

        public VkPipelineLayout CreatePipelineLayout(VkPipelineLayoutCreateFlag flags, VkPushConstantRange[] pushConstantRanges, VkDescriptorSetLayout[] setLayouts)
        {
            VkPipelineLayoutCreateInfo pipelineLayoutCreateInfo = new VkPipelineLayoutCreateInfo();
            pipelineLayoutCreateInfo.flags = flags;
            pipelineLayoutCreateInfo.pushConstantRanges = pushConstantRanges;
            pipelineLayoutCreateInfo.setLayouts = setLayouts;

            return CreatePipelineLayout(ref pipelineLayoutCreateInfo);
        }

        public VkShaderModule CreateShaderModule(VkShaderModuleCreateFlag flags, byte[] code)
        {
            VkShaderModuleCreateInfo shaderModuleCreateInfo = new VkShaderModuleCreateInfo();
            shaderModuleCreateInfo.flags = flags;
            shaderModuleCreateInfo.code = code;
            return CreateShaderModule(ref shaderModuleCreateInfo);
        }

        public unsafe VkPipeline CreateGraphicsPipeline(VkPipelineCache pipelineCache, ref VkGraphicsPipelineCreateInfo graphicsPipelineCreateInfo)
        {
            VkResult result = VkResult.VK_SUCCESS;
            UInt64 handle;
            VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();

            if (graphicsPipelineCreateInfo.stages == null || graphicsPipelineCreateInfo.stages.Length == 0) { throw new Exception("There must be at least one stage in the graphics pipeline"); }
            if ((graphicsPipelineCreateInfo.flags & VkPipelineCreateFlags.VK_PIPELINE_CREATE_ALLOW_DERIVATIVES) != 0)
            {
                // Check the basePipelineHandle
            }

            VkGraphicsPipelineCreateInfo_Native graphicsPipelineCreateInfo_Native = new VkGraphicsPipelineCreateInfo_Native();
            graphicsPipelineCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO;
            graphicsPipelineCreateInfo_Native.pNext = new IntPtr(0);
            graphicsPipelineCreateInfo_Native.flags = graphicsPipelineCreateInfo.flags;
            graphicsPipelineCreateInfo_Native.layout = graphicsPipelineCreateInfo.layout._Handle;
            graphicsPipelineCreateInfo_Native.renderPass = graphicsPipelineCreateInfo.renderPass._Handle;
            graphicsPipelineCreateInfo_Native.subpass = graphicsPipelineCreateInfo.subpass;
            graphicsPipelineCreateInfo_Native.stageCount = (uint)graphicsPipelineCreateInfo.stages.Length;
            graphicsPipelineCreateInfo_Native.basePipelineHandle = graphicsPipelineCreateInfo.basePipeline == null ? 0 : graphicsPipelineCreateInfo.basePipeline._Handle;
            graphicsPipelineCreateInfo_Native.basePipelineIndex = graphicsPipelineCreateInfo.basePipelineIndex;


            VkPipelineShaderStageCreateInfo_Native[] stages_native = new VkPipelineShaderStageCreateInfo_Native[graphicsPipelineCreateInfo.stages.Length];
            for (int n = 0; n < stages_native.Length; n++)
            {
                stages_native[n].sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
                stages_native[n].pNext = new IntPtr(0);
                stages_native[n].module = graphicsPipelineCreateInfo.stages[n].module._Handle;
                stages_native[n].flags = graphicsPipelineCreateInfo.stages[n].flags;
                stages_native[n].stage = graphicsPipelineCreateInfo.stages[n].stage;
                byte[] utf8Name = System.Text.Encoding.UTF8.GetBytes(graphicsPipelineCreateInfo.stages[n].name);
                stages_native[n].pName = System.Runtime.InteropServices.Marshal.AllocHGlobal(utf8Name.Length + 1);
                System.Runtime.InteropServices.Marshal.Copy(utf8Name, 0, stages_native[n].pName, utf8Name.Length);
                ((byte*)(stages_native[n].pName.ToPointer()))[utf8Name.Length] = 0;

                if (graphicsPipelineCreateInfo.stages[n].specializationInfo.HasValue)
                {
                    stages_native[n].pSpecializationInfo = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkSpecializationInfo_Native)));
                    if (graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.mapEntries == null ||
                        graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.mapEntries.Length == 0)
                    {
                        ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->mapEntryCount = 0;
                        ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->pMapEntries = new IntPtr(0);
                    }

                    if (graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.data == null ||
                        graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.data.Length == 0)
                    {
                        ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->dataSize = new IntPtr(0);
                        ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->pData = new IntPtr(0);
                    }
                    else
                    {
                        ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->dataSize = new IntPtr(graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.data.Length);
                        ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->dataSize);
                        System.Runtime.InteropServices.Marshal.Copy(
                            graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.data,
                            0,
                            ((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->pData,
                            graphicsPipelineCreateInfo.stages[n].specializationInfo.Value.data.Length);
                    }
                }
                else { stages_native[n].pSpecializationInfo = new IntPtr(0); }
            }

            fixed (VkPipelineShaderStageCreateInfo_Native* pStages_native = &stages_native[0])
            {
                graphicsPipelineCreateInfo_Native.pStages = new IntPtr(pStages_native);
                VkPipelineVertexInputStateCreateInfo_Native pipelineVertexInputStateCreateInfo_Native = new VkPipelineVertexInputStateCreateInfo_Native();
                pipelineVertexInputStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO;
                pipelineVertexInputStateCreateInfo_Native.pNext = new IntPtr(0);
                pipelineVertexInputStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.vertexInputState.flags;
                if (graphicsPipelineCreateInfo.vertexInputState.vertexAttributeDescriptions == null ||
                    graphicsPipelineCreateInfo.vertexInputState.vertexAttributeDescriptions.Length == 0)
                {
                    pipelineVertexInputStateCreateInfo_Native.vertexAttributeDescriptionCount = 0;
                    pipelineVertexInputStateCreateInfo_Native.pVertexAttributeDescriptions = new IntPtr(0);
                }
                else
                {
                    pipelineVertexInputStateCreateInfo_Native.vertexAttributeDescriptionCount = (uint)graphicsPipelineCreateInfo.vertexInputState.vertexBindingDescriptions.Length;
                    pipelineVertexInputStateCreateInfo_Native.pVertexAttributeDescriptions = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkVertexInputAttributeDescription) * pipelineVertexInputStateCreateInfo_Native.vertexAttributeDescriptionCount));
                    for (int n = 0; n < pipelineVertexInputStateCreateInfo_Native.vertexAttributeDescriptionCount; n++)
                    {
                        ((VkVertexInputAttributeDescription*)pipelineVertexInputStateCreateInfo_Native.pVertexAttributeDescriptions.ToPointer())[n] = graphicsPipelineCreateInfo.vertexInputState.vertexAttributeDescriptions[n];
                    }
                }

                if (graphicsPipelineCreateInfo.vertexInputState.vertexBindingDescriptions == null ||
                    graphicsPipelineCreateInfo.vertexInputState.vertexBindingDescriptions.Length == 0)
                {
                    pipelineVertexInputStateCreateInfo_Native.vertexBindingDescriptionCount = 0;
                    pipelineVertexInputStateCreateInfo_Native.pVertexBindingDescriptions = new IntPtr(0);
                }
                else
                {
                    pipelineVertexInputStateCreateInfo_Native.vertexBindingDescriptionCount = (uint)graphicsPipelineCreateInfo.vertexInputState.vertexBindingDescriptions.Length;
                    pipelineVertexInputStateCreateInfo_Native.pVertexBindingDescriptions = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(VkVertexInputBindingDescription) * pipelineVertexInputStateCreateInfo_Native.vertexBindingDescriptionCount));
                    for(int n = 0; n < pipelineVertexInputStateCreateInfo_Native.vertexBindingDescriptionCount; n++)
                    {
                        ((VkVertexInputBindingDescription*)pipelineVertexInputStateCreateInfo_Native.pVertexBindingDescriptions.ToPointer())[n] = graphicsPipelineCreateInfo.vertexInputState.vertexBindingDescriptions[n];
                    }
                }

                graphicsPipelineCreateInfo_Native.pVertexInputState = new IntPtr(&pipelineVertexInputStateCreateInfo_Native);

                {
                    VkPipelineInputAssemblyStateCreateInfo_Native pipelineInputAssemblyStateCreateInfo_Native = new VkPipelineInputAssemblyStateCreateInfo_Native();

                    pipelineInputAssemblyStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO;
                    pipelineInputAssemblyStateCreateInfo_Native.pNext = new IntPtr(0);
                    pipelineInputAssemblyStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.inputAssemblyState.flags;
                    pipelineInputAssemblyStateCreateInfo_Native.primitiveRestartEnable = graphicsPipelineCreateInfo.inputAssemblyState.primitiveRestartEnable ? (uint)1 : (uint)0;
                    pipelineInputAssemblyStateCreateInfo_Native.topology = graphicsPipelineCreateInfo.inputAssemblyState.topology;

                    graphicsPipelineCreateInfo_Native.pInputAssemblyState = new IntPtr(&pipelineInputAssemblyStateCreateInfo_Native);
                    {
                        VkPipelineRasterizationStateCreateInfo_Native pipelineRasterizationStateCreateInfo_Native = new VkPipelineRasterizationStateCreateInfo_Native();
                        pipelineRasterizationStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO;
                        pipelineRasterizationStateCreateInfo_Native.pNext = new IntPtr(0);
                        pipelineRasterizationStateCreateInfo_Native.cullMode = graphicsPipelineCreateInfo.rasterizationState.cullMode;
                        pipelineRasterizationStateCreateInfo_Native.depthBiasClamp = graphicsPipelineCreateInfo.rasterizationState.depthBiasClamp;
                        pipelineRasterizationStateCreateInfo_Native.depthBiasConstantFactor = graphicsPipelineCreateInfo.rasterizationState.depthBiasConstantFactor;
                        pipelineRasterizationStateCreateInfo_Native.depthBiasEnable = graphicsPipelineCreateInfo.rasterizationState.depthBiasEnable ? (uint)1 : (uint)0;
                        pipelineRasterizationStateCreateInfo_Native.depthBiasSlopeFactor = graphicsPipelineCreateInfo.rasterizationState.depthBiasSlopeFactor;
                        pipelineRasterizationStateCreateInfo_Native.depthClampEnable = graphicsPipelineCreateInfo.rasterizationState.depthClampEnable ? (uint)1 : (uint)0;
                        pipelineRasterizationStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.rasterizationState.flags;
                        pipelineRasterizationStateCreateInfo_Native.frontFace = graphicsPipelineCreateInfo.rasterizationState.frontFace;
                        pipelineRasterizationStateCreateInfo_Native.lineWidth = graphicsPipelineCreateInfo.rasterizationState.lineWidth;
                        pipelineRasterizationStateCreateInfo_Native.polygonMode = graphicsPipelineCreateInfo.rasterizationState.polygonMode;
                        pipelineRasterizationStateCreateInfo_Native.rasterizerDiscardEnable = graphicsPipelineCreateInfo.rasterizationState.rasterizerDiscardEnable ? (uint)1 : (uint)0;

                        graphicsPipelineCreateInfo_Native.pRasterizationState = new IntPtr(&pipelineRasterizationStateCreateInfo_Native);

                        {
                            VkPipelineMultisampleStateCreateInfo_Native pipelineMultisampleStateCreateInfo_Native = new VkPipelineMultisampleStateCreateInfo_Native();
                            UInt64 sampleMask = 0;

                            if (graphicsPipelineCreateInfo.multisampleState.HasValue)
                            {
                                pipelineMultisampleStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO;
                                pipelineMultisampleStateCreateInfo_Native.pNext = new IntPtr(0);
                                pipelineMultisampleStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.multisampleState.Value.flags;
                                pipelineMultisampleStateCreateInfo_Native.alphaToCoverageEnable = graphicsPipelineCreateInfo.multisampleState.Value.alphaToCoverageEnable ? (uint)1 : (uint)0;
                                pipelineMultisampleStateCreateInfo_Native.alphaToOneEnable = graphicsPipelineCreateInfo.multisampleState.Value.alphaToOneEnable ? (uint)1 : (uint)0;
                                pipelineMultisampleStateCreateInfo_Native.minSampleShading = graphicsPipelineCreateInfo.multisampleState.Value.minSampleShading;
                                pipelineMultisampleStateCreateInfo_Native.sampleShadingEnable = graphicsPipelineCreateInfo.multisampleState.Value.sampleShadingEnable ? (uint)1 : (uint)0;
                                pipelineMultisampleStateCreateInfo_Native.rasterizationSamples = graphicsPipelineCreateInfo.multisampleState.Value.rasterizationSamples;
                                pipelineMultisampleStateCreateInfo_Native.pSampleMask = new IntPtr(&sampleMask);
                                UInt32* pSampleMask = (UInt32*)pipelineMultisampleStateCreateInfo_Native.pSampleMask.ToPointer();
                                if (graphicsPipelineCreateInfo.multisampleState.Value.sampleMask == null ||
                                    graphicsPipelineCreateInfo.multisampleState.Value.sampleMask.Length == 0)
                                {
                                    pipelineMultisampleStateCreateInfo_Native.pSampleMask = new IntPtr(0);
                                }
                                else
                                {
                                    if (graphicsPipelineCreateInfo.multisampleState.Value.sampleMask.Length >= 1) { pSampleMask[0] = graphicsPipelineCreateInfo.multisampleState.Value.sampleMask[0]; }
                                    if (graphicsPipelineCreateInfo.multisampleState.Value.sampleMask.Length >= 2) { pSampleMask[1] = graphicsPipelineCreateInfo.multisampleState.Value.sampleMask[1]; }
                                }
                                graphicsPipelineCreateInfo_Native.pMultisampleState = new IntPtr(&pipelineMultisampleStateCreateInfo_Native);
                            }
                            else
                            {
                                graphicsPipelineCreateInfo_Native.pMultisampleState = new IntPtr(0);
                            }

                            {
                                VkPipelineDepthStencilStateCreateInfo_Native pipelineDepthStencilStateCreateInfo_Native = new VkPipelineDepthStencilStateCreateInfo_Native();
                                if (graphicsPipelineCreateInfo.depthStencilState.HasValue)
                                {
                                    pipelineDepthStencilStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO;
                                    pipelineDepthStencilStateCreateInfo_Native.pNext = new IntPtr(0);
                                    pipelineDepthStencilStateCreateInfo_Native.back = graphicsPipelineCreateInfo.depthStencilState.Value.back;
                                    pipelineDepthStencilStateCreateInfo_Native.depthBoundsTestEnable = graphicsPipelineCreateInfo.depthStencilState.Value.depthBoundsTestEnable ? (uint)1 : (uint)0;
                                    pipelineDepthStencilStateCreateInfo_Native.depthCompareOp = graphicsPipelineCreateInfo.depthStencilState.Value.depthCompareOp;
                                    pipelineDepthStencilStateCreateInfo_Native.depthTestEnable = graphicsPipelineCreateInfo.depthStencilState.Value.depthTestEnable ? (uint)1 : (uint)0;
                                    pipelineDepthStencilStateCreateInfo_Native.depthWriteEnable = graphicsPipelineCreateInfo.depthStencilState.Value.depthWriteEnable ? (uint)1 : (uint)0;
                                    pipelineDepthStencilStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.depthStencilState.Value.flags;
                                    pipelineDepthStencilStateCreateInfo_Native.front = graphicsPipelineCreateInfo.depthStencilState.Value.front;
                                    pipelineDepthStencilStateCreateInfo_Native.maxDepthBounds = graphicsPipelineCreateInfo.depthStencilState.Value.maxDepthBounds;
                                    pipelineDepthStencilStateCreateInfo_Native.minDepthBounds = graphicsPipelineCreateInfo.depthStencilState.Value.minDepthBounds;
                                    pipelineDepthStencilStateCreateInfo_Native.stencilTestEnable = graphicsPipelineCreateInfo.depthStencilState.Value.stencilTestEnable ? (uint)1 : (uint)0;
                                    graphicsPipelineCreateInfo_Native.pDepthStencilState = new IntPtr(&pipelineDepthStencilStateCreateInfo_Native);
                                }
                                else { graphicsPipelineCreateInfo_Native.pDepthStencilState = new IntPtr(0); }

                                {
                                    VkPipelineColorBlendStateCreateInfo_Native pipelineColorBlendStateCreateInfo_Native = new VkPipelineColorBlendStateCreateInfo_Native();
                                    if (graphicsPipelineCreateInfo.colorBlendState.HasValue)
                                    {
                                        pipelineColorBlendStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO;
                                        pipelineColorBlendStateCreateInfo_Native.pNext = new IntPtr(0);
                                        pipelineColorBlendStateCreateInfo_Native.blendConstants_A = graphicsPipelineCreateInfo.colorBlendState.Value.blendConstants_A;
                                        pipelineColorBlendStateCreateInfo_Native.blendConstants_B = graphicsPipelineCreateInfo.colorBlendState.Value.blendConstants_B;
                                        pipelineColorBlendStateCreateInfo_Native.blendConstants_G = graphicsPipelineCreateInfo.colorBlendState.Value.blendConstants_G;
                                        pipelineColorBlendStateCreateInfo_Native.blendConstants_R = graphicsPipelineCreateInfo.colorBlendState.Value.blendConstants_R;
                                        pipelineColorBlendStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.colorBlendState.Value.flags;
                                        pipelineColorBlendStateCreateInfo_Native.logicOp = graphicsPipelineCreateInfo.colorBlendState.Value.logicOp;
                                        pipelineColorBlendStateCreateInfo_Native.logicOpEnable = graphicsPipelineCreateInfo.colorBlendState.Value.logicOpEnable ? (uint)1 : (uint)0;
                                        pipelineColorBlendStateCreateInfo_Native.attachmentCount = graphicsPipelineCreateInfo.colorBlendState.Value.attachments == null ? (uint)0 : (uint)graphicsPipelineCreateInfo.colorBlendState.Value.attachments.Length;

                                        if (pipelineColorBlendStateCreateInfo_Native.attachmentCount > 0)
                                        {
                                            VkPipelineColorBlendAttachmentState* attachments = (VkPipelineColorBlendAttachmentState*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(pipelineColorBlendStateCreateInfo_Native.attachmentCount * sizeof(VkPipelineColorBlendAttachmentState))).ToPointer();
                                            for (int n = 0; n < pipelineColorBlendStateCreateInfo_Native.attachmentCount; n++)
                                            {
                                                attachments[n].alphaBlendOp = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].alphaBlendOp;
                                                attachments[n].blendEnable = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].blendEnable;
                                                attachments[n].colorBlendOp = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].colorBlendOp;
                                                attachments[n].colorWriteMask = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].colorWriteMask;
                                                attachments[n].dstAlphaBlendFactor = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].dstAlphaBlendFactor;
                                                attachments[n].dstColorBlendFactor = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].dstColorBlendFactor;
                                                attachments[n].srcAlphaBlendFactor = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].srcAlphaBlendFactor;
                                                attachments[n].srcColorBlendFactor = graphicsPipelineCreateInfo.colorBlendState.Value.attachments[n].srcColorBlendFactor;
                                            }

                                            pipelineColorBlendStateCreateInfo_Native.pAttachments = new IntPtr(attachments);
                                        }
                                        else { pipelineColorBlendStateCreateInfo_Native.pAttachments = new IntPtr(0); }
                                        graphicsPipelineCreateInfo_Native.pColorBlendState = new IntPtr(&pipelineColorBlendStateCreateInfo_Native);
                                    }
                                    else { graphicsPipelineCreateInfo_Native.pColorBlendState = new IntPtr(0); }


                                    {
                                        VkPipelineDynamicStateCreateInfo_Native pipelineDynamicStateCreateInfo_Native = new VkPipelineDynamicStateCreateInfo_Native();

                                        if (graphicsPipelineCreateInfo.dynamicState.HasValue)
                                        {
                                            pipelineDynamicStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO;
                                            pipelineDynamicStateCreateInfo_Native.pNext = new IntPtr(0);
                                            pipelineDynamicStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.dynamicState.Value.flags;
                                            pipelineDynamicStateCreateInfo_Native.dynamicStateCount = graphicsPipelineCreateInfo.dynamicState.Value.dynamicStates == null ? (uint)0 : (uint)graphicsPipelineCreateInfo.dynamicState.Value.dynamicStates.Length;

                                            if (pipelineDynamicStateCreateInfo_Native.dynamicStateCount > 0)
                                            {
                                                VkDynamicState* dynamicStates = (VkDynamicState*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(graphicsPipelineCreateInfo.dynamicState.Value.dynamicStates.Length * sizeof(VkDynamicState))).ToPointer();
                                                for (int n = 0; n < pipelineDynamicStateCreateInfo_Native.dynamicStateCount; n++)
                                                {
                                                    dynamicStates[n] = graphicsPipelineCreateInfo.dynamicState.Value.dynamicStates[n];
                                                }

                                                pipelineDynamicStateCreateInfo_Native.pDynamicStates = new IntPtr(dynamicStates);
                                            }
                                            else { pipelineDynamicStateCreateInfo_Native.pDynamicStates = new IntPtr(0); }
                                            graphicsPipelineCreateInfo_Native.pDynamicState = new IntPtr(&pipelineDynamicStateCreateInfo_Native);
                                        }
                                        else { graphicsPipelineCreateInfo_Native.pDynamicState = new IntPtr(0); }

                                        {
                                            VkPipelineViewportStateCreateInfo_Native pipelineViewportStateCreateInfo_Native = new VkPipelineViewportStateCreateInfo_Native();
                                            if (graphicsPipelineCreateInfo.viewportState.HasValue)
                                            {
                                                pipelineViewportStateCreateInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO;
                                                pipelineViewportStateCreateInfo_Native.pNext = new IntPtr(0);
                                                pipelineViewportStateCreateInfo_Native.flags = graphicsPipelineCreateInfo.viewportState.Value.flags;
                                                pipelineViewportStateCreateInfo_Native.viewportCount = graphicsPipelineCreateInfo.viewportState.Value.viewports == null ? (uint)0 : (uint)graphicsPipelineCreateInfo.viewportState.Value.viewports.Length;
                                                pipelineViewportStateCreateInfo_Native.scissorCount = graphicsPipelineCreateInfo.viewportState.Value.scissors == null ? (uint)0 : (uint)graphicsPipelineCreateInfo.viewportState.Value.scissors.Length;

                                                VkViewport* viewports = (VkViewport*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(pipelineViewportStateCreateInfo_Native.viewportCount * sizeof(VkViewport)));
                                                for (int n = 0; n < pipelineViewportStateCreateInfo_Native.viewportCount; n++)
                                                {
                                                    viewports[n] = graphicsPipelineCreateInfo.viewportState.Value.viewports[n];
                                                }
                                                pipelineViewportStateCreateInfo_Native.pViewports = new IntPtr(viewports);

                                                VkRect2D* scissors = (VkRect2D*)System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(pipelineViewportStateCreateInfo_Native.scissorCount * sizeof(VkRect2D)));
                                                for (int n = 0; n < pipelineViewportStateCreateInfo_Native.viewportCount; n++)
                                                {
                                                    scissors[n] = graphicsPipelineCreateInfo.viewportState.Value.scissors[n];
                                                }
                                                pipelineViewportStateCreateInfo_Native.pScissors = new IntPtr(scissors);

                                                graphicsPipelineCreateInfo_Native.pViewportState = new IntPtr(&pipelineViewportStateCreateInfo_Native);
                                            }
                                            else { graphicsPipelineCreateInfo_Native.pViewportState = new IntPtr(0); }

                                            if (pipelineCache == null)
                                            {
                                                result = vkCreateGraphicsPipelines(_Handle, 0, 1, new IntPtr(&graphicsPipelineCreateInfo_Native), ref allocator, new IntPtr(&handle));
                                            }
                                            else
                                            {
                                                result = vkCreateGraphicsPipelines(_Handle, pipelineCache._Handle, 1, new IntPtr(&graphicsPipelineCreateInfo_Native), ref allocator, new IntPtr(&handle));
                                            }

                                            if (graphicsPipelineCreateInfo.viewportState.HasValue)
                                            {
                                                System.Runtime.InteropServices.Marshal.FreeHGlobal(pipelineViewportStateCreateInfo_Native.pViewports);
                                                System.Runtime.InteropServices.Marshal.FreeHGlobal(pipelineViewportStateCreateInfo_Native.pScissors);
                                            }
                                        }

                                        if (graphicsPipelineCreateInfo.dynamicState.HasValue)
                                        {
                                            System.Runtime.InteropServices.Marshal.FreeHGlobal(graphicsPipelineCreateInfo_Native.pDynamicState);
                                        }
                                    }

                                    if (graphicsPipelineCreateInfo.colorBlendState.HasValue)
                                    {
                                        System.Runtime.InteropServices.Marshal.FreeHGlobal(pipelineColorBlendStateCreateInfo_Native.pAttachments);
                                    }
                                }
                            }
                        }
                    }

                }

                System.Runtime.InteropServices.Marshal.FreeHGlobal(pipelineVertexInputStateCreateInfo_Native.pVertexBindingDescriptions);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pipelineVertexInputStateCreateInfo_Native.pVertexAttributeDescriptions);
            }

            for (int n = 0; n < stages_native.Length; n++)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(stages_native[n].pName);
                if (stages_native[n].pSpecializationInfo.ToInt64() == 0)
                {
                    if (stages_native[n].pSpecializationInfo.ToInt64() != 0)
                    {
                        System.Runtime.InteropServices.Marshal.FreeHGlobal(((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->pData);
                        System.Runtime.InteropServices.Marshal.FreeHGlobal(((VkSpecializationInfo_Native*)stages_native[n].pSpecializationInfo)->pMapEntries);
                    }
                }
                System.Runtime.InteropServices.Marshal.FreeHGlobal(stages_native[n].pSpecializationInfo);
            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }

            return new VkPipeline(handle, this);
        }

        public unsafe VkPipeline CreateGraphicsPipeline(VkPipelineCache pipelineCache,
                                                        VkPipelineCreateFlags flags,
                                                        VkPipelineShaderStageCreateInfo[] stages,
                                                        VkPipelineVertexInputStateCreateInfo vertexInputState,
                                                        VkPipelineInputAssemblyStateCreateInfo inputAssemblyState,
                                                        VkPipelineTessellationStateCreateInfo? tessellationState,
                                                        VkPipelineViewportStateCreateInfo? viewportState,
                                                        VkPipelineRasterizationStateCreateInfo rasterizationState,
                                                        VkPipelineMultisampleStateCreateInfo? multisampleState,
                                                        VkPipelineDepthStencilStateCreateInfo? depthStencilState,
                                                        VkPipelineColorBlendStateCreateInfo? colorBlendState,
                                                        VkPipelineDynamicStateCreateInfo? dynamicState,
                                                        VkPipelineLayout layout,
                                                        VkRenderPass renderPass,
                                                        UInt32 subpass,
                                                        VkPipeline basePipeline,
                                                        Int32 basePipelineIndex)
        {
            VkGraphicsPipelineCreateInfo graphicsPipelineCreateInfo = new VkGraphicsPipelineCreateInfo();

            graphicsPipelineCreateInfo.flags = flags;
            graphicsPipelineCreateInfo.stages = stages;
            graphicsPipelineCreateInfo.vertexInputState = vertexInputState;
            graphicsPipelineCreateInfo.inputAssemblyState = inputAssemblyState;
            graphicsPipelineCreateInfo.tessellationState = tessellationState;
            graphicsPipelineCreateInfo.viewportState = viewportState;
            graphicsPipelineCreateInfo.rasterizationState = rasterizationState;
            graphicsPipelineCreateInfo.multisampleState = multisampleState;
            graphicsPipelineCreateInfo.depthStencilState = depthStencilState;
            graphicsPipelineCreateInfo.colorBlendState = colorBlendState;
            graphicsPipelineCreateInfo.dynamicState = dynamicState;
            graphicsPipelineCreateInfo.layout = layout;
            graphicsPipelineCreateInfo.renderPass = renderPass;
            graphicsPipelineCreateInfo.subpass = subpass;
            graphicsPipelineCreateInfo.basePipeline = basePipeline;
            graphicsPipelineCreateInfo.basePipelineIndex = basePipelineIndex;

            return CreateGraphicsPipeline(pipelineCache, ref graphicsPipelineCreateInfo);
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
