using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.XmlList;

namespace jdeMasters.Components.XmlWrapper.XmlResponse
{
    [XmlInclude(typeof(JDEXmlResponseListCreate))]
    [XmlInclude(typeof(JDEXmlActionResponseCreateList))]
    [XmlInclude(typeof(JDEXmlReturnCode))]
    [XmlInclude(typeof(JDEXmlResponseList))]
    [XmlInclude(typeof(JDEXmlOperation)), XmlInclude(typeof(JDEXmlReturnCode))]

    [KnownType(typeof(JDEXmlResponseListCreate))]
    [KnownType(typeof(JDEXmlActionResponseCreateList))]
    [KnownType(typeof(JDEXmlReturnCode))]
    [KnownType(typeof(JDEXmlResponseList))]
    [KnownType(typeof(JDEXmlOperation)), KnownType(typeof(JDEXmlReturnCode))]

    [DataContract]
    [XmlRoot("jdeResponse", IsNullable = false)]
    public sealed class JDEXmlResponseListCreate: JDEXmlResponseList
    {
        [XmlElement("ACTION")]
        public JDEXmlActionResponseCreateList Action { get; set; }

        public JDEXmlResponseListCreate(): base()
        {
            ReturnCode = new JDEXmlReturnCode();
            Action = new JDEXmlActionResponseCreateList();
        }

    }
}
