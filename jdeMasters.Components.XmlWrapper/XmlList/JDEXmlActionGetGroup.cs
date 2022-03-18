using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlActionGetGroup))]
    [XmlInclude(typeof(JDEXmlValuedField<int>))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlActionGetGroup))]
    [KnownType(typeof(JDEXmlValuedField<int>))]
    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]
    public sealed class JDEXmlActionGetGroup: JDEXmlAction
    {
        [XmlElement("HANDLE")]
        public JDEXmlValuedField<string> Handle { get; set; }
        public bool ShouldSerializeHandle() { return true; }

        [XmlElement("FROM")]
        public JDEXmlValuedField<int> From { get; set; }

        [XmlElement("TO")]
        public JDEXmlValuedField<int> To { get; set; }

        public JDEXmlActionGetGroup(): base(JDEXmlActionTypes.GetGroup)
        {
            From = new JDEXmlValuedField<int>();
            To = new JDEXmlValuedField<int>();
        }

        public JDEXmlActionGetGroup(string handle, int from, int to): base(JDEXmlActionTypes.GetGroup)
        {
            From = new JDEXmlValuedField<int>(from);
            To = new JDEXmlValuedField<int>(to);
            Handle = new JDEXmlValuedField<string>(handle);
        }

    }
}
