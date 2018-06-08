using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeGenerator
{
    public class ClassTranformer
    {
        public List<IGenerator> Generators { get; }
        public ClassTranformer(List<IGenerator> generators)
        {
            Generators = generators;
        }

        public void Transform()
        {
            foreach (var generator in Generators)
            {
                generator.Generate();
            }
        }
    }
}
