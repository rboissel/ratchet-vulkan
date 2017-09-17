using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public enum VkCommandBufferUsageFlag
    {
        NONE = 0,
        VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT = 0x00000001,
        VK_COMMAND_BUFFER_USAGE_RENDER_PASS_CONTINUE_BIT = 0x00000002,
        VK_COMMAND_BUFFER_USAGE_SIMULTANEOUS_USE_BIT = 0x00000004,
    }

    struct VkCommandBufferBeginInfo_Native
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCommandBufferUsageFlag flags;
        public IntPtr pInheritanceInfo;
    }

    public struct VkCommandBufferBeginInfo
    {
        public VkCommandBufferUsageFlag flags;
        public VkCommandBufferInheritanceInfo? inheritanceInfo;
    }
}
