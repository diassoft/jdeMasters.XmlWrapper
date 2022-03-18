using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlResponse
{
    [XmlRoot("jdeResponse", IsNullable = false)]
    [XmlInclude(typeof(JDEXmlResponseCallMethod))]
    [KnownType(typeof(JDEXmlResponseCallMethod))]
    [DataContract]
    public sealed class JDEXmlResponseErrorReport: JDEXmlOperation
    {
        [XmlElement("errorReport")]
        public JDEXmlErrorReport ErrorReport { get; set; }

        public JDEXmlResponseErrorReport(): base()
        {
            ErrorReport = new JDEXmlErrorReport();
        }

        public JDEXmlResponseErrorReport(Exception e): this()
        {
            ErrorReport.Code = "11";
            ErrorReport.State = "3";
            ErrorReport.ErrorDescription = $"{e.Message}\n{e.StackTrace}";
        }
    }
}
