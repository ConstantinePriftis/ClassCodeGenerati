using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class MetadataTypeAttributeGenerator : MetadataGenerator
    {
        public string MetadataClassName { get; private set; }
        public IFileWriter FileWriter { get; }

        public MetadataTypeAttributeGenerator(string MetadataClassName, IFileReader fileReader, IFileWriter fileWriter) : base(fileReader)
        {
            this.MetadataClassName = MetadataClassName;
            FileWriter = fileWriter;
            if (string.IsNullOrEmpty(MetadataClassName))
                throw new NotImplementedException("Invariant what if the FrienlyName is empty or null?");
        }
        protected override void GenerateMetaData()
        {
            string metaData = $@"<System.ComponentModel.DataAnnotations.MetadataType(GetType(""{MetadataClassName}""))>";

            int classIndex = base.GetClassDeclarationIndex();
            if (!base.File.Contains(metaData))
            {
                base.File.Insert(classIndex, metaData);
                FileWriter.WriteFile(base.File);
            }
        }
    }
}
