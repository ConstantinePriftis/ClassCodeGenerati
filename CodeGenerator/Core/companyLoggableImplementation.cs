using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class companyLoggableImplementation : InterfaceImplementationGenerator
    {
        public companyLoggableImplementation(IFileReader fileReader, IFileWriter fileWriter)
            : base(fileReader, fileWriter)
        {
            FileWriter = fileWriter;
        }

        public IFileWriter FileWriter { get; }

        private string FunctionIdentity = "Public Function GetCompanyID() As Integer? Implements ICompanyIDLoggable.GetCompanyID";

        private string InterFaceDeclaration = "ICompanyLoggable";

        /*Returns The Function to implement inside the specified Class*/
        public StringBuilder GetFunctionImplementationBlock()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Public Function GetCompanyID() As Integer? Implements ICompanyIDLoggable.GetCompanyID");
            stringBuilder.AppendLine("          throw new NotImplementedException()");
            stringBuilder.AppendLine("End Function");
            return stringBuilder;
        }

        /*Returns the Index to Generate the Function Implementation*/
        public override int GetIndexToImplement()
        {
            int TargetIndex = 0;
            for (int i = 0; i < File.Count; i++)
            {
                if (File[i].Contains("End") && File[i].Contains("Class"))
                    TargetIndex = i;
            }
            int Anotherindex = GeneratorUtility.GetInterfaceIndexToImplement();
            return TargetIndex;
        }

        /*Checks Class if an Implementation
         has already been implemented*/
        public bool CheckIfImplementationExists()
        {
            bool Exists = false;

            for (int i = 0; i < File.Count; i++)
            {
                if (File[i].Contains(FunctionIdentity))
                    Exists = true;
            }
            return Exists;
        }

        /*Checks the Class if an Interface declaration
         is Made. If interface is declared it returns true
         and it proceeds to implementation*/
        public bool InterfaceExists()
        {
            bool Exists = false;
            foreach (var line in File)
            {
                if (line.Contains(InterFaceDeclaration))
                    Exists = true;
            }
            return Exists;
        }

        /*Checks some invariants and then
         proceeds to generate Implementation*/
        protected override void GenerateImplementation()
        {
            int ClassIndexToImplement = GetIndexToImplement();
            StringBuilder InterfaceImplementationFunction = GetFunctionImplementationBlock();
            bool MethodExists = CheckIfImplementationExists();
            bool DeclarationExists = InterfaceExists();
            if (!MethodExists && InterfaceExists())
            {
                File.Insert(ClassIndexToImplement, InterfaceImplementationFunction.ToString());
                FileWriter.WriteFile(File);
            }
        }
    }
}

