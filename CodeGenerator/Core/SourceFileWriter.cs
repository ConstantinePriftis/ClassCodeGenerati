using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class SourceFileWriter : IFileWriter
    {
        public SourceFileWriter(string path )
        {
            Path = path;
        }

        public string Path { get; }

        public void WriteFile(List<string> sourceCode)
        {
            File.WriteAllLines(Path, sourceCode);
        }
    }
}
