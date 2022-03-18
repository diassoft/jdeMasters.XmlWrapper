using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlOperandList))]
    [XmlInclude(typeof(JDEXmlJDEValuedField))]
    [XmlInclude(typeof(JDEXmlOperand))]

    [KnownType(typeof(JDEXmlOperandList))]
    [KnownType(typeof(JDEXmlJDEValuedField))]
    [KnownType(typeof(JDEXmlOperand))]
    public sealed class JDEXmlOperandList: JDEXmlOperand
    {
        [XmlArray("LIST")]
        [XmlArrayItem("LITERAL")]
        public List<JDEXmlJDEValuedField> List { get; set; }

        public JDEXmlOperandList(): base()
        {
            List = new List<JDEXmlJDEValuedField> ();
        }
    }
}
