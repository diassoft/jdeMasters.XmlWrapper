using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    [XmlRoot("genericField")]
    public class JDEXmlValuedField<T>
    {
        [XmlAttribute("VALUE")]
        public virtual T Value { get; set; }

        public bool ShouldSerializeValue() { return true; }

        public JDEXmlValuedField()
        {

        }

        public JDEXmlValuedField(T value): this()
        {
            Value = value;
        }
    }

}
