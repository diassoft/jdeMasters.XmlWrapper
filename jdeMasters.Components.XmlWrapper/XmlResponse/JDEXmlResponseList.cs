using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlResponse
{

    [XmlInclude(typeof(JDEXmlResponseList))]
    [XmlInclude(typeof(JDEXmlOperation)), XmlInclude(typeof(JDEXmlReturnCode))]

    [KnownType(typeof(JDEXmlResponseList))]
    [KnownType(typeof(JDEXmlOperation)), KnownType(typeof(JDEXmlReturnCode))]

    [DataContract]
    [XmlRoot("jdeResponse", IsNullable = false)]
    public abstract class JDEXmlResponseList: JDEXmlOperation
    {
        [XmlElement("returnCode")]
        public JDEXmlReturnCode ReturnCode { get; set; }

        public JDEXmlResponseList(): base()
        {
            ReturnCode = new JDEXmlReturnCode();
        }
    }
}
