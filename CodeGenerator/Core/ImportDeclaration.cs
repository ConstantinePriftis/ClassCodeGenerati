using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class ImportDeclaration
    {
        public int Line { get; }
        public string NameSpace { get; }

        public ImportDeclaration(int line, string nameSpace)
        {
            if (line < 0)
                throw new InvalidOperationException("Invalid argument Line, value cannot be less than zero.");

            if (string.IsNullOrWhiteSpace(nameSpace))
                throw new InvalidOperationException("Invalid argument nameSpace, cannot be Empty, Null Or WhiteSpace!");

            if(nameSpace.Contains("Imports"))
                NameSpace = nameSpace.Split(' ').Last();
            else
                NameSpace = nameSpace;

            Line = line;
        }
        public ImportDeclaration(string nameSpace) : this(0, nameSpace)
        {

        }
        public ImportDeclaration FromLine(int line)
        {
            return new ImportDeclaration(line, NameSpace);
        }

        public static bool operator ==(ImportDeclaration c1, ImportDeclaration c2)
        {
            return c1.NameSpace.Equals(c2.NameSpace);
        }
        public static bool operator !=(ImportDeclaration c1, ImportDeclaration c2)
        {
            return !c1.NameSpace.Equals(c2.NameSpace);
        }

        public override string ToString()
        {
            return $"Imports {NameSpace}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is ImportDeclaration))
                return false;

            ImportDeclaration other = obj as ImportDeclaration;
            return other == this;
        }
        public override int GetHashCode()
        {
            return this.NameSpace.GetHashCode();
        }
    }
}
