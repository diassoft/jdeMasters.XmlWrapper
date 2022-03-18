using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.Utils
{
    public enum JDEYesNo
    {
        [XmlEnum("no")]
        No,
        [XmlEnum("yes")]
        Yes
    }
}
