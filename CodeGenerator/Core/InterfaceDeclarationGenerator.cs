using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class InterfaceDeclarationGenerator : IGenerator

    {
        public InterfaceDeclarationGenerator(string interfaceName, IFileReader fileReader, IFileWriter fileWriter)
        {
            InterfaceName = interfaceName;
            FileReader = fileReader;
            FileWriter = fileWriter;
        }

        public string InterfaceName { get; }
        private int TargetIndex { get; set; }
        public IFileReader FileReader { get; }
        public IFileWriter FileWriter { get; }


        public List<string> File {
            get {
                if (FileReader.GetFile() == null)
                    this.File = FileReader.GetFile();

                return File;
            }
            set { this.File = FileReader.GetFile(); }
        }

        /*Sets Index for the InterFace Declaration*/
        public void SetDeclarationIndex()
        {
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
        }

        /*Decides if it should append 
         * already implemented interfaces
         Or create new ones*/
        private string GetImplementationString()
        {
            string implementationName = string.Empty;

            if (File[TargetIndex].Contains("Implements") && !DeclarationExists())
            {
                implementationName = "," + InterfaceName;
                File[TargetIndex] += implementationName;
            }
            else
                implementationName = $"Implements {InterfaceName}";
            return implementationName;
        }

        /*Checking Each line inside File 
        To ensure Interface is not already declared*/
        private bool DeclarationExists()
        {
            bool exists = false;

            foreach (var line in File)
            {
                if (line.Contains(InterfaceName))
                    exists = true;
            }
            return exists;
        }

        /*Writing changes to file
         After validating some Invariants*/
        private void WriteInterfaceDeclarationToFile(string textToWrite)
        {
            if (!File[TargetIndex].Contains("Implements")
            && !DeclarationExists() && !File[TargetIndex].Contains("End"))
                File.Insert(TargetIndex + 1, textToWrite);
        }
        /**/
        public void Generate()
        {
            SetDeclarationIndex();
            WriteInterfaceDeclarationToFile(GetImplementationString());
            FileWriter.WriteFile(File);
        }
    }
}
