using System;
using System.IO;
using System.Xml.Serialization;

namespace PictureEditZoomAndMove
{
    public static class Serialization
    {
        public static string SerializeObject<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        private static object Deserialize(string xml, Type type)
        {
            if (string.IsNullOrEmpty(xml))
                throw new Exception("Failed to deserialize an empty string.");

            using (StringReader reader = new StringReader(xml))
                return GetSerializerFor(type).Deserialize(reader);
        }

        public static T Deserialize<T>(string xml)
        {
            return (T)Deserialize(xml, typeof(T));
        }

        private static XmlSerializer GetSerializerFor(Type type)
        {
            XmlSerializer result;
            result = new XmlSerializer(type);
            return result;
        }
    }
}
