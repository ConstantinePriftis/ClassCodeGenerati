using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeGenerator.Core
{
    public class GeneratorUtility
    {

        static int TargetIndex;

        public static List<string> File { get; set; }

        public GeneratorUtility()
        {

        }
        private static void InitializeGeneratorProvider()
        {
            PathProvider provider = new PathProvider();
            File = provider.GetFile();
        }

        public static int GetClassDeclarationIndex()
        {
            InitializeGeneratorProvider();
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

        public static int GetInterfaceDeclarationIndex()
        {
            InitializeGeneratorProvider();
            TargetIndex = 0;
            for (int i = 0; i < File.Count; i++)
            {
                if (File[i].Contains("Class") && !File[i].Contains("End"))
                {
                    foreach (var word in File[i].Split(' '))
                    {
                        if (word.Equals("Class"))
                            TargetIndex = i;
                    }
                }
            }
            if (File[TargetIndex + 1].Contains("Inherits"))
                TargetIndex += 2;

            return TargetIndex;
        }

        public static int GetInterfaceIndexToImplement()
        {
            InitializeGeneratorProvider();
            TargetIndex = 0;
            for (int i = 0; i < File.Count; i++)
            {
                if (File[i].Contains("End") && File[i].Contains("Class"))
                    TargetIndex = i;
            }
            return TargetIndex;
        }


    }
}
