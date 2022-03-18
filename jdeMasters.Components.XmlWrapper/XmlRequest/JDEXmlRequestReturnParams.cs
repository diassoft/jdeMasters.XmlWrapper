using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdeMasters.Components.XmlWrapper.Utils;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    /// <summary>
    /// Represents a list of Request Parameters with additional attributes
    /// </summary>
    [DataContract]
    public sealed class JDEXmlRequestReturnParams
    {

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("messagetype")]
        public string MessageType { get; set; }

        /// <summary>
        /// The Failure Destination Queue Name.
        /// The default value is "ERROR.Q".
        /// </summary>
        [XmlAttribute("failureDestination")]
        public string FailureDestination { get; set; }

        /// <summary>
        /// The Success Destination Queue Name.
        /// The default value is "SUCCESS.Q".
        /// </summary>
        [XmlAttribute("successDestination")]
        public string SuccessDestination { get; set; }

        [XmlElement("param")]
        public List<JDEFunctionParameter> Items { get; set; }

        /// <summary>
        /// Initializes a new Instance of the JDEXmlRequestReturnParams
        /// </summary>
        public JDEXmlRequestReturnParams()
        {
            Items = new List<JDEFunctionParameter>();
        }

        public JDEXmlRequestReturnParams(string version) : this()
        {
            Version = version;
        }

        public JDEXmlRequestReturnParams(string version, string messageType) : this(version)
        {
            MessageType = messageType;
        }

        public JDEXmlRequestReturnParams(string version, string messageType, string failureDestination) : this(version, messageType)
        {
            FailureDestination = failureDestination;
        }

        public JDEXmlRequestReturnParams(string version, string messageType, string failureDestination, string successDestination) : this(version, messageType, failureDestination)
        {
            SuccessDestination = successDestination;
        }

    }
}
