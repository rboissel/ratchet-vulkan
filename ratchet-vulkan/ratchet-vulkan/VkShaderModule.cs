﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    public class VkShaderModule
    {
        internal UInt64 _Handle;
        VkDevice _Parent;

        public VkDevice Device { get { return _Parent; } }

        internal VkShaderModule(VkDevice Parent, UInt64 Handle)
        {
            _Handle = Handle;
            _Parent = Parent;
        }
    }
}
