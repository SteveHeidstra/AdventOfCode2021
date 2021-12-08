using System.IO;
using Newtonsoft.Json;

namespace Kerstpuzzel
{
    public static class BestandHelper
    {
        public static string ApplicationPath = @"D:\Temp";
                
        public static void SaveObject<T>(T obj, string filename)
        {
            File.WriteAllText(Path.Combine(ApplicationPath, filename + ".txt"), JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        public static T LoadObject<T>(string filename)
        {
            var settings = new JsonSerializerSettings();
            
            T obj = JsonConvert.DeserializeObject<T>(
                File.ReadAllText(sanitizePath(filename)), settings);

            return obj;
        }

        private static string sanitizePath(string filename)
        {
            string extentie = filename.Contains(".") ? "" : ".txt";

            return Path.Combine(ApplicationPath, filename + extentie);
        }

        public static string[] Readfile(string filename)
        {
            string[] lines = File.ReadAllLines(sanitizePath(filename));
            return lines;
        }
    }
}
