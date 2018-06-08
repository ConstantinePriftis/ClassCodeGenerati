using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeGenerator.DTO
{
    public class ClassInfo
    {
        public ClassInfo()
        {
            this.Properties = new List<PropertyInfo>();
        }
        public string ClassName { get; set; }

        public List<PropertyInfo> Properties { get; set; }
    }
}
