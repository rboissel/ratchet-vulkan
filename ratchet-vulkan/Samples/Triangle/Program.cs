using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ratchet.Drawing.Vulkan;

// This sample is partially based on the sample: https://vulkan-tutorial.com/Drawing_a_triangle

namespace Triangle
{
    static class Program
    {
        /// <summary>
        /// Main Entry point
        /// </summary>
        [STAThread]
        static unsafe void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Triangle());
        }
    }
}
