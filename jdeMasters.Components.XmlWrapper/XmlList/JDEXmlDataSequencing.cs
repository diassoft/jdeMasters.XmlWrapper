using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlDataSequencing))]
    [XmlInclude(typeof(JDEXmlDataSequencingData))]

    [KnownType(typeof(JDEXmlDataSequencing))]
    [KnownType(typeof(JDEXmlDataSequencingData))]

    [XmlRoot("DATA_SEQUENCING")]
    public sealed class JDEXmlDataSequencing
    {
        [XmlElement("DATA")]
        public List<JDEXmlDataSequencingData> Data { get; set; }

        public JDEXmlDataSequencing()
        {
            Data = new List<JDEXmlDataSequencingData>();
        }
    }
}
