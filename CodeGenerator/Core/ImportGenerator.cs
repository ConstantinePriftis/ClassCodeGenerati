using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.DTO;

namespace CodeGenerator.Core
{
    public class ImportGenerator : IGenerator
    {
        public IFileWriter FileWriter { get; }
        private ImportDeclaration ImportDeclaration { get; set; }
        public IFileReader FileReader { get; }
        private List<ImportDeclaration> DeclaredNamespaces { get; set; }
        private int FirstDeclarationLine { get { if (DeclaredNamespaces.Count > 0) return DeclaredNamespaces.First().Line;  else return 0;  } }
        private int LastDeclarationLine { get { if (DeclaredNamespaces.Count > 0) return DeclaredNamespaces.Last().Line; else return 0; } }

        private List<string> file;
        public ImportGenerator(string @namespace, IFileReader FileReader, IFileWriter fileWriter)
        {
            ImportDeclaration = new ImportDeclaration(@namespace);
            this.FileReader = FileReader;
            this.FileWriter = fileWriter;
            this.DeclaredNamespaces = new List<ImportDeclaration>();
        }

        public List<string> File {
            get {
                if (file == null)
                    file = FileReader.GetFile();

                return file;
            }
        }
        private void ParseImportDeclarations()
        {
            for (int i = 0; i < File.Count; i++)
            {
                int lineIndexer = i;
                string line = File[i];
                ImportDeclaration importDeclaration = null;
                try
                {
                    if (line.Contains("Imports"))
                        importDeclaration = new ImportDeclaration(lineIndexer, line);
                    else
                        continue;
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
                DeclaredNamespaces.Add(importDeclaration);
            }
        }
        private bool IsNamespaceDeclared()
        {
            return DeclaredNamespaces.Any(d => d == ImportDeclaration);
        }
        private void SetImportDeclarationToLastLine()
        {
            this.ImportDeclaration = this.ImportDeclaration.FromLine(LastDeclarationLine + 1);
        }
        private void SetImportDeclarationToFirstLine()
        {
            this.ImportDeclaration = this.ImportDeclaration.FromLine(FirstDeclarationLine);
        }
        private void WriteToFile(ImportDeclaration importDeclaration)
        {
            File.Insert(ImportDeclaration.Line, ImportDeclaration.ToString());
            FileWriter.WriteFile(File);
        }
        public void Generate()
        {
            ParseImportDeclarations();
            if (IsNamespaceDeclared())
                return;
            SetImportDeclarationToFirstLine();
            WriteToFile(ImportDeclaration);
        }
    }
}
