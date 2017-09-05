using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    unsafe class WDDMAdapter
    {
        string _OpenGLDriver = "";
        string _DeviceId = "";

        IntPtr _OpenGLDriverLibrary = new IntPtr(0);
        IntPtr _VkGetInstanceProcAddr_ptr = new IntPtr(0);
        delegate IntPtr vkGetInstanceProcAddr_func(IntPtr vkInstance, string Name);
        vkGetInstanceProcAddr_func _vkGetInstanceProcAddr_del;

        public string OpenGLDriver { get { return _OpenGLDriver; } }
        public string DeviceId { get { return _DeviceId; } }

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string libraryName);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr library, string functionName);

        public DelegateType vkGetInstanceProcAddr<DelegateType>(IntPtr vkInstance, string functionName)
        {
            lock (this)
            {
                if (_OpenGLDriverLibrary.ToInt64() == 0) { _OpenGLDriverLibrary = LoadLibrary(_OpenGLDriver); if (_OpenGLDriverLibrary.ToInt64() == 0) { return default(DelegateType); } }
                if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0)
                {
                    _VkGetInstanceProcAddr_ptr = GetProcAddress(_OpenGLDriverLibrary, "vkGetInstanceProcAddr");
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0) { _VkGetInstanceProcAddr_ptr = GetProcAddress(_OpenGLDriverLibrary, "vk_GetInstanceProcAddr"); }
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0) { _VkGetInstanceProcAddr_ptr = GetProcAddress(_OpenGLDriverLibrary, "vk_icdGetInstanceProcAddr"); }
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() != 0)
                    {
                        _vkGetInstanceProcAddr_del = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<vkGetInstanceProcAddr_func>(_VkGetInstanceProcAddr_ptr);
                    }
                }
                return System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<DelegateType>(_vkGetInstanceProcAddr_del(vkInstance, functionName));
            }
        }

        public WDDMAdapter(string DeviceId, string OpenGLDriver)
        {
            _OpenGLDriver = OpenGLDriver;
            _DeviceId = DeviceId;
        }

        static string[] getVulkanDrivers()
        {
            HashSet<string> drivers = new HashSet<string>();
            foreach (WDDMAdapter adapter in getWDDMAdapters())
            {
                drivers.Add(adapter._OpenGLDriver);
            }
            return new List<string>(drivers).ToArray();
        }

        static string getStringValue(Microsoft.Win32.RegistryKey WDDMAdapterKey, string ValueName)
        {
            try
            {
                object val = WDDMAdapterKey.GetValue(ValueName);
                if (val is string[]) { return ((string[])val)[0]; }
                if (val is string) { return ((string)val); }
            }
            catch { }
            return "";
        }

        static string getWDDMAdapterDeviceId(Microsoft.Win32.RegistryKey WDDMAdapterKey)
        {
            if (WDDMAdapterKey == null) { return ""; }
            try { return getStringValue(WDDMAdapterKey, "MatchingDeviceId").ToLower(); } catch { }
            return "";
        }

        static string getWDDMAdapterOpenGLDriver(Microsoft.Win32.RegistryKey WDDMAdapterKey)
        {
            if (WDDMAdapterKey == null) { return ""; }
            try
            {
                try
                {
                    if (!System.Environment.Is64BitProcess)
                    {
                        string oglDriverName = getStringValue(WDDMAdapterKey, "OpenGLDriverNameWoW").Trim();
                        if (!oglDriverName.ToLower().EndsWith(".dll")) { oglDriverName += ".dll"; }
                        if (oglDriverName != "")
                        {
                            try { if (System.IO.File.Exists("C:/Windows/Syswow64/" + oglDriverName)) { return "C:/Windows/Syswow64/" + oglDriverName; } } catch { }
                            try { if (System.IO.File.Exists("C:/Windows/System32/" + oglDriverName)) { return "C:/Windows/System32/" + oglDriverName; } } catch { }
                            try { if (System.IO.File.Exists(oglDriverName)) { return oglDriverName; } } catch { }
                        }
                    }
                }
                catch { }

                {
                    string oglDriverName = ((string[])WDDMAdapterKey.GetValue("OpenGLDriverName"))[0].Trim();
                    if (!oglDriverName.ToLower().EndsWith(".dll")) { oglDriverName += ".dll"; }
                    if (oglDriverName != "")
                    {
                        try { if (System.IO.File.Exists("C:/Windows/System32/" + oglDriverName)) { return "C:/Windows/System32/" + oglDriverName; } } catch { }
                        try { if (System.IO.File.Exists(oglDriverName)) { return oglDriverName; } } catch { }
                    }
                }
            }
            catch { }
            return "";
        }

        public static List<WDDMAdapter> getWDDMAdapters()
        {
            List<WDDMAdapter> adapters = new List<WDDMAdapter>();
            if (System.Environment.OSVersion.Platform == PlatformID.Win32NT ||
                System.Environment.OSVersion.Platform == PlatformID.Xbox)
            {
                Microsoft.Win32.RegistryKey SystemKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM");
                Microsoft.Win32.RegistryKey CurrentControlSetKey = SystemKey.OpenSubKey("CurrentControlSet");
                Microsoft.Win32.RegistryKey ControlKey = CurrentControlSetKey.OpenSubKey("Control");
                Microsoft.Win32.RegistryKey ClassKey = ControlKey.OpenSubKey("Class");
                Microsoft.Win32.RegistryKey WDDMAdaptersKey = ClassKey.OpenSubKey(@"{4d36e968-e325-11ce-bfc1-08002be10318}");
                if (WDDMAdaptersKey != null)
                {
                    foreach (string adapterKeyName in WDDMAdaptersKey.GetSubKeyNames())
                    {
                        try
                        {
                            Microsoft.Win32.RegistryKey WDDMAdapterKey = WDDMAdaptersKey.OpenSubKey(adapterKeyName);
                            string deviceId = getWDDMAdapterDeviceId(WDDMAdapterKey);
                            string openGLDriver = getWDDMAdapterOpenGLDriver(WDDMAdapterKey);
                            if (deviceId != "" && openGLDriver != "")
                            {
                                adapters.Add(new WDDMAdapter(deviceId, openGLDriver));
                            }
                        }
                        catch { }
                    }
                }
            }



            return adapters;

        }
    }
}
