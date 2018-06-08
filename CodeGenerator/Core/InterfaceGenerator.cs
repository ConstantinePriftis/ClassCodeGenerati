using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.DTO;

namespace CodeGenerator.Core
{
    public class InterFaceGenerator : IGenerator
    {
        public InterFaceGenerator(ImportGenerator generator, InterfaceImplementationGenerator implementation, InterfaceDeclarationGenerator declaration)
        {
            Generator = generator;
            Implementation = implementation;
            Declaration = declaration;
        }

        public ImportGenerator Generator { get; }
        public InterfaceImplementationGenerator Implementation { get; }
        public InterfaceDeclarationGenerator Declaration { get; }
        public List<string> CLassLines {
            get;

            set;
        }
        public int GetImplementationIndex()
        {
            int TargetIndex = 0;
            for (int i = 0; i < CLassLines.Count; i++)
            {
                if (CLassLines[i].Contains("End") && CLassLines[i].Contains("Class"))
                    TargetIndex = i;
            }
            return TargetIndex;
        }
        public void GetDeclarationIndex()
        {
            int TargetIndex = 0;
            for (int i = 0; i < CLassLines.Count; i++)
            {
                if (CLassLines[i].Contains("Class") && !CLassLines[i].Contains("End"))
                {
                    foreach (var word in CLassLines[i].Split(' '))
                    {
                        if (word.Equals("Class"))
                            TargetIndex = i;
                    }
                }
            }

            if (CLassLines[TargetIndex + 1].Contains("Inherits"))
                TargetIndex += 2;
        }

        //public IFileReader FileReader { get; }
        //public IFileWriter FileWriter { get; }
        //public string InterFaceImplementationName { get; }
        //private int TargetIndex { get; set; }
        //private List<string> file;
        //public List<string> File {
        //    get {
        //        if (file == null)
        //            file = FileReader.GetFile();

        //        return file;
        //    }
        //}
        //public InterFaceGenerator(string InterFaceImplementationName, IFileReader FileReader, IFileWriter fileWriter)
        //{
        //    if (string.IsNullOrWhiteSpace(InterFaceImplementationName))
        //        throw new InvalidOperationException("Invalid argument InterFaceImplementationName, cannot be Empty, Null Or WhiteSpace!");

        //    this.InterFaceImplementationName = InterFaceImplementationName;
        //    this.FileReader = FileReader;
        //    FileWriter = fileWriter;
        //}

        //public void SetClassIndex()
        //{

        //    for (int i = 0; i < File.Count; i++)
        //    {
        //        if (File[i].Contains("Class"))
        //        {
        //            foreach (var word in File[i].Split(' '))
        //            {
        //                if (word.Equals("Class"))
        //                    TargetIndex = i;
        //            }
        //        }
        //    }

        //    //TargetIndex = File.IndexOf(ClassLine);
        //    if (File[TargetIndex + 1].Contains("Inherits"))
        //        TargetIndex += 2;
        //    else
        //        TargetIndex += 1;
        //}
        //private string GetImplementationName()
        //{
        //    string implementationName = string.Empty;

        //    if (File[TargetIndex].Contains("Implements"))
        //    {
        //        implementationName = "," + InterFaceImplementationName;
        //        File[TargetIndex] += implementationName;
        //    }
        //    else
        //        implementationName = $"Implements {InterFaceImplementationName}";
        //    return implementationName;
        //}
        //private void WriteImplementsDeclarationToFile(string textToWrite)
        //{
        //    if (!File[TargetIndex].Contains(InterFaceImplementationName))
        //    {
        //        if (!File[TargetIndex].Contains("Implements"))
        //            File.Insert(TargetIndex, textToWrite);

        //        FileWriter.WriteFile(File);
        //    }
        //}
        //private void WriteInterfaceImplementationToFile()
        //{
        //    if (!DoesInterFaceImplementationExists())
        //    {
        //        File.InsertRange(GetFunctionIndexToImplement(), GetFunctionList());

        //        FileWriter.WriteFile(File);
        //    }

        //}
        //private bool DoesInterFaceImplementationExists()
        //{
        //    bool Exists = false;
        //    foreach (var line in File)
        //    {
        //        if (line.Contains(GetFunctionList()[0].ToString()))
        //        {
        //            Exists = true;
        //        }
        //    }
        //    return Exists;
        //}
        //public List<string> GetFunctionList()
        //{
        //    List<string> FunctionDeclaration = new List<string>();
        //    string FunctionIdentity = "Public Function GetCompanyID() As Integer? Implements ICompanyIDLoggable.GetCompanyID";
        //    string FunctionBehaviour = "throw new NotImplementedException();";
        //    string FunctionEnd = "End Function";
        //    FunctionDeclaration.Add(FunctionIdentity);
        //    FunctionDeclaration.Add("       " + FunctionBehaviour);
        //    FunctionDeclaration.Add(FunctionEnd);

        //    return FunctionDeclaration;
        //}
        //public int GetFunctionIndexToImplement()
        //{
        //    string EndClassLine = File.First(l => l.Equals("End Class"));
        //    int NeededIndex = File.IndexOf(EndClassLine);
        //    return NeededIndex - 2;
        //}

        //public void Generate()
        //{
        //    //string InterFaceImplementation = $"Implements {InterFaceImplementationName}";
        //    SetClassIndex();
        //    WriteImplementsDeclarationToFile(GetImplementationName());
        //    WriteInterfaceImplementationToFile();
        //}
        public void Generate()
        {
            Declaration.Generate();
            Generator.Generate();
            Implementation.Generate();
        }
    }
}
