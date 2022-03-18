using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.Utils;
using System.Globalization;

namespace jdeMasters.Components.XmlWrapper
{
    public class JDEXmlJDEValuedField
    {
        [XmlIgnore]
        public JDEValue Value { get; set; }

        [XmlAttribute("VALUE")]
        public string SerializationValue
        {
            get
            {
                if (Value == null) return null;
                return Value.ToString();
            }
            set
            {
                // Verify value to call the proper constructor
                int integer;
                double numeric;
                DateTime date;

                if (int.TryParse(value, out integer))
                    Value = new JDEValue(integer);

                else if (double.TryParse(value, out numeric))
                    Value = new JDEValue(numeric);

                else if (DateTime.TryParseExact(value, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    Value = new JDEValue(date);

                else
                    Value = new JDEValue(value.ToString());
            }
        }

        public JDEXmlJDEValuedField()
        {

        }

        public JDEXmlJDEValuedField(JDEValue value)
        {
            Value = value;
        }
    }
}
