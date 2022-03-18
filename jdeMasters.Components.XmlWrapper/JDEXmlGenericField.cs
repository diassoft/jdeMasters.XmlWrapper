using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    public class JDEXmlGenericField<T>
    {
        [XmlText]
        public T InnerText { get; set; }

        public JDEXmlGenericField()
        {
            InnerText = default(T);
        }

        public JDEXmlGenericField(T innerText)
        {
            InnerText = innerText;
        }
    }
}
