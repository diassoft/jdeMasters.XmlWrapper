using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    [XmlRoot("jdeRequest")]
    [DataContract]
    public sealed class JDEXmlRequestCallMethodTemplate: JDEXmlOperation
    {
        [XmlElement("callMethodTemplate")]
        public JDEXmlCallMethod CallMethodTemplate;

        /// <summary>
        /// Initializes a new instance of the JDEXmlRequestTemplate. This is used when you want to as for the parameters of a function, so you pass the function name and it will return the contents.
        /// </summary>
        public JDEXmlRequestCallMethodTemplate(): base()
        {
            CallMethodTemplate = new JDEXmlCallMethod();
            base.Type = JDEXmlRequestTypes.CallMethod;
        }

    }
}
