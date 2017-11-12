using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.Drawing.Vulkan
{
    class Manifest
    {
        string _LibraryPath = "";
        public string LibraryPath { get { return _LibraryPath; } }

        public Manifest(string File)
        {
            string manifestPath = System.IO.Path.GetDirectoryName(File);
            manifestPath = System.IO.Path.GetFullPath(manifestPath);

            JSON.Value value = JSON.Parse(System.IO.File.ReadAllText(File));
            if (value is JSON.Object)
            {
                JSON.Object obj = value as JSON.Object;
                JSON.Object icd = value as JSON.Object;

                if (obj["ICD"] != null) { icd = obj["ICD"] as JSON.Object; }
                else if (obj["icd"] != null) { icd = obj["icd"] as JSON.Object; }

                if (icd != null)
                {
                    if (icd["library_path"] != null)
                    {
                        JSON.String str = icd["library_path"] as JSON.String;
                        string path = "";

                        try
                        {
                            path = System.IO.Path.GetFullPath(manifestPath + str.Value);
                            if (System.IO.File.Exists(path)) { _LibraryPath = path; }
                        }
                        catch { }

                        try
                        {
                            path = System.IO.Path.GetFullPath(str.Value);
                            if (System.IO.File.Exists(path)) { _LibraryPath = path; }
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
