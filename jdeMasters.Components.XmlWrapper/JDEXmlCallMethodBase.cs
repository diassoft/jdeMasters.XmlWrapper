using jdeMasters.Components.XmlWrapper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    /// <summary>
    /// Represents the Base Class of a CallMethod 
    /// </summary>
    [DataContract]
    public abstract class JDEXmlCallMethodBase
    {
        /// <summary>
        /// The call method name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Name of the application calling the Business Function
        /// </summary>
        [XmlAttribute(AttributeName = "app")]
        [DataMember]
        public string CallingApplication { get; set; }

        /// <summary>
        /// The transaction ID
        /// </summary>
        [XmlAttribute(AttributeName = "trans")]
        [DataMember]
        public string TransactionID { get; set; }

        /// <summary>
        /// The Run on error
        /// </summary>
        [XmlAttribute("runOnError")]
        [DataMember]
        public JDEYesNo RunOnError { get; set; }

        /// <summary>
        /// Function to inform the serializer whether to serialize or not the <see cref="RunOnError"/> property
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeRunOnError()
        {
            return RunOnError == JDEYesNo.Yes;
        }

        /// <summary>
        /// The ReturnNullData flag
        /// </summary>
        [XmlAttribute("returnNullData")]
        [DataMember]
        public JDEYesNo ReturnNullData { get; set; }

        /// <summary>
        /// Function to inform the serializer whether to serialize or not the <see cref="ReturnNullData"/> property
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeReturnNullData()
        {
            return ReturnNullData == JDEYesNo.Yes;
        }

        /// <summary>
        /// The Call Method parameters
        /// </summary>
        [XmlArray("params")]
        [XmlArrayItem("param")]
        public List<JDEFunctionParameter> Parameters { get; set; }

        /// <summary>
        /// Function to inform the serializer whether to serialize or not the <see cref="Parameters"/> property
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeParameters()
        {
            return (Parameters.Count > 0);
        }

        internal JDEXmlCallMethodBase()
        {
            Parameters = new List<JDEFunctionParameter>();
        }

    }
}
