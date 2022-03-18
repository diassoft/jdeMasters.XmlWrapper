using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    [DataContract]
    public sealed class JDEXmlTableDataColumn
    {
        [XmlAttribute("ALIAS")]
        [DataMember]
        public string Alias { get; set; }

        [XmlText]
        [DataMember]
        public string Value { get; set; }

        public JDEXmlTableDataColumn()
        {
            Alias = "";
            Value = "";
        }

        public JDEXmlTableDataColumn(string alias, string value)
        {
            Alias = alias;
            Value = value;
        }
    }
}
