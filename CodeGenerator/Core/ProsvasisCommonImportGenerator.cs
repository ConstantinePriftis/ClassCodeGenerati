using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class ProsvasisCommonImportGenerator : ImportGenerator
    {

        public ProsvasisCommonImportGenerator(IFileReader reader, IFileWriter writer) : base("Prosvasis.Common",reader,writer)
        {

        }
    }
}
