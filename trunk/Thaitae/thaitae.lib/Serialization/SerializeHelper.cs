using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace IConcepts.Net.Serialization
{
    public static class SerializeHelper
    {
        public static string Serialize<T>(T graph, IEnumerable<Type> types = null)
        {
            return Serialize(typeof(T), graph, types);
        }

        public static string Serialize(Type type, object graph, IEnumerable<Type> types = null)
        {
            using (var writer = new StringWriter())
            using (var xmlWriter = new XmlTextWriter(writer))
            {
                var ser = new DataContractSerializer(type, types);
                ser.WriteObject(xmlWriter, graph);
                return writer.ToString();
            }
        }

        public static T Deserialize<T>(string xml, IEnumerable<Type> types = null) where T : class
        {
            return Deserialize(typeof(T), xml, types) as T;
        }

        public static object Deserialize(Type type, string xml, IEnumerable<Type> types = null)
        {
            using (var reader = new StringReader(xml))
            using (var xmlReader = new XmlTextReader(reader))
            {
                var ser = new DataContractSerializer(type, types);
                return ser.ReadObject(xmlReader);
            }
        }
    }
}