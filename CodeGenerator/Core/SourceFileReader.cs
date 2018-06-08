using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace CodeGenerator.Core
{
    public class SourceFileReader : IFileReader
    {
        public SourceFileReader(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public List<string> GetFile()
        {
            //if (!File.Exists(Path))
            //{
            //    throw new FileNotFoundException("File does not exist");
            //}
            return File.ReadAllLines(Path).ToList();
        }


    }
}
