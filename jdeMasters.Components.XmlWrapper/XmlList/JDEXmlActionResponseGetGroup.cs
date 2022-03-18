using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlActionResponseGetGroup))]
    [XmlInclude(typeof(JDEXmlValuedField<int>)), XmlInclude(typeof(JDEXmlTableData))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlActionResponseGetGroup))]
    [KnownType(typeof(JDEXmlValuedField<int>)), KnownType(typeof(JDEXmlTableData))]
    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]

    [XmlRoot("ACTION")]
    public sealed class JDEXmlActionResponseGetGroup : JDEXmlAction
    {
        [XmlElement("HANDLE")]
        public JDEXmlValuedField<string> Handle { get; set; }
        public bool ShouldSerializeHandle() { return true; }

        [XmlElement("FROM")]
        public JDEXmlValuedField<int> From { get; set; }

        [XmlElement("TO")]
        public JDEXmlValuedField<int> To { get; set; }

        [XmlElement("FORMAT")]
        public List<JDEXmlTableData> Data { get; set; }

        public JDEXmlActionResponseGetGroup(): base(JDEXmlActionTypes.GetGroup)
        {
            From = new JDEXmlValuedField<int>();
            To = new JDEXmlValuedField<int>();

            Data = new List<JDEXmlTableData>();

            Handle = new JDEXmlValuedField<string>();
        }
    }
}
