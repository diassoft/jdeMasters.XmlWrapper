using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]

    [XmlRoot("ACTION")]
    public abstract class JDEXmlAction: JDEXmlTypedField<JDEXmlActionTypes>
    {

        public JDEXmlAction(): base()
        {

        }

        public JDEXmlAction(JDEXmlActionTypes type): base(type)
        {
            
        }

    }

    public enum JDEXmlActionTypes: int
    {
        [XmlEnum("GetTemplate")]
        GetTemplate = 0,
        [XmlEnum("CreateList")]
        CreateList = 1,
        [XmlEnum("GetGroup")]
        GetGroup = 2,
        [XmlEnum("DeleteList")]
        DeleteList = 3
    }
}
