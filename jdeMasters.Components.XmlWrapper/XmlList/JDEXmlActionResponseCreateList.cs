using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlActionResponseCreateList))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlActionResponseCreateList))]
    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]
    public sealed class JDEXmlActionResponseCreateList: JDEXmlAction
    {
        [XmlElement("HANDLE")]
        public string Handle { get; set; }
        public bool ShouldSerializeHandle() { return true; }

        [XmlElement("SIZE")]
        public int Size { get; set; }

        public JDEXmlActionResponseCreateList(): base(JDEXmlActionTypes.CreateList)
        {
            Handle = "";
            Size = 0;
        }

    }
}
