using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    
    [XmlInclude(typeof(JDEXmlDataSelectionClause))]
    [XmlInclude(typeof(JDEXmlDataSelectionClauseTypes)), XmlInclude(typeof(JDEXmlTypedField<JDEXmlDataSelectionClauseTypes>))]
    [XmlInclude(typeof(JDEXmlColumn))]
    [XmlInclude(typeof(JDEXmlDataSelectionClauseOperatorTypes)), XmlInclude(typeof(JDEXmlTypedField<JDEXmlDataSelectionClauseOperatorTypes>))]
    [XmlInclude(typeof(JDEXmlOperand)), XmlInclude(typeof(JDEXmlOperandLiteral)), XmlInclude(typeof(JDEXmlOperandList)), XmlInclude(typeof(JDEXmlOperandRange)), XmlInclude(typeof(JDEXmlOperandRangeLiteral))]

    [KnownType(typeof(JDEXmlDataSelectionClause))]
    [KnownType(typeof(JDEXmlDataSelectionClauseTypes)), KnownType(typeof(JDEXmlTypedField<JDEXmlDataSelectionClauseTypes>))]
    [KnownType(typeof(JDEXmlColumn))]
    [KnownType(typeof(JDEXmlDataSelectionClauseOperatorTypes)), KnownType(typeof(JDEXmlTypedField<JDEXmlDataSelectionClauseOperatorTypes>))]
    [KnownType(typeof(JDEXmlOperand)), XmlInclude(typeof(JDEXmlOperandLiteral)), KnownType(typeof(JDEXmlOperandList)), XmlInclude(typeof(JDEXmlOperandRange)), XmlInclude(typeof(JDEXmlOperandRangeLiteral))]

    [XmlRoot("CLAUSE")]
    public sealed class JDEXmlDataSelectionClause: JDEXmlTypedField<JDEXmlDataSelectionClauseTypes>
    {
        [XmlElement("COLUMN")]
        public JDEXmlColumn Column { get; set; }

        [XmlElement("OPERATOR")]
        public JDEXmlTypedField<JDEXmlDataSelectionClauseOperatorTypes> Operator { get; set; }

        [XmlElement("OPERAND")]
        public JDEXmlOperand Operand { get; set; }

        public bool ShouldSerializeOperand()
        {
            return (Operand != null);
        }

        public JDEXmlDataSelectionClause(): base(JDEXmlDataSelectionClauseTypes.And)
        {
            Column = new JDEXmlColumn();
            Operator = new JDEXmlTypedField<JDEXmlDataSelectionClauseOperatorTypes>(JDEXmlDataSelectionClauseOperatorTypes.Equal);
        }

        public JDEXmlDataSelectionClause(JDEXmlDataSelectionClauseTypes type): base(type)
        {
            Column = new JDEXmlColumn();
            Operator = new JDEXmlTypedField<JDEXmlDataSelectionClauseOperatorTypes>(JDEXmlDataSelectionClauseOperatorTypes.Equal);
        }

        public JDEXmlDataSelectionClause(JDEXmlDataSelectionClauseTypes type, JDEXmlDataSelectionClauseOperatorTypes @operator) : base(type)
        {
            Column = new JDEXmlColumn();
            Operator = new JDEXmlTypedField<JDEXmlDataSelectionClauseOperatorTypes>(@operator);
        }

    }

    /// <summary>
    /// Types of Clause Types
    /// </summary>
    public enum JDEXmlDataSelectionClauseTypes : int
    {
        [XmlEnum("WHERE")]
        Where = 0,
        [XmlEnum("AND")]
        And = 1,
        [XmlEnum("OR")]
        Or = 2
    }

    public enum JDEXmlDataSelectionClauseOperatorTypes : int
    {
        [XmlEnum("EQ")]
        Equal = 0,
        [XmlEnum("NE")]
        NotEqual = 1,
        [XmlEnum("LT")]
        LessThan = 2,
        [XmlEnum("GT")]
        GreaterThan = 3,
        [XmlEnum("LE")]
        LessOrEqualTo = 4,
        [XmlEnum("GE")]
        GreaterOrEqualTo = 5,
        [XmlEnum("IN")]
        In = 6,
        [XmlEnum("NI")]
        NotIn = 7,
        [XmlEnum("BW")]
        Between = 8,
        [XmlEnum("NB")]
        NotBetween = 9
    }

}
