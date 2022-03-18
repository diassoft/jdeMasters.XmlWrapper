using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.XmlRequest;

namespace jdeMasters.Components.XmlWrapper.XmlResponse
{
    /// <summary>
    /// Represents a JDE Xml Response.
    /// Responses are generated from JDE Xml Requests, after the requests are processed by the JDE EnterpriseOne XML Interoperability
    /// </summary>
    [XmlRoot("jdeResponse", IsNullable = false)]
    [XmlInclude(typeof(JDEXmlResponseCustomQuery))]
    [KnownType(typeof(JDEXmlResponseCustomQuery))]
    [DataContract]
    public sealed class JDEXmlResponseCustomQuery: JDEXmlOperation
    {
        [XmlElement("returnCode")]
        public JDEXmlReturnCode ReturnCode { get; set; }

        [XmlElement("FORMAT")]
        public JDEXmlTableData Data { get; set; }

        public JDEXmlResponseCustomQuery(): base(JDEXmlRequestTypes.CustomQuery)
        {
            ReturnCode = new JDEXmlReturnCode();
            Data = new JDEXmlTableData();
        }

    }
}
