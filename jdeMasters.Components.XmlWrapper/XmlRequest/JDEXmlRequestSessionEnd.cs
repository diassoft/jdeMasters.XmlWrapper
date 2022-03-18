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
    /// This class represents the Session End Command
    /// </summary>
    [XmlRoot("endSession")]
    [XmlType("endSession")]
    [DataContract]
    public sealed class JDEXmlRequestSessionEnd
    {
        public JDEXmlRequestSessionEnd()
        {

        }

    }
}
