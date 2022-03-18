using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    /// <summary>
    /// Represents an Error on the Process
    /// </summary>
    [DataContract]
    public sealed class JDEXmlError
    {
        /// <summary>
        /// The Error Code
        /// </summary>
        [XmlAttribute("code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// The parameter where the error was set
        /// </summary>
        [XmlAttribute("name")]
        public string ParameterName { get; set; }

        /// <summary>
        /// The error description
        /// </summary>
        [XmlText]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Initializes a new instance of the JDE Xml Error object.
        /// </summary>
        public JDEXmlError()
        {

        }
    }
}
