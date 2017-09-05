﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Ratchet.Drawing.Vulkan
{

    [StructLayout(LayoutKind.Sequential)]
    public struct VkPhysicalDeviceMemoryProperties
    {
        const int VK_MAX_MEMORY_TYPES = 32;
        const int VK_MAX_MEMORY_HEAPS = 16;

        public UInt32 memoryTypeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK_MAX_MEMORY_TYPES)]
        public VkMemoryType[] memoryTypes;
        public UInt32 memoryHeapCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK_MAX_MEMORY_HEAPS)]
        public VkMemoryHeap[] memoryHeaps;
    }
}
