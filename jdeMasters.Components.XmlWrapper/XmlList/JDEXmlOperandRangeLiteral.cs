using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlOperandRangeLiteral))]
    [XmlInclude(typeof(JDEXmlJDEValuedField))]
    [XmlInclude(typeof(JDEXmlOperand))]

    [KnownType(typeof(JDEXmlOperandRangeLiteral))]
    [KnownType(typeof(JDEXmlJDEValuedField))]
    [KnownType(typeof(JDEXmlOperand))]
    public sealed class JDEXmlOperandRangeLiteral
    {
        [XmlElement("LITERAL_FROM")]
        public JDEXmlJDEValuedField LiteralFrom { get; set; }

        [XmlElement("LITERAL_TO")]
        public JDEXmlJDEValuedField LiteralTo { get; set; }

        public JDEXmlOperandRangeLiteral()
        {
            LiteralFrom = new JDEXmlJDEValuedField();
            LiteralTo = new JDEXmlJDEValuedField();
        }
    }
}
