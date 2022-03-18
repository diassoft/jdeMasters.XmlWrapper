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
    /// <summary>
    /// Base Class for Start and End Transactions
    /// </summary>
    [DataContract]
    public abstract class JDEXmlRequestTransactionBase
    {

        [XmlAttribute("trans")]
        public string Transaction { get; set; }

    }


}
