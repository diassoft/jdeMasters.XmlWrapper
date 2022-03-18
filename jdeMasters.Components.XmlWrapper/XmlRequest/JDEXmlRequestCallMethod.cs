using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdeMasters.Components.XmlWrapper;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using jdeMasters.Components.XmlWrapper.Utils;
using System.Runtime.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    /// <summary>
    /// Represents a JDE Xml Request of Call Method type
    /// Requests are used to send data to JDE EnterpriseOne XML Interoperability.
    /// </summary>
    [XmlRoot("jdeRequest", IsNullable = false)]
    [XmlInclude(typeof(JDEXmlRequestCallMethod)), XmlInclude(typeof(JDEXmlCallMethod)), XmlInclude(typeof(JDEFunctionParameter))]
    [XmlInclude(typeof(JDEXmlRequestTransactionBase)), XmlInclude(typeof(JDEXmlRequestTransactionEnd))]
    [XmlInclude(typeof(SerializableObject))]
    [KnownType(typeof(JDEXmlRequestCallMethod)), KnownType(typeof(JDEXmlCallMethod)), KnownType(typeof(JDEFunctionParameter))]
    [KnownType(typeof(JDEXmlRequestTransactionBase)), KnownType(typeof(JDEXmlRequestTransactionEnd))]
    [KnownType(typeof(SerializableObject))]
    [DataContract]
    public sealed class JDEXmlRequestCallMethod: JDEXmlOperation
    {
        /// <summary>
        /// Represents the Start Transaction tag
        /// </summary>
        [XmlElement("startTransaction")]
        public JDEXmlRequestTransactionStart StartTransaction { get; set; }

        /// <summary>
        /// Defines whether the Start Transaction Tag will be serialized or not.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeStartTransaction()
        {
            if (Type != JDEXmlRequestTypes.CallMethod) return false;
            return (StartTransaction != null);
        }

        /// <summary>
        /// Array of Call Methods to be generated on the Request
        /// </summary>
        [XmlElement("callMethod")]
        public List<JDEXmlCallMethod> CallMethods { get; set; }

        /// <summary>
        /// Defines whether the Call Methods array will be serialized or not.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeCallMethod()
        {
            if (Type != JDEXmlRequestTypes.CallMethod) return false;
            if (CallMethods == null) return false;
            return (CallMethods.Count > 0);
        }

        /// <summary>
        /// Defines the OnError tag
        /// </summary>
        [XmlElement("onError")]
        public JDEXmlRequestOnError OnError { get; set; }

        /// <summary>
        /// Defines whether the On Error tag will be serialized or not.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeOnError()
        {
            if (Type != JDEXmlRequestTypes.CallMethod) return false;
            return (OnError != null);
        }

        /// <summary>
        /// Defines the End Transaction tag
        /// </summary>
        [XmlElement("endTransaction")]
        public JDEXmlRequestTransactionEnd EndTransaction { get; set; }

        /// <summary>
        /// Defines whether the End Transaction tag will be serialized or not.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeEndTransaction()
        {
            if (Type != JDEXmlRequestTypes.CallMethod) return false;
            return (EndTransaction != null);
        }

        /// <summary>
        /// Defines the End Session Tag
        /// </summary>
        [XmlElement("endSession")]
        public JDEXmlRequestSessionEnd EndSession { get; set; }

        /// <summary>
        /// Defines whether the End Session Tag will be serialized or not.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeEndSession()
        {
            if (Type != JDEXmlRequestTypes.CallMethod) return false;
            return (EndSession != null) && (Session != "") && (Session != null);
        }

        /// <summary>
        /// Creates a new instance of a JDEXmlRequest Object
        /// </summary>
        public JDEXmlRequestCallMethod(): base()
        {
            DateTimeKey = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            Role = "*ALL";
            CallMethods = new List<JDEXmlCallMethod>();
            Type = JDEXmlRequestTypes.CallMethod;
        }

    }

    /// <summary>
    /// Valid values for XML Request Types
    /// </summary>
    public enum JDEXmlRequestTypes: int
    {
        /// <summary>
        /// The type of the request is a Call Method.
        /// You can call business functions using the CallMethod type.
        /// </summary>
        [XmlEnum(Name = "callmethod")]
        CallMethod = 0,

        /// <summary>
        /// The type of the request is a List.
        /// You can create and maintain lists using this request type.
        /// </summary>
        [XmlEnum(Name = "list")]
        List = 1,

        /// <summary>
        /// The type of the request is Transaction.
        /// You can call standard transaction (such as JDESOOUT) using this type.
        /// </summary>
        [XmlEnum(Name = "trans")]
        Trans = 2,

        /// <summary>
        /// The type of the request is a XAPI Call Method.
        /// </summary>
        [XmlEnum(Name = "xapicallmethod")]
        XAPICallMethod = 3,

        /// <summary>
        /// The request is to perform a raw SQL statement.
        /// This is not a standard interoperability method.
        /// </summary>
        [XmlEnum(Name = "customQuery")]
        CustomQuery = 90
    }
}
