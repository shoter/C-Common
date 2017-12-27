using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Xml
{
    public class KeyWithType
    {
        public string Key { get; set; }
        [XmlIgnore]
        public Type Type => Type.GetType(AssemblyQualifiedName);

        public string AssemblyQualifiedName { get; set; }

        public KeyWithType() { }
        public KeyWithType(string key, Type type)
        {
            Key = key;
            AssemblyQualifiedName = type.AssemblyQualifiedName;

        }
    }
}
