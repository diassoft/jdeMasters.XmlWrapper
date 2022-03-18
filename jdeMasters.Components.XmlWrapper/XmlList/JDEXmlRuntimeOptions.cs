using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlRuntimeOptions))]
    [XmlInclude(typeof(JDEXmlDataSelection))]
    [XmlInclude(typeof(JDEXmlDataSequencing))]

    [KnownType(typeof(JDEXmlRuntimeOptions))]
    [KnownType(typeof(JDEXmlDataSelection))]
    [KnownType(typeof(JDEXmlDataSequencing))]
    public sealed class JDEXmlRuntimeOptions
    {
        [XmlElement("DATA_SELECTION")]
        public JDEXmlDataSelection DataSelection { get; set; }

        [XmlElement("DATA_SEQUENCING")]
        public JDEXmlDataSequencing DataSequencing { get; set; }

        public JDEXmlRuntimeOptions()
        {
            DataSelection = new JDEXmlDataSelection();
        }

    }
}
