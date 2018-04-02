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

        IntPtr _VkDriverLibrary = new IntPtr(0);
        IntPtr _VkGetInstanceProcAddr_ptr = new IntPtr(0);
        delegate IntPtr vkGetInstanceProcAddr_func(IntPtr vkInstance, string Name);
        vkGetInstanceProcAddr_func _vkGetInstanceProcAddr_del;

        Manifest _VkManifest = null;

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
                if (_VkDriverLibrary.ToInt64() == 0)
                {
                    if (_VkManifest != null && _VkManifest.LibraryPath != "")
                    {
                        _VkDriverLibrary = LoadLibrary(_VkManifest.LibraryPath);
                    }
                }

                if (_VkDriverLibrary.ToInt64() == 0)
                {
                    _VkDriverLibrary = LoadLibrary(_OpenGLDriver); if (_VkDriverLibrary.ToInt64() == 0) { return default(DelegateType); }
                }

                if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0)
                {
                    _VkGetInstanceProcAddr_ptr = GetProcAddress(_VkDriverLibrary, "vkGetInstanceProcAddr");
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0) { _VkGetInstanceProcAddr_ptr = GetProcAddress(_VkDriverLibrary, "vk_GetInstanceProcAddr"); }
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() == 0) { _VkGetInstanceProcAddr_ptr = GetProcAddress(_VkDriverLibrary, "vk_icdGetInstanceProcAddr"); }
                    if (_VkGetInstanceProcAddr_ptr.ToInt64() != 0)
                    {
                        _vkGetInstanceProcAddr_del = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<vkGetInstanceProcAddr_func>(_VkGetInstanceProcAddr_ptr);
                    }
                }
                return System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<DelegateType>(_vkGetInstanceProcAddr_del(vkInstance, functionName));
            }
        }

        public WDDMAdapter(string DeviceId, string OpenGLDriver, Manifest vulkanManifest)
        {
            _OpenGLDriver = OpenGLDriver;
            _VkManifest = vulkanManifest;
            _DeviceId = DeviceId;
        }

        static string[] getVulkanDrivers()
        {
            HashSet<string> drivers = new HashSet<string>();
            foreach (WDDMAdapter adapter in getWDDMAdapters())
            {
                drivers.Add(adapter._OpenGLDriver);
            }
            
            // Last chance if we have found nothing go with the system loader
            if (drivers.Count == 0)
            {
                if (System.IO.File.Exists("C:\\Windows\\System32\\vulkan-1.dll"))
                {
                    drivers.Add("C:\\Windows\\System32\\vulkan-1.dll");
                }
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

        static Manifest[] getWDDMAdapterVulkanDriverManifests(Microsoft.Win32.RegistryKey WDDMAdapterKey)
        {
            string[] files = getWDDMAdapterVulkanDriverManifestsFiles(WDDMAdapterKey);
            List<Manifest> parsedManifest = new List<Manifest>();
            foreach (string manifestFile in files)
            {
                parsedManifest.Add(new Manifest(manifestFile));
            }
            return parsedManifest.ToArray();
        }

        static string[] getWDDMAdapterVulkanDriverManifestsFiles(Microsoft.Win32.RegistryKey WDDMAdapterKey)
        {
            List<string> manifests = new List<string>();
            if (WDDMAdapterKey == null) { return new string[0]; }
            try
            {
                try
                {
                    if (!System.Environment.Is64BitProcess)
                    {
                        string vkDriverName = getStringValue(WDDMAdapterKey, "VulkanDriverNameWoW").Trim();
                        if (!vkDriverName.ToLower().EndsWith(".json")) { vkDriverName += ".json"; }
                        if (vkDriverName != "")
                        {
                            try { if (System.IO.File.Exists("C:/Windows/Syswow64/" + vkDriverName)) { manifests.Add("C:/Windows/Syswow64/" + vkDriverName); return manifests.ToArray(); } } catch { }
                            try { if (System.IO.File.Exists("C:/Windows/System32/" + vkDriverName)) { manifests.Add("C:/Windows/System32/" + vkDriverName); return manifests.ToArray(); } } catch { }
                            try { if (System.IO.File.Exists(vkDriverName)) { manifests.Add(vkDriverName); return manifests.ToArray(); } } catch { }
                        }
                    }
                }
                catch { }

                {
                    string vkDriverName = ((string[])WDDMAdapterKey.GetValue("VulkanDriverName"))[0].Trim();
                    if (!vkDriverName.ToLower().EndsWith(".json")) { vkDriverName += ".json"; }
                    if (vkDriverName != "")
                    {
                        try { if (System.IO.File.Exists("C:/Windows/System32/" + vkDriverName)) { manifests.Add("C:/Windows/System32/" + vkDriverName); return manifests.ToArray(); } } catch { }
                        try { if (System.IO.File.Exists(vkDriverName)) { manifests.Add(vkDriverName); return manifests.ToArray(); } } catch { }
                    }
                }
            }
            catch { }


            // If the WDDM Adapter has no specified vulkan driver key we will look at the system wide key

            try
            {
                Microsoft.Win32.RegistryKey SoftwareKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE");
                string driver = "";

                if (!System.Environment.Is64BitProcess)
                {
                    try
                    {
                        Microsoft.Win32.RegistryKey WOWKey = SoftwareKey.OpenSubKey("WOW6432Node");
                        Microsoft.Win32.RegistryKey KhronosKey = WOWKey.OpenSubKey("Khronos");
                        if (KhronosKey != null)
                        {
                            Microsoft.Win32.RegistryKey VulkanKey = KhronosKey.OpenSubKey("Vulkan");
                            if (VulkanKey != null)
                            {
                                Microsoft.Win32.RegistryKey DriversKey = VulkanKey.OpenSubKey("Drivers");
                                foreach (string key in DriversKey.GetValueNames())
                                {
                                    if (System.IO.File.Exists(key))
                                    {
                                        try
                                        {
                                            if ((int)DriversKey.GetValue(key) == 0)
                                            {
                                                manifests.Add(key);
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                DriversKey.Close();
                                VulkanKey.Close();
                            }
                            KhronosKey.Close();
                        }
                        WOWKey.Close();
                    }
                    catch { }
                }

                if (manifests.Count == 0)
                {
                    try
                    {
                        Microsoft.Win32.RegistryKey KhronosKey = SoftwareKey.OpenSubKey("Khronos");
                        if (KhronosKey != null)
                        {
                            Microsoft.Win32.RegistryKey VulkanKey = KhronosKey.OpenSubKey("Vulkan");
                            if (VulkanKey != null)
                            {
                                Microsoft.Win32.RegistryKey DriversKey = VulkanKey.OpenSubKey("Drivers");
                                foreach (string key in DriversKey.GetValueNames())
                                {
                                    if (System.IO.File.Exists(key))
                                    {
                                        try
                                        {
                                            if ((int)DriversKey.GetValue(key) == 0)
                                            {
                                                manifests.Add(key);
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                DriversKey.Close();
                                VulkanKey.Close();
                            }
                            KhronosKey.Close();
                        }
                    }
                    catch { }
                }
                SoftwareKey.Close();
            }
            catch { }

            return manifests.ToArray();
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
                            Manifest[] vulkanDriverManifests = getWDDMAdapterVulkanDriverManifests(WDDMAdapterKey);

                            if (deviceId != "" && (openGLDriver != "" || vulkanDriverManifests.Length > 0))
                            {
                                Manifest manifest = null;
                                // For now pick the first manifest. Ultimatly we might preffer the one that is in the driver store and math the adapter driver
                                if (vulkanDriverManifests.Length >= 1)
                                {
                                    manifest = vulkanDriverManifests[0];
                                }

                                adapters.Add(new WDDMAdapter(deviceId, openGLDriver, manifest));
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
