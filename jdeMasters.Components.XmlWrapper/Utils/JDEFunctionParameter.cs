using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.Utils;

namespace jdeMasters.Components.XmlWrapper.Utils
{
    public class JDEFunctionParameter
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlIgnore]
        public JDEValue Value { get; set; }

        /// <summary>
        /// Defines a name for the ID to be used as a reference in additional CallMethod requests inside the same JdeXmlRequest
        /// </summary>
        [XmlAttribute("id")]
        public string ParameterId { get; set; }

        public bool ShouldSerializeParamaterId()
        {
            return (ParameterId != null);
        }

        /// <summary>
        /// Defines a reference to a previously created parameter.
        /// </summary>
        [XmlAttribute("idref")]
        public string ParameterIdReference { get; set; }

        public bool ShouldSerializeParamaterIdReference()
        {
            // There is a parameter ID setup, so do not print the reference even if accidentally there is data on that property
            if (ParameterId != null) return false;

            return (ParameterIdReference != null);
        }

        [XmlText(typeof(string))]
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

        public JDEFunctionParameter()
        {
            
        }

        public JDEFunctionParameter(string name, JDEValue value)
        {
            Name = name;
            Value = value;
        }

        public JDEFunctionParameter(string name, string text)
        {
            Name = name;
            Value = new JDEValue(text);
        }

        public JDEFunctionParameter(string name, string text, int characterCount, bool rightAlign = false)
        {
            Name = name;
            Value = new JDEValue(text, characterCount, rightAlign);
        }

        public JDEFunctionParameter(string name, int integer)
        {
            Name = name;
            Value = new JDEValue(integer);
        }

        public JDEFunctionParameter(string name, DateTime date)
        {
            Name = name;
            Value = new JDEValue(date);
        }

        public JDEFunctionParameter(string name, double numeric)
        {
            Name = name;
            Value = new JDEValue(numeric);
        }

        public JDEFunctionParameter(string name, double numeric, int decimals)
        {
            Name = name;
            Value = new JDEValue(numeric, decimals);
        }



    }
}
