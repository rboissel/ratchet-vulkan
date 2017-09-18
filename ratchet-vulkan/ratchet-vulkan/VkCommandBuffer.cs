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

            VkResult result =  _Parent.Device.vkBeginCommandBuffer(_Handle, new IntPtr(&commandBufferBeginInfo_Native));

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

        public unsafe void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, ref VkClearColorValue.Float color, VkImageSubresourceRange[] Ranges)
        {
            if (Ranges == null || Ranges.Length == 0) { throw new Exception("There must be at least one range"); }
            fixed (VkImageSubresourceRange* pRange = &Ranges[0])
            { _Parent.Device.vkCmdClearColorImage_Float(_Handle, Image._Handle, ImageLayout, ref color, (uint)Ranges.Length, new IntPtr(pRange)); }
        }

        public unsafe void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, ref VkClearColorValue.Int32_t color, VkImageSubresourceRange[] Ranges)
        {
            if (Ranges == null || Ranges.Length == 0) { throw new Exception("There must be at least one range"); }
            fixed (VkImageSubresourceRange* pRange = &Ranges[0])
            { _Parent.Device.vkCmdClearColorImage_Int32(_Handle, Image._Handle, ImageLayout, ref color, (uint)Ranges.Length, new IntPtr(pRange)); }
        }

        public unsafe void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, ref VkClearColorValue.UInt32_t color, VkImageSubresourceRange[] Ranges)
        {
            if (Ranges == null || Ranges.Length == 0) { throw new Exception("There must be at least one range"); }
            fixed (VkImageSubresourceRange* pRange = &Ranges[0])
            { _Parent.Device.vkCmdClearColorImage_UInt32(_Handle, Image._Handle, ImageLayout, ref color, (uint)Ranges.Length, new IntPtr(pRange)); }
        }

        public void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, float R, float G, float B, float A, VkImageSubresourceRange[] Ranges)
        {
            VkClearColorValue.Float color = new VkClearColorValue.Float();
            color.float32 = new float[4];
            color.float32[0] = R;
            color.float32[1] = G;
            color.float32[2] = B;
            color.float32[3] = A;
            CmdClearColorImage(Image, ImageLayout, ref color, Ranges);
        }

        public void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, int R, int G, int B, int A, VkImageSubresourceRange[] Ranges)
        {
            VkClearColorValue.Int32_t color = new VkClearColorValue.Int32_t();
            color.int32 = new int[4];
            color.int32[0] = R;
            color.int32[1] = G;
            color.int32[2] = B;
            color.int32[3] = A;
            CmdClearColorImage(Image, ImageLayout, ref color, Ranges);
        }

        public void CmdClearColorImage(VkImage Image, VkImageLayout ImageLayout, uint R, uint G, uint B, uint A, VkImageSubresourceRange[] Ranges)
        {
            VkClearColorValue.UInt32_t color = new VkClearColorValue.UInt32_t();
            color.uint32 = new uint[4];
            color.uint32[0] = R;
            color.uint32[1] = G;
            color.uint32[2] = B;
            color.uint32[3] = A;
            CmdClearColorImage(Image, ImageLayout, ref color, Ranges);
        }
    }
}
