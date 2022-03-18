using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    [DataContract]
    public sealed class JDEXmlRequestTransactionEnd: JDEXmlRequestTransactionBase
    {
        [XmlAttribute("action")]
        public JDEXmlRequestTransactionEndActions Action { get; set; }

        public static JDEXmlRequestTransactionEnd CommitTransaction()
        {
            return new JDEXmlRequestTransactionEnd()
            {
                Action = JDEXmlRequestTransactionEndActions.Commit,
            };
        }

        public static JDEXmlRequestTransactionEnd CommitTransaction(string transactionId)
        {
            return new JDEXmlRequestTransactionEnd()
            {
                Action = JDEXmlRequestTransactionEndActions.Commit,
                Transaction = transactionId
            };
        }

        public static JDEXmlRequestTransactionEnd RollbackTransaction
        {
            get
            {
                return new JDEXmlRequestTransactionEnd()
                {
                    Action = JDEXmlRequestTransactionEndActions.Rollback
                };
            }
        }


    }

    public enum JDEXmlRequestTransactionEndActions : int
    {
        [XmlEnum("commit")]
        Commit = 0,
        [XmlEnum("rollback")]
        Rollback = 1
    }
}
