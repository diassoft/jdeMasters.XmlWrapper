using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlJDEValuedField))]
    [XmlInclude(typeof(JDEXmlOperand))]

    [KnownType(typeof(JDEXmlJDEValuedField))]
    [KnownType(typeof(JDEXmlOperand))]
    public sealed class JDEXmlOperandLiteral: JDEXmlOperand
    {
        [XmlElement("LITERAL")]
        public JDEXmlJDEValuedField Value { get; set; }

        public JDEXmlOperandLiteral(): base()
        {
            Value = new JDEXmlJDEValuedField();
        }

        public JDEXmlOperandLiteral(JDEXmlJDEValuedField value): base()
        {
            Value = value;
        }

        //public JDEXmlOperandLiteral(Utils.JDEValue value): base()
        //{
        //    Value = value;
        //}

    }
}
