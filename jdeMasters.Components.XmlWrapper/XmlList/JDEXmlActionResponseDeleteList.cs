using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlActionResponseDeleteList))]
    [XmlInclude(typeof(JDEXmlGenericField<string>))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlActionResponseDeleteList))]
    [KnownType(typeof(JDEXmlGenericField<string>))]
    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]
    public sealed class JDEXmlActionResponseDeleteList : JDEXmlAction
    {
        [XmlElement("HANDLE")]
        public JDEXmlValuedField<string> Handle { get; set; }

        public bool ShouldSerializeHandle() { return true; }

        [XmlElement("STATUS")]
        public JDEXmlGenericField<string> Status { get; set; }

        public JDEXmlActionResponseDeleteList(): base(JDEXmlActionTypes.DeleteList)
        {
            Status = new JDEXmlGenericField<string>();
            Handle = new JDEXmlValuedField<string>();
        }


    }
}
