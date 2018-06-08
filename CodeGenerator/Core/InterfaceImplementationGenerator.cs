using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public abstract class InterfaceImplementationGenerator : IGenerator
    {
        public InterfaceImplementationGenerator(IFileReader fileReader, IFileWriter fileWriter)
        {
            FileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        private List<string> file;
        private readonly IFileWriter fileWriter;
        public List<string> File {
            get {
                if (file == null)
                    file = FileReader.GetFile();

                return file;
            }
        }

        public List<string> interfaceToImplement { get; }
        public IFileReader FileReader { get; }

        public abstract int GetIndexToImplement();
        protected abstract void GenerateImplementation();
        public void Generate()
        {
            GenerateImplementation();
        }
    }
}
