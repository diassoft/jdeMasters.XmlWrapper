using jdeMasters.Components.XmlWrapper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    /// <summary>
    /// Represents a Custom Sql Query to be ran by the JDE Xml Dispatcher.
    /// This is a custom object, by default the query transactions should be done thru lists, but this is a very slow process, hence the custom query enhances the performance on the execution.
    /// </summary>
    [XmlRoot("jdeRequest", IsNullable = false)]
    [XmlInclude(typeof(JDEXmlRequestCustomQuery))]
    [XmlInclude(typeof(JDEXmlRequestTransactionBase)), XmlInclude(typeof(JDEXmlRequestTransactionEnd))]
    [XmlInclude(typeof(SerializableObject))]
    [KnownType(typeof(JDEXmlRequestCustomQuery)), KnownType(typeof(JDEXmlCallMethod)), KnownType(typeof(JDEFunctionParameter))]
    [KnownType(typeof(JDEXmlOperation)), KnownType(typeof(JDEXmlRequestTransactionEnd))]
    [KnownType(typeof(SerializableObject))]
    [DataContract]
    public sealed class JDEXmlRequestCustomQuery: JDEXmlOperation
    {

        /// <summary>
        /// The Sql Statement
        /// </summary>
        [XmlElement("statement")]
        public string Statement { get; set; }

        public JDEXmlRequestCustomQuery(): base(JDEXmlRequestTypes.CustomQuery)
        {
            Statement = "";
        }

        public JDEXmlRequestCustomQuery(string statement) : base(JDEXmlRequestTypes.CustomQuery)
        {
            Statement = statement;
        }

    }
}
