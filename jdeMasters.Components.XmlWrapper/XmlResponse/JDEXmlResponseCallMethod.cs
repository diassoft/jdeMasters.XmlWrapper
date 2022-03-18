using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlResponse
{
    /// <summary>
    /// Represents a JDE Xml Response.
    /// Responses are generated from JDE Xml Requests, after the requests are processed by the JDE EnterpriseOne XML Interoperability
    /// </summary>
    [XmlRoot("jdeResponse", IsNullable = false)]
    [XmlInclude(typeof(JDEXmlResponseCallMethod))]
    [KnownType(typeof(JDEXmlResponseCallMethod))]
    [DataContract]
    public sealed class JDEXmlResponseCallMethod: JDEXmlOperation
    {
        /// <summary>
        /// The time in milliseconds that the request took to run
        /// </summary>
        [XmlIgnore]
        public int ProcessingTime { get; internal set; }

        /// <summary>
        /// The Request Unique Key
        /// </summary>
        [XmlIgnore]
        public string RequestUniqueKey { get; internal set; }

        /// <summary>
        /// The Path for the Request XML File
        /// </summary>
        [XmlIgnore]
        public string RequestFilename { get; internal set; }

        /// <summary>
        /// The return of the Call Methods
        /// </summary>
        [XmlElement("callMethod")]
        public List<JDEXmlCallMethodReturn> CallMethods { get; set; }

        /// <summary>
        /// Initializes a new instance of the JDE Xml Response of Call Method Type
        /// </summary>
        public JDEXmlResponseCallMethod(): base()
        {

        }

        internal JDEXmlResponseCallMethod(string requestUniqueKey, string requestFilename)
        {
            RequestUniqueKey = requestUniqueKey;
            RequestFilename = requestFilename;
        }

        internal JDEXmlResponseCallMethod(string requestUniqueKey, string requestFilename, int processingTime)
        {
            RequestUniqueKey = requestUniqueKey;
            RequestFilename = requestFilename;
            ProcessingTime = processingTime;
        }


    }
}
