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
    [XmlInclude(typeof(JDEXmlResponseListGetGroup))]
    [XmlInclude(typeof(JDEXmlActionResponseGetGroup))]
    [XmlInclude(typeof(JDEXmlResponseList))]
    [XmlInclude(typeof(JDEXmlOperation)), XmlInclude(typeof(JDEXmlReturnCode))]

    [KnownType(typeof(JDEXmlResponseListGetGroup))]
    [KnownType(typeof(JDEXmlActionResponseGetGroup))]
    [KnownType(typeof(JDEXmlResponseList))]
    [KnownType(typeof(JDEXmlOperation)), KnownType(typeof(JDEXmlReturnCode))]

    [DataContract]
    [XmlRoot("jdeResponse", IsNullable = false)]
    public sealed class JDEXmlResponseListGetGroup: JDEXmlResponseList
    {
        [XmlElement("ACTION")]
        public JDEXmlActionResponseGetGroup Action { get; set; }

        public JDEXmlResponseListGetGroup(): base()
        {
            Action = new JDEXmlActionResponseGetGroup();
        }

    }
}
