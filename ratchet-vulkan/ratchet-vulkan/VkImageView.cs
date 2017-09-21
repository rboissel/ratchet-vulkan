﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkImageView
    {
        internal UInt64 _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }

        internal VkImageView(UInt64 Handle, VkDevice Parent)
        {
            _Parent = Parent;
            _Handle = Handle;
        }
    }
}
