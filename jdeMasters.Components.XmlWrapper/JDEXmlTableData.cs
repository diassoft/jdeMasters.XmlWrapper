using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    [DataContract]
    public sealed class JDEXmlTableData
    {
        [XmlAttribute("NAME")]
        [DataMember]
        public string Name { get; set; }

        [XmlElement("COLUMN")]
        [DataMember]
        public ObservableCollection<JDEXmlTableDataColumn> Columns { get; set; }

        [XmlIgnore]
        [DataMember]
        public Dictionary<string, string> ColumnDictionary { get; set; }

        public JDEXmlTableData()
        {
            Name = "";
            ColumnDictionary = new Dictionary<string, string>();
            Columns = new ObservableCollection<JDEXmlTableDataColumn>();
            Columns.CollectionChanged += Columns_CollectionChanged;
        }

        private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Updates dictionary with field content to make it easier to do the inquiries
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (JDEXmlTableDataColumn item in e.NewItems)
                {
                    if (ColumnDictionary.ContainsKey(item.Alias)) ColumnDictionary[item.Alias] = item.Value;
                    else ColumnDictionary.Add(item.Alias, item.Value);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (JDEXmlTableDataColumn item in e.NewItems)
                {
                    if (ColumnDictionary.ContainsKey(item.Alias)) ColumnDictionary.Remove(item.Alias);
                }
            }
        }
    }
}
