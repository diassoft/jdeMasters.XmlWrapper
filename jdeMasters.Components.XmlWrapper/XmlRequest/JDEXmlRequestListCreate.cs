using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.XmlList;

namespace jdeMasters.Components.XmlWrapper.XmlRequest
{
    /// <summary>
    /// Represents a jdeRequest of type "List", with the Create List configuration.
    /// </summary>
    [XmlRoot("jdeRequest")]
    [XmlInclude(typeof(JDEXmlRequestList))]
    [XmlInclude(typeof(JDEXmlRequestListCreate)), XmlInclude(typeof(JDEXmlOperation))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionCreateList))]
    [XmlInclude(typeof(JDEXmlColumn))]
    [XmlInclude(typeof(JDEXmlDataSelection)), XmlInclude(typeof(JDEXmlDataSelectionClause))]
    [XmlInclude(typeof(JDEXmlOperand)), XmlInclude(typeof(JDEXmlOperandColumn)), XmlInclude(typeof(JDEXmlOperandList)), XmlInclude(typeof(JDEXmlOperandLiteral)), XmlInclude(typeof(JDEXmlOperandRange)), XmlInclude(typeof(JDEXmlOperandRangeLiteral))]
    [XmlInclude(typeof(JDEXmlRuntimeOptions)), XmlInclude(typeof(JDEXmlJDEValuedField)), XmlInclude(typeof(JDEXmlValuedField<string>))]
    [XmlInclude(typeof(Utils.JDEValue))]
    [DataContract]
    public sealed class JDEXmlRequestListCreate: JDEXmlRequestList
    {

        public JDEXmlRequestListCreate(): base()
        {
            // Defines the Action of type JDEXmlActionCreateList
            Action = new JDEXmlActionCreateList();
        }

    }
}
