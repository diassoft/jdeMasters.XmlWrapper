using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    [XmlRoot("callMethod")]
    [DataContract]
    public sealed class JDEXmlCallMethodReturn: JDEXmlCallMethodBase
    {
        [XmlElement("returnCode")]
        public JDEXmlReturnCode ReturnCode { get; set; }

        [XmlArray("errors")]
        [XmlArrayItem("error")]
        public List<JDEXmlError> Errors { get; set; }

        public bool ShouldSerializeErrors()
        {
            return (Errors.Count > 0);
        }

        public JDEXmlCallMethodReturn()
        {
            Errors = new List<JDEXmlError>();
        }

    }
}
