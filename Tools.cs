using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FirefoxMissingCertMimeTypePatcher
{
    class Tools
    {
        public static string GetFirefoxProfilePath()
        {
            string apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string mozilla = Path.Combine(apppath, "Mozilla");

            bool exist = Directory.Exists(mozilla);

            if (exist)
            {

                string firefox = Path.Combine(mozilla, "firefox");

                if (Directory.Exists(firefox))
                {
                    string prof_file = Path.Combine(firefox, "profiles.ini");

                    bool file_exist = File.Exists(prof_file);

                    if (file_exist)
                    {
                        StreamReader rdr = new StreamReader(prof_file);

                        string resp = rdr.ReadToEnd();

                        string[] lines = resp.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                        string location = lines.First(x => x.Contains("Path=")).Split(new string[] { "=" }, StringSplitOptions.None)[1];

                        string prof_dir = Path.Combine(firefox, location);

                        return prof_dir;
                    }
                }
            }
            return "";
        }

        public static string GetMimeTypesRdfPath()
        {
            return GetFirefoxProfilePath() + @"\mimeTypes.rdf";
        }

        public static bool MimeTypesRdfExist()
        {
            return File.Exists(GetMimeTypesRdfPath());
        }

        public static string GetMimeTypesRdfText()
        {
            return File.ReadAllText(GetMimeTypesRdfPath());
        }

        public static void CreateBackup()
        {
            File.Copy(GetMimeTypesRdfPath(), GetMimeTypesRdfPath() + ".bak", true);
        }
    }
}
