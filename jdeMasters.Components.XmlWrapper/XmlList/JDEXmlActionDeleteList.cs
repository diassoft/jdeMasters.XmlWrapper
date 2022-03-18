using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlActionDeleteList))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlActionDeleteList))]
    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]
    public sealed class JDEXmlActionDeleteList: JDEXmlAction
    {
        [XmlElement("HANDLE")]
        public JDEXmlValuedField<string> Handle { get; set; }
        public bool ShouldSerializeHandle() { return true; }

        public JDEXmlActionDeleteList(): base(JDEXmlActionTypes.DeleteList)
        {
            Handle = new JDEXmlValuedField<string>();
        }
    }

}
