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
        internal delegate VkResult vkCmdClearColorImage_Float_func(IntPtr commandBuffer, UInt64 image, VkImageLayout imageLayout, ref VkClearValue.VkClearColorValue.Float_s pColor, UInt32 rangeCount, IntPtr pRanges);
        internal vkCmdClearColorImage_Float_func vkCmdClearColorImage_Float;
        internal delegate VkResult vkCmdClearColorImage_Int32_func(IntPtr commandBuffer, UInt64 image, VkImageLayout imageLayout, ref VkClearValue.VkClearColorValue.Int32_t_s pColor, UInt32 rangeCount, IntPtr pRanges);
        internal vkCmdClearColorImage_Int32_func vkCmdClearColorImage_Int32;
        internal delegate VkResult vkCmdClearColorImage_UInt32_func(IntPtr commandBuffer, UInt64 image, VkImageLayout imageLayout, ref VkClearValue.VkClearColorValue.UInt32_t_s pColor, UInt32 rangeCount, IntPtr pRanges);
        internal vkCmdClearColorImage_UInt32_func vkCmdClearColorImage_UInt32;
        internal delegate void vkCmdBeginRenderPass_func(IntPtr commandBuffer, IntPtr pRenderPassBegin, VkSubpassContents contents);
        internal vkCmdBeginRenderPass_func vkCmdBeginRenderPass;
        internal delegate void vkCmdEndRenderPass_func(IntPtr commandBuffer);
        internal vkCmdEndRenderPass_func vkCmdEndRenderPass;
        internal delegate void vkCmdSetViewport_func(IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, IntPtr pViewports);
        internal vkCmdSetViewport_func vkCmdSetViewport;
        internal delegate VkResult vkCreateCommandPool_func(IntPtr deviceHandle, IntPtr pAllocateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pCommandPoolHandle);
        internal vkCreateCommandPool_func vkCreateCommandPool;
        internal delegate VkResult vkCreateFence_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFenceHandle);
        internal vkCreateFence_func vkCreateFence;
        internal delegate VkResult vkCreateFramebuffer_func(IntPtr deviceHandle, IntPtr pCreateInfo, ref VkAllocationCallbacks pAllocator, IntPtr pFramebufferHandle);
        internal vkCreateFramebuffer_func vkCreateFramebuffer;
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


        internal VkDevice(VkPhysicalDevice PhysicalDevice, IntPtr Handle, VkDeviceQueueCreateInfo[] queueCreateInfo)
        {
            _PhysicalDevice = PhysicalDevice;
            _Handle = Handle;
            vkAllocateMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkAllocateMemory_func>("vkAllocateMemory");
            vkAllocateCommandBuffers = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkAllocateCommandBuffers_func>("vkAllocateCommandBuffers");
            vkBeginCommandBuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkBeginCommandBuffer_func>("vkBeginCommandBuffer");
            vkBindImageMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkBindImageMemory_func>("vkBindImageMemory");
            vkCmdBeginRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdBeginRenderPass_func>("vkCmdBeginRenderPass");
            vkCmdClearColorImage_Float = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdClearColorImage_Float_func>("vkCmdClearColorImage");
            vkCmdClearColorImage_Int32 = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdClearColorImage_Int32_func>("vkCmdClearColorImage");
            vkCmdClearColorImage_UInt32 = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdClearColorImage_UInt32_func>("vkCmdClearColorImage");
            vkCmdEndRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCmdEndRenderPass_func>("vkCmdEndRenderPass");
            vkCreateCommandPool = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateCommandPool_func>("vkCreateCommandPool");
            vkCreateFence = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateFence_func>("vkCreateFence");
            vkCreateFramebuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateFramebuffer_func>("vkCreateFramebuffer");
            vkCreateImage = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateImage_func>("vkCreateImage");
            vkCreateImageView = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateImageView_func>("vkCreateImageView");
            vkCreateRenderPass = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateRenderPass_func>("vkCreateRenderPass");
            vkCreateSemaphore = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateSemaphore_func>("vkCreateSemaphore");
            vkCreateShaderModule = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreateShaderModule_func>("vkCreateShaderModule");
            vkCreatePipelineLayout = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkCreatePipelineLayout_func>("vkCreatePipelineLayout");
            vkEndCommandBuffer = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkEndCommandBuffer_func>("vkEndCommandBuffer");
            vkGetFenceStatus = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetFenceStatus_func>("vkGetFenceStatus");
            vkGetDeviceQueue = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetDeviceQueue_func>("vkGetDeviceQueue");
            vkGetImageMemoryRequirements = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkGetImageMemoryRequirements_func>("vkGetImageMemoryRequirements");
            vkMapMemory = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkMapMemory_func>("vkMapMemory");
            vkQueueSubmit = PhysicalDevice._ParentInstance.vkGetInstanceProcAddr<vkQueueSubmit_func>("vkQueueSubmit");
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
                UInt64 deviceMemoryHandle = 0;
                VkAllocationCallbacks allocator = Allocator.getAllocatorCallbacks();
                VkMemoryAllocateInfo_Native allocateInfo_native = new VkMemoryAllocateInfo_Native();
                allocateInfo_native.allocationSize = allocateInfo.allocationSize;
                allocateInfo_native.memoryTypeIndex = (uint)allocateInfo.memoryType.index;
                allocateInfo_native.sType = VkStructureType.VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO;
                allocateInfo_native.pNext = new IntPtr(0);
                VkResult result = vkAllocateMemory(_Handle, new IntPtr(&allocateInfo_native), ref allocator, new IntPtr(&deviceMemoryHandle));
                if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
                VkDeviceMemory deviceMemory = new VkDeviceMemory(deviceMemoryHandle, this);
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

            return new VkImageView(imageViewHandle, this);
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

            return new VkImage(imageHandle, this);
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


            if (pipelineLayoutCreateInfo_Native.setLayoutCount == 0)
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
