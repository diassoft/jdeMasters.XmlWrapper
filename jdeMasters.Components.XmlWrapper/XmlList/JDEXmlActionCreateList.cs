using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdeMasters.Components.XmlWrapper;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlActionCreateList))]
    [XmlInclude(typeof(JDEXmlTableTypes)), XmlInclude(typeof(JDEXmlValuedField<JDEXmlTableTypes>))]
    [XmlInclude(typeof(JDEXmlFormattingTypes)), XmlInclude(typeof(JDEXmlValuedField<JDEXmlFormattingTypes>))]
    [XmlInclude(typeof(JDEXmlRuntimeOptions))]
    [XmlInclude(typeof(JDEXmlAction)), XmlInclude(typeof(JDEXmlActionTypes))]
    [XmlInclude(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), XmlInclude(typeof(JDEXmlValuedField<string>))]

    [KnownType(typeof(JDEXmlActionCreateList))]
    [KnownType(typeof(JDEXmlTableTypes)), KnownType(typeof(JDEXmlValuedField<JDEXmlTableTypes>))]
    [KnownType(typeof(JDEXmlFormattingTypes)), KnownType(typeof(JDEXmlValuedField<JDEXmlFormattingTypes>))]
    [KnownType(typeof(JDEXmlRuntimeOptions))]
    [KnownType(typeof(JDEXmlAction)), KnownType(typeof(JDEXmlActionTypes))]
    [KnownType(typeof(JDEXmlTypedField<JDEXmlActionTypes>)), KnownType(typeof(JDEXmlValuedField<string>))]
    public sealed class JDEXmlActionCreateList: JDEXmlAction
    {
        [XmlElement("LIST_TYPE")]
        public JDEXmlValuedField<string> ListType { get; set; }

        [XmlElement("TABLE_NAME")]
        public JDEXmlValuedField<string> TableName { get; set; }

        public bool ShouldSerializeTableName() { return (TableName?.Value != ""); }

        [XmlElement("TABLE_TYPE")]
        public JDEXmlValuedField<JDEXmlTableTypes> TableType { get; set; }

        public bool ShouldSerializeTableType()
        {
            if (TableName == null) return false;
            if (TableName?.Value == "") return false;

            return (TableType != null);
        }

        [XmlElement("TEMPLATE_TYPE")]
        public JDEXmlValuedField<JDEXmlTemplateTypes> TemplateType { get; set; }

        public bool ShouldSerializeTemplateType() { return (TemplateType != null); }

        [XmlElement("TC_NAME")]
        public JDEXmlValuedField<string> TableConversionName { get; set; }

        public bool ShouldSerializeTableConversionName()
        {
            if (TableName?.Value != "") return false;

            return (TableConversionName?.Value != "");
        }

        [XmlElement("TC_VERSION")]
        public JDEXmlValuedField<string> TableConversionVersion { get; set; }

        public bool ShouldSerializeTableConversionVersion()
        {
            if (TableName?.Value != "") return false;

            return (TableConversionVersion?.Value != "");
        }

        [XmlElement("FORMAT")]
        public JDEXmlValuedField<JDEXmlFormattingTypes> Format { get; set; }

        [XmlElement("RUNTIME_OPTIONS")]
        public JDEXmlRuntimeOptions RuntimeOptions { get; set; }

        /// <summary>
        /// Creates a new Action of type Create List
        /// </summary>
        public JDEXmlActionCreateList(): base(JDEXmlActionTypes.CreateList)
        {
            TableName = new JDEXmlValuedField<string>();
            TableType = new JDEXmlValuedField<JDEXmlTableTypes>();
            TableConversionName = new JDEXmlValuedField<string>();
            TableConversionVersion = new JDEXmlValuedField<string>();
            Format = new JDEXmlValuedField<JDEXmlFormattingTypes>(JDEXmlFormattingTypes.FullFormatting);
            RuntimeOptions = new JDEXmlRuntimeOptions();
            ListType = new JDEXmlValuedField<string>("JDB");
        }

    }

    /// <summary>
    /// The valid types for formatting.
    /// </summary>
    public enum JDEXmlFormattingTypes : int
    {
        /// <summary>
        /// The Concise Mode (UT)
        /// </summary>
        [XmlEnum("UT")]
        ConciseMode = 0,
        /// <summary>
        /// The Full Formatting Mode
        /// </summary>
        [XmlEnum("")]
        FullFormatting = 1
    }

    public enum JDEXmlTemplateTypes : int
    {
        [XmlEnum("INPUT")]
        Input = 0,
        [XmlEnum("OUTPUT")]
        Output = 1
    }

    public enum JDEXmlTableTypes : int
    {
        [XmlEnum("OWTABLE")]
        OneWorldTable = 0,
        [XmlEnum("OWVIEW")]
        OneWorldView = 1,
        [XmlEnum("FOREIGN_TABLE")]
        ForeignTable = 2

    }
}
