using Newtonsoft.Json;
using SchoolAverageCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchoolAverageCalculator.App.Helpers
{
    public static class FileManager
    {
        #region Writing
        public static bool SaveToFile<T>(T toSave, string path, SerializerType type)
        {
            if(string.IsNullOrEmpty(path)) throw new ArgumentNullException("Path cannot be null");
            if (toSave == null)
                return false;
            return WriteToFile(toSave, path, type);
        }

        private static bool WriteToFile<T>(T toSerialize, string path, SerializerType type)
        {
            string? directory = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(directory))
                return false;
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            using StreamWriter sw = new StreamWriter(path);
            switch (type)
            {
                case SerializerType.JSON:
                    return JSONSerialize(toSerialize, sw);
                case SerializerType.XML:
                    return XMLSerialize(toSerialize, sw);
                case SerializerType.CSV:
                    return CSVSerialize<T>(toSerialize,sw);
                default: throw new NotImplementedException();
            }
        }
        #endregion
        #region Reading
        public static T? LoadFromFile<T>(string path, SerializerType type)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("Path cannot be null");
            return ReadFromFile<T>(path, type);
        }

        private static T? ReadFromFile<T>(string path, SerializerType type)
        {
            if (!File.Exists(path))
                return default(T);

            using StreamReader sr = new StreamReader(path);
            switch (type)
            {
                case SerializerType.JSON:
                    return JSONDeserialize<T>(sr);
                case SerializerType.XML:
                    return XMLDeserialize<T>(sr);
                case SerializerType.CSV:
                    return CSVDeserialize<T>(sr);
                default: throw new NotImplementedException();
            }
        }
        #endregion


        #region JSON
        private static bool JSONSerialize<T>(T obj, StreamWriter sw)
        {
            using JsonWriter jsonWriter = new JsonTextWriter(sw);
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(jsonWriter, obj);
            return true;
        }
        private static T? JSONDeserialize<T>(StreamReader sr)
        {
            using JsonReader jsonReader = new JsonTextReader(sr);
            JsonSerializer jsonSerializer = new JsonSerializer();
            var ret = jsonSerializer.Deserialize<T>(jsonReader);
            return ret;
        }
        #endregion
        #region XML
        private static bool XMLSerialize<T>(T obj, StreamWriter sw)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(sw, obj);
            return true;
        }
        private static T? XMLDeserialize<T>(StreamReader sr)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            var ret = xmlSerializer.Deserialize(sr);
            if (ret == null)
                return default(T);
            return (T)ret;
        }
        #endregion
        #region CSV
        private static bool CSVSerialize<T>(T obj, StreamWriter sw)
        {
            ServiceStack.Text.CsvSerializer.SerializeToWriter(obj, sw);
            return true;
        }
        private static T? CSVDeserialize<T>(StreamReader sr)
        {
            var ret = ServiceStack.Text.CsvSerializer.DeserializeFromReader<T>(sr);
            if (ret == null)
                return default(T);
            return (T)ret;
        }
        #endregion
        
        public static string GetProperExtension(SerializerType serializerType)
        {
            switch(serializerType)
            {
                case SerializerType.CSV:
                    return ".csv";
                case SerializerType.JSON: 
                    return "json";
                case SerializerType.XML:
                    return ".xml";
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MSzopa", "E-School Manager");
        }

    }
    public enum SerializerType { XML, JSON, CSV};
}
