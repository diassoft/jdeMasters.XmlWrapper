using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    public class JDEXmlTypedField<T>
    {
        [XmlAttribute("TYPE")]
        public T Type { get; set; }

        public JDEXmlTypedField()
        {

        }

        public JDEXmlTypedField(T type): this()
        {
            Type = type;
        }
    }

}
