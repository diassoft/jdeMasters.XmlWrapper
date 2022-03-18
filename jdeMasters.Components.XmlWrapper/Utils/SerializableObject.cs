using System;

namespace jdeMasters.Components.XmlWrapper.Utils
{
    public abstract class SerializableObject
    {

        public string SerializeToText(SerializationFormats format = SerializationFormats.Xml)
        {
            return Serializer.SerializeToText(this, format);
        }

        public void SerializeToFile(string filename, SerializationFormats format = SerializationFormats.Xml)
        {
            Serializer.SerializeToFile<object>(this, filename, format);
        }

    }
}
