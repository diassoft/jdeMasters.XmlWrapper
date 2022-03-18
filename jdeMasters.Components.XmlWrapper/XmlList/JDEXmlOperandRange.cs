using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlOperandRange))]
    [XmlInclude(typeof(JDEXmlOperandRangeLiteral))]
    [XmlInclude(typeof(JDEXmlOperand))]

    [KnownType(typeof(JDEXmlOperandRange))]
    [KnownType(typeof(JDEXmlOperandRangeLiteral))]
    [KnownType(typeof(JDEXmlOperand))]
    public sealed class JDEXmlOperandRange: JDEXmlOperand
    {
        [XmlElement("RANGE")]
        public JDEXmlOperandRangeLiteral Range { get; set; }

        public JDEXmlOperandRange(): base()
        {
            Range = new JDEXmlOperandRangeLiteral();
        }
    }


}
