using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeGenerator.Core
{
    public class EntityLogGenerator : MetadataGenerator
    {
        public string FriendlyName { get; private set; }

        public IFileWriter FileWriter { get; }

        public EntityLogGenerator(string FriendlyName, IFileReader fileReader, IFileWriter fileWriter) : base(fileReader)
        {
            this.FriendlyName = FriendlyName;
            FileWriter = fileWriter;
            if (string.IsNullOrEmpty(FriendlyName))
                throw new NotImplementedException("Invariant what if the FrienlyName is empty or null?");
        }
        
        
        /*Checks if specified Metadata exists
         And if not it then procceeds to Generate it*/
        protected override void GenerateMetaData()
        {
            string metaData = $@"<EntityLog(FriendlyName:= ""{FriendlyName}"")>";

            int classIndex = base.GetClassDeclarationIndex();

            if (!base.File.Contains(metaData))
            {
                base.File.Insert(classIndex, metaData);
                FileWriter.WriteFile(base.File);
            }
        }
    }
}
