using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator;
using CodeGenerator.Core;
using CodeGenerator.DTO;
using Reflector.Core;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\k.priftis.PROSVASISHQ\Desktop\data\ApplicationModule.vb";

            IFileReader reader = new SourceFileReader(PathProvider.GetPath());
            IFileWriter writer = new SourceFileWriter(PathProvider.GetPath());

            int x = GeneratorUtility.GetClassDeclarationIndex();
            int y = GeneratorUtility.GetInterfaceDeclarationIndex();
            int f = GeneratorUtility.GetInterfaceIndexToImplement();

            List<IGenerator> generators = new List<IGenerator>()
            {
                new InterFaceGenerator(new ImportGenerator("Prosvasis.Common",reader,writer),new companyLoggableImplementation(reader,writer),new InterfaceDeclarationGenerator("ICompanyLoggable",reader,writer)),
                //new ProsvasisCommonImportGenerator(reader,writer),
                new ImportGenerator("Chrysikos",reader,writer),
                new EntityLogGenerator("Kwstas",reader,writer),
            };
            new CompanyLoggableDeclaration("dkfjvnkjf", reader, writer);
            ClassTranformer tranformer = new ClassTranformer(generators);
            tranformer.Transform();
        }
        public static CodeGenerator.DTO.ClassInfo toClassInfo(Reflector.DTO.ClassInfo classInfo)
        {
            return new ClassInfo()
            {
                ClassName = classInfo.ClassName,
                Properties = toEnumerablePropertyInfo(classInfo.Properties).ToList()
            };
        }
        public static CodeGenerator.DTO.PropertyInfo toPropertyInfo(Reflector.DTO.PropertyInfo propertyinfo)
        {
            return new PropertyInfo()
            {
                Name = propertyinfo.Name,
                Type = propertyinfo.Type
            };
        }
        public static IEnumerable<CodeGenerator.DTO.PropertyInfo> toEnumerablePropertyInfo(IEnumerable<Reflector.DTO.PropertyInfo> source)
        {
            foreach (var item in source)
            {
                yield return toPropertyInfo(item);
            }
        }
    }
}
