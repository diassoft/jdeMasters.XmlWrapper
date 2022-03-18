using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    [XmlRoot("errorReport")]
    public sealed class JDEXmlErrorReport
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("state")]
        public string State { get; set; }

        [XmlText]
        public string ErrorDescription { get; set; }

        public JDEXmlErrorReport()
        {
            Code = "";
            State = "";
            ErrorDescription = "";
        }

    }
}
