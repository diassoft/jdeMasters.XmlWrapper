using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.Utils
{
    public static class Serializer
    {

        public static string SerializeToText<T>(T objectToSerialize, SerializationFormats format = SerializationFormats.Xml)
        {
            // Initializes the Serializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            return RunXmlSerializaion(objectToSerialize, xmlSerializer, format == SerializationFormats.Xml ? true : false);
        }

        public static string SerializeToText(object objectToSerialize, SerializationFormats format = SerializationFormats.Xml)
        {
            // Initializes the Serializer
            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            return RunXmlSerializaion(objectToSerialize, xmlSerializer, format == SerializationFormats.Xml ? true : false);
        }

        private static string RunXmlSerializaion(object objectToSerialize, XmlSerializer serializer, bool addNamespace = false)
        {
            using (StringWriter strWriter = new StringWriter())
            {
                if (addNamespace)
                {
                    // Serialize to String
                    serializer.Serialize(strWriter, objectToSerialize);
                }
                else
                {
                    // Clear Namespaces
                    XmlSerializerNamespaces xSerNs = new XmlSerializerNamespaces();
                    xSerNs.Add("", "");

                    // Serialize to String
                    serializer.Serialize(strWriter, objectToSerialize, xSerNs);
                }

                // Return the serialized string
                return strWriter.ToString();
            }
        }

        public static void SerializeToFile<T>(T objectToSerialize, string filename, SerializationFormats format = SerializationFormats.Xml)
        {
            try
            {
                // Perform validations
                if (filename.Trim() == "") throw new ArgumentNullException("filename", "File name must not be blank");

                // Serialize the contents to a string
                string SerializedContent = SerializeToText<T>(objectToSerialize, format);

                // Writes the string to a file
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.Write(SerializedContent);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static T DeserializeFromText<T>(string text, SerializationFormats format = SerializationFormats.Xml)
        {
            // Verify format
            if (format == SerializationFormats.Json)
            {
                // Process in Json Format
                return default(T);
            }
            else
            {
                // Process in Xml Format
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                using (TextReader tr = new StringReader(text))
                {
                    return (T)xmlSer.Deserialize(tr);
                }
            }
        }

        public static T DeserializeFromFile<T>(string filename, SerializationFormats format = SerializationFormats.Xml)
        {
            // Verify format
            if (format == SerializationFormats.Json)
            {
                // Process in Json format
                return default(T);
            }
            else
            {
                // Process in Xml Format
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                using (TextReader sr = new StreamReader(filename))
                {
                    return (T)xmlSer.Deserialize(sr);
                }
            }
        }

    }

    public enum SerializationFormats : int
    {
        Xml = 0,
        XmlWithoutNamespaces = 1,
        Json = 2
    }
}
