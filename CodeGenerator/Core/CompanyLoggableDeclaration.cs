using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class CompanyLoggableDeclaration : InterfaceDeclarationGenerator
    {
        public CompanyLoggableDeclaration(string interfaceName, IFileReader fileReader, IFileWriter fileWriter) : 
            base(interfaceName, fileReader, fileWriter)
        {

        }
    }
}
