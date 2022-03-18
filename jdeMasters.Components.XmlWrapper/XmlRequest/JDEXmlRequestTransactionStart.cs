using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    [XmlRoot("startTransaction")]
    [DataContract]
    public sealed class JDEXmlRequestTransactionStart: JDEXmlRequestTransactionBase
    {
        [XmlAttribute("type")]
        public JDEXmlRequestTransactionTypes Type { get; set; }

        public JDEXmlRequestTransactionStart()
        {
            Type = JDEXmlRequestTransactionTypes.Manual;
        }

        public JDEXmlRequestTransactionStart(JDEXmlRequestTransactionTypes type)
        {
            Type = type;
        }

        public JDEXmlRequestTransactionStart(JDEXmlRequestTransactionTypes type, string transactionID)
        {
            Type = type;
            base.Transaction = transactionID;
        }

    }

    public enum JDEXmlRequestTransactionTypes : int
    {
        [XmlEnum("auto")]
        Auto = 0,
        [XmlEnum("manual")]
        Manual = 1
    }
}
