using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.XmlList
{
    [XmlInclude(typeof(JDEXmlColumn))]
    [KnownType(typeof(JDEXmlColumn))]
    [XmlRoot("COLUMN")]
    public class JDEXmlColumn
    {
        [XmlAttribute("NAME")]
        public string Name { get; set; }

        [XmlAttribute("TABLE")]
        public string Table { get; set; }

        [XmlAttribute("INSTANCE")]
        public string Instance { get; set; }

        [XmlAttribute("ALIAS")]
        public string Alias { get; set; }

        [XmlAttribute("TYPE")]
        public string Type { get; set; }

        public bool ShouldSerializeType()
        {
            return ((Type != "") && (Type != null));
        }

        [XmlAttribute("LENGTH")]
        public int Length { get; set; }

        public bool ShouldSerializeLength()
        {
            return (Length > 0);
        }

        public JDEXmlColumn()
        {

        }

        public JDEXmlColumn(string table, string alias)
        {
            Table = table;
            Alias = alias;
            Instance = "0";
        }

        public JDEXmlColumn(string table, string alias, string name): this(table, alias)
        {
            Name = name;
            Instance = "0";
        }

        public JDEXmlColumn(string table, string alias, string name, string instance) : this(table, alias, name)
        {
            Instance = instance;
        }

    }
}
