using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlDataSequencingData))]
    [XmlInclude(typeof(JDEXmlDataSequencingDataSortTypes))]
    [XmlInclude(typeof(JDEXmlColumn))]

    [KnownType(typeof(JDEXmlDataSequencingData))]
    [KnownType(typeof(JDEXmlDataSequencingDataSortTypes))]
    [KnownType(typeof(JDEXmlColumn))]

    [XmlRoot("DATA")]
    public sealed class JDEXmlDataSequencingData
    {
        [XmlAttribute("SORT")]
        public JDEXmlDataSequencingDataSortTypes Sort { get; set; }

        [XmlElement("COLUMN")]
        public JDEXmlColumn Column { get; set; }

        public JDEXmlDataSequencingData()
        {
            Sort = JDEXmlDataSequencingDataSortTypes.Ascending;
            Column = new JDEXmlColumn();
        }

        public JDEXmlDataSequencingData(JDEXmlDataSequencingDataSortTypes sort, JDEXmlColumn column)
        {
            Sort = sort;
            Column = column;
        }

    }

    public enum JDEXmlDataSequencingDataSortTypes : int
    {
        [XmlEnum("ASCENDING")]
        Ascending = 0,
        [XmlEnum("DESCENDING")]
        Descending = 1
    }
}
