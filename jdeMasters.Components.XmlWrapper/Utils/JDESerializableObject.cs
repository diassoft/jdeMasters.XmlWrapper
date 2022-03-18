using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper.Utils
{
    [DataContract]
    public abstract class JDESerializableObject
    {
        public string SerializeToText(JDESerializationFormats format = JDESerializationFormats.Xml)
        {
            // Initializes the Serializer
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());

            return RunXmlSerialization(xmlSerializer, format == JDESerializationFormats.Xml ? true : false);
        }

        public Task<string> SerializeToTextAsync(JDESerializationFormats format = JDESerializationFormats.Xml)
        {
            return Task.Factory.StartNew(() => SerializeToText(format));
        }

        ///// <summary>
        ///// Places the JDE Request on the XML Dispatch.
        ///// This function must be called thru an async function, using await.
        ///// </summary>
        ///// <param name="jdeRequest">The JDEXmlRequest of type "Call Method" to be processed</param>
        ///// <returns>A Task of type <see cref="JDEXmlOperation"/> based on the Request Type, for asynchronous use.</returns>
        //public Task<JDEXmlOperation> PutRequestAsync(JDEXmlOperation jdeRequest)
        //{
        //    return Task.Factory.StartNew(() => PutRequest(jdeRequest, ActiveToolsReleaseConfig));
        //}

        private string RunXmlSerialization(XmlSerializer serializer, bool addNamespace = false)
        {
            using (StringWriter strWriter = new StringWriter())
            {
                if (addNamespace)
                {
                    // Serialize to String
                    serializer.Serialize(strWriter, this);
                }
                else
                {
                    // Clear Namespaces
                    XmlSerializerNamespaces xSerNs = new XmlSerializerNamespaces();
                    xSerNs.Add("", "");

                    // Serialize to String
                    serializer.Serialize(strWriter, this, xSerNs);
                }

                // Return the serialized string
                return strWriter.ToString();
            }
        }

        public void SerializeToFile(string filename, JDESerializationFormats format = JDESerializationFormats.Xml)
        {
            try
            {
                // Perform validations
                if (filename.Trim() == "") throw new ArgumentNullException("filename", "File name must not be blank");

                // Serialize the contents to a string
                string SerializedContent = SerializeToText(format);

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

        public static T DeserializeFromText<T>(string text, JDESerializationFormats format = JDESerializationFormats.Xml)
        {
            // Verify format
            if (format == JDESerializationFormats.Json)
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

        public static T DeserializeFromFile<T>(string filename, JDESerializationFormats format = JDESerializationFormats.Xml)
        {
            // Verify format
            if (format == JDESerializationFormats.Json)
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

    public enum JDESerializationFormats : int
    {
        Xml = 0,
        XmlWithoutNamespaces = 1,
        Json = 2
    }

}
