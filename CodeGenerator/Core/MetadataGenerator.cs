using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public abstract class MetadataGenerator : IGenerator
    {
        public MetadataGenerator(IFileReader fileReader)
        {
            FileReader = fileReader;
        }
        public IFileReader FileReader { get; }

        private List<string> file;
        public List<string> File 
        {
            get 
            {
                if (file == null)
                    file = FileReader.GetFile();

                return file;
            }
        }
        protected int GetClassDeclarationIndex()
        {
            int ClassDeclarationIndex = 0;
            for (int i = 0; i < File.Count; i++)
            {
                if (File[i].Contains("Class"))
                {
                    foreach (var word in File[i].Split(' ').ToList())
                    {
                        if (word == "Class" && !File[i].Contains("End"))
                            ClassDeclarationIndex = i;
                    }
                }
            }
            return ClassDeclarationIndex;
        }
        protected abstract void GenerateMetaData();
         
        public void Generate()
        {
            GenerateMetaData();
        }
    }
}
