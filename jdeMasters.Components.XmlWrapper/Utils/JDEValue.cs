using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.Utils
{
    public class JDEValue
    {

        [XmlIgnore]
        public JDEValueTypes Type { get; }

        [XmlIgnore]
        public object Value { get; set; }

        public int Decimals { get; set; }

        public JDEValue()
        {
            Value = "";
            Type = JDEValueTypes.Text;
        }

        public JDEValue(string value)
        {
            Value = value;
            Type = JDEValueTypes.Text;
        }

        public JDEValue(string value, int characterCount, bool rightAlign = false)
        {
            if (rightAlign)
                Value = value.Trim().PadRight(characterCount).Substring(0, characterCount).Trim().PadLeft(characterCount);
            else
                Value = value.PadRight(characterCount).Substring(0, characterCount).Trim();

            Type = JDEValueTypes.Text;
        }

        public JDEValue(int integer)
        {
            Value = integer;
            Type = JDEValueTypes.Integer;
        }

        public JDEValue(double numeric)
        {
            Value = numeric;
            Type = JDEValueTypes.Numeric;
            Decimals = GetDecimalCount(numeric);
        }

        public JDEValue(double numeric, int decimals)
        {
            Value = Math.Round(numeric, decimals);
            Type = JDEValueTypes.Numeric;
            Decimals = decimals;
        }


        public JDEValue(DateTime date)
        {
            Value = date;
            Type = JDEValueTypes.Date;
        }

        public override string ToString()
        {
            // Verify Type and format it to be serialized properly

            // According to Oracle Documentation, the Numbers should be always passed with:
            //       "," = thousands separator
            //       "." = decimal separator

            if (Type == JDEValueTypes.Integer)
                return Value.ToString();

            else if (Type == JDEValueTypes.Numeric)
                return ((double)Value).ToString(string.Format("N{0}", Decimals), CultureInfo.InvariantCulture);

            else if (Type == JDEValueTypes.Date)
                return ((DateTime)Value).ToString("yyyy/MM/dd");

            else
                return Value.ToString().Trim();
        }

        private int GetDecimalCount(double numeric)
        {
            int i = 0;
            while (Math.Round(numeric, i) != numeric)
                i++;

            return i;
        }
    }

    public enum JDEValueTypes : int
    {
        Text = 0,
        Integer = 1,
        Numeric = 2,
        Date = 3
    }
}
