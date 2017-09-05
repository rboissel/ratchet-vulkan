using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ratchet_vulkan.Platform.Win32
{
    class VkLibrary
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr lib, string proc);

        public VkLibrary()
        {
            Microsoft.Win32.RegistryKey WddmAdapters;
            
            try
            {
                Microsoft.Win32.RegistryKey HKLM = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default);
                Microsoft.Win32.RegistryKey SYSTEM = HKLM.OpenSubKey("SYSTEM");
                Microsoft.Win32.RegistryKey CurrentControlSet = HKLM.OpenSubKey("CurrentControlSet");
                Microsoft.Win32.RegistryKey Control = HKLM.OpenSubKey("Control");
                Microsoft.Win32.RegistryKey Class = HKLM.OpenSubKey("Class");
                WddmAdapters = HKLM.OpenSubKey("{4d36e968-e325-11ce-bfc1-08002be10318}");
                HKLM.Close();
                SYSTEM.Close();
                CurrentControlSet.Close();
                Control.Close();
                Class.Close();
            }
            catch { return; }

            foreach (string WddmAdapterName in WddmAdapters.GetSubKeyNames())
            {
                Microsoft.Win32.RegistryKey WddmAdapter = WddmAdapters.OpenSubKey(WddmAdapterName);
                string driverName = (string)WddmAdapter.GetValue("OpenGLDriverName");
                if (System.IO.File.Exists("C:/Windows/System32/" + driverName + ".dll"))
                {
                    IntPtr hOglLib = LoadLibrary("C:/Windows/System32/" + driverName + ".dll");
                    if (System.Runtime.InteropServices.Marshal.GetLastWin32Error() == 0)
                    {
                        IntPtr getInstanceProcAddr = GetProcAddress(hOglLib, "vk_icdGetInstanceProcAddr");
                        if (System.Runtime.InteropServices.Marshal.GetLastWin32Error() == 0)
                        {

                        }
                    }
                }
            }

        }
    }
}
