using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeGenerator
{
    public class PathProvider : IFileReader
    {
        private static string Path { get; set; }
        private static void initialize()
        {
            Path = @"C:\Users\k.priftis.PROSVASISHQ\Desktop\data\ApplicationModule.vb";
        }

        public static string GetPath()
        {
            initialize();
            return Path;
        }
        public List<string> GetFile()
        {
            if (!string.IsNullOrWhiteSpace(Path))
            {
                if (File.Exists(Path))
                {
                    if (Path.Split('.').Last() != "vb" && Path.Split('.').Last() != "cs")
                        throw new FileNotFoundException("Not a valid source file");
                }
            }
            
            return File.ReadAllLines(GetPath()).ToList();
        }
    }
}
