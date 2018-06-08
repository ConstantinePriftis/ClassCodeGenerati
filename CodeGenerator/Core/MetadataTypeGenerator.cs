using CodeGenerator.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextTemplating;
using System.CodeDom;

namespace CodeGenerator.Core
{
    public class MetadataTypeGenerator
    {
        public MetadataTypeGenerator(ClassInfo classInfo, string path)
        {
            ClassInfo = classInfo;
            if (!Directory.Exists(path))
                throw new InvalidOperationException("Path is invalid.");
            Path = path;
        }

        public ClassInfo ClassInfo { get; }
        public string Path { get; }

        public void Generate()
        {
            MetadataTypeTextTemplate template = new MetadataTypeTextTemplate();
            template.Session = new TextTemplatingSession();
            template.Session["classinfo"] = ClassInfo;
            template.Initialize();
            File.WriteAllText($"{Path}\\{ClassInfo.ClassName}.cs", template.TransformText());
        }
    }
}
