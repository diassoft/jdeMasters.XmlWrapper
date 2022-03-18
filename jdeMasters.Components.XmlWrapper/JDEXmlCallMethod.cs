using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.Utils;
using jdeMasters.Components.XmlWrapper.XmlRequest;
using System.Runtime.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    /// <summary>
    /// Representation of a CallMethod tag inside a <see cref="JDEXmlRequestCallMethod"/>
    /// </summary>
    [XmlType("callMethod")]
    [DataContract]
    public sealed class JDEXmlCallMethod: JDEXmlCallMethodBase
    {

        /// <summary>
        /// The return parameters
        /// </summary>
        [XmlElement("returnParams")]
        [DataMember]
        public JDEXmlRequestReturnParams ReturnParameters { get; set; }

        /// <summary>
        /// Function to inform the serializer whether to serialize or not the <see cref="ReturnParameters"/>
        /// </summary>
        /// <returns>A <see cref="bool"/> to define whether to serialize or not</returns>
        public bool ShouldSerializeReturnParameters()
        {
            return (ReturnParameters.Items.Count > 0);
        }

        /// <summary>
        /// The OnError Xml Data
        /// </summary>
        [XmlElement("onError")]
        [DataMember]
        public JDEXmlRequestOnError OnError { get; set; }

        /// <summary>
        /// Function to informn the serializer whether to serialize or not the <see cref="OnError"/>
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeOnError()
        {
            return (OnError != null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JDEXmlCallMethod"/>
        /// </summary>
        public JDEXmlCallMethod(): base()
        {
            ReturnParameters = new JDEXmlRequestReturnParams();
        }
    }
}
