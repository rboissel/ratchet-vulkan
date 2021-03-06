﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VkPushConstantRange
    {
        VkShaderStageFlags stageFlags;
        UInt32 offset;
        UInt32 size;
    }
}
