using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    [DataContract]
    public sealed class JDEXmlReturnCode
    {
        /// <summary>
        /// The Return Codes from a Function
        /// </summary>
        [XmlAttribute("code")]
        public JDEXmlReturnCodeCodes Code { get; set; }

        [XmlText]
        public string Value { get; set; }

        public JDEXmlReturnCode()
        {

        }
    }

    public enum JDEXmlReturnCodeCodes : int
    {
        /// <summary>
        /// Return of Business Function was ER_SUCCESS
        /// </summary>
        [XmlEnum("0")]
        Success = 0,
        [XmlEnum("1")]
        Warning = 1,
        /// <summary>
        /// Return of Business Function was ER_ERROR
        /// </summary>
        [XmlEnum("2")]
        Error = 2,
        /// <summary>
        /// General Error on the Business Function Call
        /// </summary>
        [XmlEnum("99")]
        GeneralError = 99
    }

}
