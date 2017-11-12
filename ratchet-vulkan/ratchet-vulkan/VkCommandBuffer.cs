using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkCommandBuffer
    {
        internal IntPtr _Handle;
        VkCommandPool _Parent;

        public VkCommandPool CommandPool { get { return _Parent; } }

        internal VkCommandBuffer(IntPtr Handle, VkCommandPool Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
        }

        public unsafe void Begin(ref VkCommandBufferBeginInfo CommandBufferBeginInfo)
        {
            VkCommandBufferBeginInfo_Native commandBufferBeginInfo_Native = new VkCommandBufferBeginInfo_Native();
            commandBufferBeginInfo_Native.sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO;
            commandBufferBeginInfo_Native.pNext = new IntPtr(0);
            commandBufferBeginInfo_Native.flags = CommandBufferBeginInfo.flags;
            if (CommandBufferBeginInfo.inheritanceInfo != null)
            {

            }
            else
            {
                commandBufferBeginInfo_Native.pInheritanceInfo = new IntPtr(0);
            }

            VkResult result = _Parent.Device.vkBeginCommandBuffer(_Handle, new IntPtr(&commandBufferBeginInfo_Native));

            if (CommandBufferBeginInfo.inheritanceInfo != null)
            {

            }

            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }

        public void Begin(VkCommandBufferUsageFlag Flags, ref VkCommandBufferInheritanceInfo InheritanceInfo)
        {
            VkCommandBufferBeginInfo CommandBufferBeginInfo = new VkCommandBufferBeginInfo();
            CommandBufferBeginInfo.flags = Flags;
            CommandBufferBeginInfo.inheritanceInfo = InheritanceInfo;
            Begin(ref CommandBufferBeginInfo);
        }

        public void Begin(VkCommandBufferUsageFlag Flags)
        {
            VkCommandBufferBeginInfo CommandBufferBeginInfo = new VkCommandBufferBeginInfo();
            CommandBufferBeginInfo.flags = Flags;
            CommandBufferBeginInfo.inheritanceInfo = null;
            Begin(ref CommandBufferBeginInfo);
        }

        public void End()
        {
            VkResult result = _Parent.Device.vkEndCommandBuffer(_Handle);
            if (result != VkResult.VK_SUCCESS) { throw new Exception(result.ToString()); }
        }

        public unsafe void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, ref VkClearValue.VkClearColorValue.Float color, VkImageSubresourceRange[] Ranges)
        {
            VkClearValue.VkClearColorValue.Float_s color_native = new VkClearValue.VkClearColorValue.Float_s();
            color_native.float32 = color.float32;

            if (Ranges == null || Ranges.Length == 0) { throw new Exception("There must be at least one range"); }
            fixed (VkImageSubresourceRange* pRange = &Ranges[0])
            { _Parent.Device.vkCmdClearColorImage_Float(_Handle, Image._Handle, ImageLayout, ref color_native, (uint)Ranges.Length, new IntPtr(pRange)); }
        }

        public unsafe void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, ref VkClearValue.VkClearColorValue.Int32_t color, VkImageSubresourceRange[] Ranges)
        {
            VkClearValue.VkClearColorValue.Int32_t_s color_native = new VkClearValue.VkClearColorValue.Int32_t_s();
            color_native.int32 = color.int32;

            if (Ranges == null || Ranges.Length == 0) { throw new Exception("There must be at least one range"); }
            fixed (VkImageSubresourceRange* pRange = &Ranges[0])
            { _Parent.Device.vkCmdClearColorImage_Int32(_Handle, Image._Handle, ImageLayout, ref color_native, (uint)Ranges.Length, new IntPtr(pRange)); }
        }

        public unsafe void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, ref VkClearValue.VkClearColorValue.UInt32_t color, VkImageSubresourceRange[] Ranges)
        {
            VkClearValue.VkClearColorValue.UInt32_t_s color_native = new VkClearValue.VkClearColorValue.UInt32_t_s();
            color_native.uint32 = color.uint32;

            if (Ranges == null || Ranges.Length == 0) { throw new Exception("There must be at least one range"); }
            fixed (VkImageSubresourceRange* pRange = &Ranges[0])
            { _Parent.Device.vkCmdClearColorImage_UInt32(_Handle, Image._Handle, ImageLayout, ref color_native, (uint)Ranges.Length, new IntPtr(pRange)); }
        }

        public void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, float R, float G, float B, float A, VkImageSubresourceRange[] Ranges)
        {
            VkClearValue.VkClearColorValue.Float color = new VkClearValue.VkClearColorValue.Float();
            color.float32 = new float[4];
            color.float32[0] = R;
            color.float32[1] = G;
            color.float32[2] = B;
            color.float32[3] = A;
            CmdClearColorImage(Image, ImageLayout, ref color, Ranges);
        }

        public void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, int R, int G, int B, int A, VkImageSubresourceRange[] Ranges)
        {
            VkClearValue.VkClearColorValue.Int32_t color = new VkClearValue.VkClearColorValue.Int32_t();
            color.int32 = new int[4];
            color.int32[0] = R;
            color.int32[1] = G;
            color.int32[2] = B;
            color.int32[3] = A;
            CmdClearColorImage(Image, ImageLayout, ref color, Ranges);
        }

        public void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, uint R, uint G, uint B, uint A, VkImageSubresourceRange[] Ranges)
        {
            VkClearValue.VkClearColorValue.UInt32_t color = new VkClearValue.VkClearColorValue.UInt32_t();
            color.uint32 = new uint[4];
            color.uint32[0] = R;
            color.uint32[1] = G;
            color.uint32[2] = B;
            color.uint32[3] = A;
            CmdClearColorImage(Image, ImageLayout, ref color, Ranges);
        }

        public unsafe void CmdBeginRenderPass(ref VkRenderPassBeginInfo renderPassBegin, VkSubpassContents contents)
        {
            VkRenderPassBeginInfo_Native renderPassBegin_native = new VkRenderPassBeginInfo_Native();
            renderPassBegin_native.pNext = new IntPtr(0);
            renderPassBegin_native.sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO;
            if (renderPassBegin.clearValues == null || renderPassBegin.clearValues.Length == 0) { renderPassBegin_native.clearValueCount = 0; }
            else
            {
                renderPassBegin_native.clearValueCount = (uint)renderPassBegin.clearValues.Length;
                renderPassBegin_native.pClearValues = System.Runtime.InteropServices.Marshal.AllocHGlobal(new IntPtr(sizeof(UInt32) * 4 * renderPassBegin_native.clearValueCount));
            }
            renderPassBegin_native.framebufferHandle = renderPassBegin.framebuffer._Handle;
            renderPassBegin_native.renderArea = renderPassBegin.renderArea;
            renderPassBegin_native.renderPassHandle = renderPassBegin.renderPass._Handle;

            for (int n = 0; n < renderPassBegin_native.clearValueCount; n++)
            {
                if (renderPassBegin.clearValues[n] is VkClearValue.VkClearColorValue.Float)
                {
                    VkClearValue.VkClearColorValue.Float value = renderPassBegin.clearValues[n] as VkClearValue.VkClearColorValue.Float;
                    float* pValue = ((float*)(renderPassBegin_native.pClearValues.ToPointer()) + (n * 4));
                    pValue[0] = value.float32[0];
                    pValue[1] = value.float32[1];
                    pValue[2] = value.float32[2];
                    pValue[3] = value.float32[3];
                }
                else if (renderPassBegin.clearValues[n] is VkClearValue.VkClearColorValue.Int32_t)
                {
                    VkClearValue.VkClearColorValue.Int32_t value = renderPassBegin.clearValues[n] as VkClearValue.VkClearColorValue.Int32_t;
                    Int32* pValue = ((Int32*)(renderPassBegin_native.pClearValues.ToPointer()) + (n * 4));
                    pValue[0] = value.int32[0];
                    pValue[1] = value.int32[1];
                    pValue[2] = value.int32[2];
                    pValue[3] = value.int32[3];
                }
                else if (renderPassBegin.clearValues[n] is VkClearValue.VkClearColorValue.UInt32_t)
                {
                    VkClearValue.VkClearColorValue.UInt32_t value = renderPassBegin.clearValues[n] as VkClearValue.VkClearColorValue.UInt32_t;
                    UInt32* pValue = ((UInt32*)(renderPassBegin_native.pClearValues.ToPointer()) + (n * 4));
                    pValue[0] = value.uint32[0];
                    pValue[1] = value.uint32[1];
                    pValue[2] = value.uint32[2];
                    pValue[3] = value.uint32[3];
                }
                else if (renderPassBegin.clearValues[n] is VkClearValue.VkClearDepthStencilValue.VkClearDepthStencilValue)
                {
                    VkClearValue.VkClearDepthStencilValue.VkClearDepthStencilValue value = renderPassBegin.clearValues[n] as VkClearValue.VkClearDepthStencilValue.VkClearDepthStencilValue;
                    *((float*)(renderPassBegin_native.pClearValues.ToPointer()) + (n * 4)) = value.depth;
                    *((UInt32*)(renderPassBegin_native.pClearValues.ToPointer()) + (n * 4 + 1)) = value.stencil;
                }
            }

            _Parent.Device.vkCmdBeginRenderPass(_Handle, new IntPtr(&renderPassBegin_native), contents);

            System.Runtime.InteropServices.Marshal.FreeHGlobal(renderPassBegin_native.pClearValues);

        }

        public unsafe void CmdBeginRenderPass(VkRenderPass renderPass, VkRect2D renderArea, VkFramebuffer frameBuffer, VkClearValue[] clearValues, VkSubpassContents contents)
        {
            VkRenderPassBeginInfo renderPassBegin = new VkRenderPassBeginInfo();
            renderPassBegin.renderPass = renderPass;
            renderPassBegin.renderArea = renderArea;
            renderPassBegin.framebuffer = frameBuffer;
            renderPassBegin.clearValues = clearValues;
            CmdBeginRenderPass(ref renderPassBegin, contents);
        }

        public unsafe void CmdSetViewport(UInt32 firstViewport, UInt32 viewportCount, VkViewport[] viewports)
        {
            fixed (VkViewport* pViewport = &viewports[0])
            {
                _Parent.Device.vkCmdSetViewport(_Handle, firstViewport, viewportCount, new IntPtr(pViewport));
            }
        }

        public void CmdSetViewport(VkViewport[] viewports)
        {
            CmdSetViewport(0, (uint)viewports.Length, viewports);
        }

        public unsafe void CmdBindPipeline(VkPipelineBindPoint pipelineBindPoint, VkPipeline pipeline)
        {
            _Parent.Device.vkCmdBindPipeline(_Handle, pipelineBindPoint, pipeline._Handle);
        }

        public unsafe void CmdDraw(UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            _Parent.Device.vkCmdDraw(_Handle, vertexCount, instanceCount, firstVertex, firstInstance);
        }

        public unsafe void CmdBindVertexBuffers(UInt32 firstBinding, VkBuffer[] buffers, UInt64[] offsets)
        {
            if (buffers.Length != offsets.Length) { throw new Exception("buffers and offsets must have the same size"); }
            UInt64[] bufferHandles = new UInt64[buffers.Length];
            for (int n = 0; n < buffers.Length; n++) { bufferHandles[n] = buffers[n]._Handle; }
            fixed (UInt64* pBuffers = &bufferHandles[0])
            {
                fixed (UInt64* pOffsets = &offsets[0])
                {
                    _Parent.Device.vkCmdBindVertexBuffers(_Handle, firstBinding, (uint)buffers.Length, new IntPtr(pBuffers), new IntPtr(pOffsets));
                }
            }
        }

        public unsafe void CmdBindVertexBuffers(UInt32 binding, VkBuffer buffer, UInt64 offset)
        {
            CmdBindVertexBuffers(binding, new VkBuffer[] { buffer }, new UInt64[] { offset });
        }

        public void CmdEndRenderPass()
        {
            _Parent.Device.vkCmdEndRenderPass(_Handle);
        }
    }
}
