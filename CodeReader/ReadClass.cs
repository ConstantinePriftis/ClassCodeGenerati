using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CodeGenerator;
namespace CodeReader
{
    public class ReadClass
    {
        string path = @"C:\Users\k.priftis.PROSVASISHQ\source\repos\CaseStudies\ClassCodeGeneration\CodeGenerator\bin\Debug\CodeGenerator.dll";
        CodeGenerator.Customer customer1 = new Customer();

        private System.Reflection.Assembly LoadAssembly()
        {
            return Assembly.LoadFrom(path);
        }

        
    }
}
