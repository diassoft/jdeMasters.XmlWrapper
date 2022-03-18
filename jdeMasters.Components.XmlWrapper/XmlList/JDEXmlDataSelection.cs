using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlDataSelection))]
    [XmlInclude(typeof(JDEXmlDataSelectionClause))]

    [KnownType(typeof(JDEXmlDataSelection))]
    [KnownType(typeof(JDEXmlDataSelectionClause))]

    [XmlRoot("DATA_SELECTION")]
    public sealed class JDEXmlDataSelection
    {
        [XmlElement("CLAUSE")]
        public List<JDEXmlDataSelectionClause> Clauses { get; set; }

    }
}
