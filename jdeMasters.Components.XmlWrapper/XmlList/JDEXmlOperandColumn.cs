using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlOperandColumn))]
    [XmlInclude(typeof(JDEXmlColumn))]
    [XmlInclude(typeof(JDEXmlOperand))]

    [KnownType(typeof(JDEXmlOperandColumn))]
    [KnownType(typeof(JDEXmlColumn))]
    [KnownType(typeof(JDEXmlOperand))]
    public sealed class JDEXmlOperandColumn: JDEXmlOperand
    {
        [XmlElement("COLUMN")]
        public JDEXmlColumn Column { get; set; }

        public JDEXmlOperandColumn(): base()
        {
            Column = new JDEXmlColumn();
        }
    }
}
