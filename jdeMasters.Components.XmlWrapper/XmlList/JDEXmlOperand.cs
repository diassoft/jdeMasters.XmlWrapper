using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlOperand))]
    [KnownType(typeof(JDEXmlOperand))]

    [XmlRoot("OPERAND")]
    public abstract class JDEXmlOperand
    {
        public JDEXmlOperand()
        {

        }
    }
}
