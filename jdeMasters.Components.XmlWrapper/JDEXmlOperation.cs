using jdeMasters.Components.XmlWrapper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.XmlRequest;
using jdeMasters.Components.XmlWrapper.XmlResponse;
using System.Security.Permissions;
using System.Runtime.Serialization;
using jdeMasters.Components.XmlWrapper.XmlList;

namespace jdeMasters.Components.XmlWrapper
{
    /// <summary>
    /// Represents the base class for an XML Interop Operation
    /// </summary>
    #region Operation Attributes
    [XmlInclude(typeof(JDEXmlOperation))]
    [XmlInclude(typeof(JDEXmlRequestTypes))]
    [XmlInclude(typeof(JDESerializableObject))]

    [XmlInclude(typeof(JDEXmlRequestCallMethod)), XmlInclude(typeof(JDEXmlRequestCallMethodTemplate))]
    [XmlInclude(typeof(JDEXmlRequestCustomQuery))]
    [XmlInclude(typeof(JDEXmlRequestList)), XmlInclude(typeof(JDEXmlRequestListCreate)), XmlInclude(typeof(JDEXmlRequestListDelete)), XmlInclude(typeof(JDEXmlRequestListGetGroup))]
    [XmlInclude(typeof(JDEXmlRequestOnError)), XmlInclude(typeof(JDEXmlRequestReturnParams)), XmlInclude(typeof(JDEXmlRequestSessionEnd))]
    [XmlInclude(typeof(JDEXmlRequestTransactionBase)), XmlInclude(typeof(JDEXmlRequestTransactionEnd)), XmlInclude(typeof(JDEXmlRequestTransactionStart))]
    
    [XmlInclude(typeof(JDEXmlResponseCallMethod)), XmlInclude(typeof(JDEXmlResponseCustomQuery))]
    [XmlInclude(typeof(JDEXmlResponseErrorReport))]
    [XmlInclude(typeof(JDEXmlResponseList)), XmlInclude(typeof(JDEXmlResponseListCreate)), XmlInclude(typeof(JDEXmlResponseListDelete)), XmlInclude(typeof(JDEXmlResponseListGetGroup))]

    [XmlInclude(typeof(JDEXmlAction))]
    [XmlInclude(typeof(JDEXmlActionCreateList)), XmlInclude(typeof(JDEXmlActionDeleteList)), XmlInclude(typeof(JDEXmlActionGetGroup))]
    [XmlInclude(typeof(JDEXmlActionResponseCreateList)), XmlInclude(typeof(JDEXmlActionResponseDeleteList)), XmlInclude(typeof(JDEXmlActionResponseGetGroup))]
    [XmlInclude(typeof(JDEXmlColumn)), XmlInclude(typeof(JDEXmlDataSelection)), XmlInclude(typeof(JDEXmlDataSelectionClause))]
    [XmlInclude(typeof(JDEXmlDataSequencing)), XmlInclude(typeof(JDEXmlDataSequencingData)), XmlInclude(typeof(JDEXmlDataSequencingDataSortTypes))]
    [XmlInclude(typeof(JDEXmlOperand)), XmlInclude(typeof(JDEXmlOperandLiteral)), XmlInclude(typeof(JDEXmlOperandList)), XmlInclude(typeof(JDEXmlOperandRange)), XmlInclude(typeof(JDEXmlOperandRangeLiteral))]
    [XmlInclude(typeof(JDEXmlRuntimeOptions))]

    [XmlInclude(typeof(JDEFunctionParameter))]
    [XmlInclude(typeof(JDESerializableObject))]
    [XmlInclude(typeof(JDEValue))]
    [XmlInclude(typeof(JDEYesNo))]

    [XmlInclude(typeof(JDEXmlCallMethodBase)), XmlInclude(typeof(JDEXmlCallMethod)), XmlInclude(typeof(JDEXmlCallMethodReturn))]
    [XmlInclude(typeof(JDEXmlError)), XmlInclude(typeof(JDEXmlErrorReport))]

    [XmlInclude(typeof(JDEXmlReturnCode))]
    [XmlInclude(typeof(JDEXmlTableData)), XmlInclude(typeof(JDEXmlTableDataColumn)), XmlInclude(typeof(JDEXmlTableTypes))]

    [KnownType(typeof(JDEXmlOperation))]
    [KnownType(typeof(JDEXmlRequestTypes))]
    [KnownType(typeof(JDESerializableObject))]

    [KnownType(typeof(JDEXmlRequestCallMethod)), KnownType(typeof(JDEXmlRequestCallMethodTemplate))]
    [KnownType(typeof(JDEXmlRequestCustomQuery))]
    [KnownType(typeof(JDEXmlRequestList)), KnownType(typeof(JDEXmlRequestListCreate)), KnownType(typeof(JDEXmlRequestListDelete)), KnownType(typeof(JDEXmlRequestListGetGroup))]
    [KnownType(typeof(JDEXmlRequestOnError)), KnownType(typeof(JDEXmlRequestReturnParams)), KnownType(typeof(JDEXmlRequestSessionEnd))]
    [KnownType(typeof(JDEXmlRequestTransactionBase)), KnownType(typeof(JDEXmlRequestTransactionEnd)), KnownType(typeof(JDEXmlRequestTransactionStart))]

    [KnownType(typeof(JDEXmlResponseCallMethod)), KnownType(typeof(JDEXmlResponseCustomQuery))]
    [KnownType(typeof(JDEXmlResponseErrorReport))]
    [KnownType(typeof(JDEXmlResponseList)), KnownType(typeof(JDEXmlResponseListCreate)), KnownType(typeof(JDEXmlResponseListDelete)), KnownType(typeof(JDEXmlResponseListGetGroup))]

    [KnownType(typeof(JDEXmlAction))]
    [KnownType(typeof(JDEXmlActionCreateList)), KnownType(typeof(JDEXmlActionDeleteList)), KnownType(typeof(JDEXmlActionGetGroup))]
    [KnownType(typeof(JDEXmlActionResponseCreateList)), KnownType(typeof(JDEXmlActionResponseDeleteList)), KnownType(typeof(JDEXmlActionResponseGetGroup))]
    [KnownType(typeof(JDEXmlColumn)), KnownType(typeof(JDEXmlDataSelection)), KnownType(typeof(JDEXmlDataSelectionClause))]
    [KnownType(typeof(JDEXmlDataSequencing)), KnownType(typeof(JDEXmlDataSequencingData)), KnownType(typeof(JDEXmlDataSequencingDataSortTypes))]
    [KnownType(typeof(JDEXmlOperand)), KnownType(typeof(JDEXmlOperandLiteral)), KnownType(typeof(JDEXmlOperandList)), KnownType(typeof(JDEXmlOperandRange)), KnownType(typeof(JDEXmlOperandRangeLiteral))]
    [KnownType(typeof(JDEXmlRuntimeOptions))]

    [KnownType(typeof(JDEFunctionParameter))]
    [KnownType(typeof(JDESerializableObject))]
    [KnownType(typeof(JDEValue))]
    [KnownType(typeof(JDEYesNo))]

    [KnownType(typeof(JDEXmlCallMethodBase)), KnownType(typeof(JDEXmlCallMethod)), KnownType(typeof(JDEXmlCallMethodReturn))]
    [KnownType(typeof(JDEXmlError)), KnownType(typeof(JDEXmlErrorReport))]

    [KnownType(typeof(JDEXmlReturnCode))]
    [KnownType(typeof(JDEXmlTableData)), KnownType(typeof(JDEXmlTableDataColumn)), KnownType(typeof(JDEXmlTableTypes))]

    [DataContract]
    [XmlRoot("jdeOperation", IsNullable = false)]
    #endregion
    public abstract class JDEXmlOperation: JDESerializableObject
    {
        /// <summary>
        /// Represents the UniqueKey for the request
        /// </summary>
        [XmlIgnore]
        protected string DateTimeKey;

        private string _uniqueKey;

        /// <summary>
        /// Represents the Unique Key for the transaction
        /// </summary>
        [DataMember]
        [XmlIgnore]
        public string UniqueKey
        {
            get
            {
                return string.Format("{0}_{1}_{2}", Environment, User, DateTimeKey);
            }
            set
            {
                _uniqueKey = value;
            }
        }

        /// <summary>
        /// The type of the request.
        /// CallMethod, Trans, List, XapiCallMethod are possible values.
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        [DataMember]
        public JDEXmlRequestTypes Type { get; set; }

        /// <summary>
        /// JDE User Name
        /// </summary>
        [XmlAttribute(AttributeName = "user")]
        [DataMember]
        public string User { get; set; }

        /// <summary>
        /// JDE Password
        /// </summary>
        [XmlAttribute(AttributeName = "pwd")]
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// JDE Environment
        /// </summary>
        [XmlAttribute(AttributeName = "environment")]
        [DataMember]
        public string Environment { get; set; }

        /// <summary>
        /// JDE User Role (default is *ALL)
        /// </summary>
        [XmlAttribute(AttributeName = "role")]
        [DataMember]
        public string Role { get; set; }

        /// <summary>
        /// Specifies the Session ID.
        /// When you are initializing a session, leave this field blank and it will serialize as section = ' '. 
        /// The response will bring to you the section number.
        /// </summary>
        [XmlAttribute(AttributeName = "session")]
        [DataMember]
        public string Session { get; set; }

        /// <summary>
        /// Specifies the Session Idle time in seconds.
        /// </summary>
        [XmlAttribute(AttributeName = "sessionIdle")]
        [DataMember]
        public int SessionIdle { get; set; }

        /// <summary>
        /// Defines whether the Session Idle property will be serialized or not.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeSessionIdle()
        {
            // Serialize the SessionIdle only if it's value is greater than zero
            return (SessionIdle > 0);
        }

        /// <summary>
        /// Defines the file name for the request
        /// </summary>
        [XmlIgnore]
        public string Filename { get; set; }

        /// <summary>
        /// Initializes a new instance of a JDE Xml Operation.
        /// This should never be visible for other assemblies.
        /// </summary>
        internal JDEXmlOperation()
        {

        }

        internal JDEXmlOperation(JDEXmlRequestTypes type)
        {
            Type = type;
        }
    }
}
