using jdeMasters.Components.XmlWrapper.XmlList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlResponse
{
    [XmlInclude(typeof(JDEXmlResponseListDelete))]
    [XmlInclude(typeof(JDEXmlActionResponseDeleteList))]
    [XmlInclude(typeof(JDEXmlResponseList))]
    [XmlInclude(typeof(JDEXmlOperation)), XmlInclude(typeof(JDEXmlReturnCode))]

    [KnownType(typeof(JDEXmlResponseListDelete))]
    [KnownType(typeof(JDEXmlActionResponseDeleteList))]
    [KnownType(typeof(JDEXmlResponseList))]
    [KnownType(typeof(JDEXmlOperation)), KnownType(typeof(JDEXmlReturnCode))]

    [DataContract]
    [XmlRoot("jdeResponse", IsNullable = false)]
    public sealed class JDEXmlResponseListDelete: JDEXmlResponseList
    {
        [XmlElement("ACTION")]
        public JDEXmlActionResponseDeleteList Action { get; set; }

        public JDEXmlResponseListDelete(): base()
        {
            Action = new JDEXmlActionResponseDeleteList();
        }

    }
}
