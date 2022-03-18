using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.Utils;
using System.Runtime.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    [DataContract]
    public sealed class JDEXmlRequestOnError
    {

        [XmlAttribute("abort")]
        public JDEYesNo Abort { get; set; }

        /// <summary>
        /// Array of Call Methods to be generated on the Request
        /// </summary>
        [XmlElement("callMethod")]
        public List<JDEXmlCallMethod> CallMethods { get; set; }

        public bool ShouldSerializeCallMethods()
        {
            return (CallMethods != null) && (CallMethods.Count > 0);
        }

        [XmlElement("endTransaction")]
        public JDEXmlRequestTransactionEnd EndTransaction { get; set; }

        public bool ShouldSerializeEndTransaction()
        {
            return (EndTransaction != null);
        }

        public JDEXmlRequestOnError()
        {
            Abort = JDEYesNo.No;
            EndTransaction = null;
            CallMethods = new List<JDEXmlCallMethod>();
        }

        public JDEXmlRequestOnError(JDEYesNo abort): this()
        {
            Abort = abort;
        }
    }
}
