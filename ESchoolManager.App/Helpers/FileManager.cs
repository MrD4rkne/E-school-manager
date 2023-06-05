using Newtonsoft.Json;
using ESchoolManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ESchoolManager.App.Helpers
{
    public static class FileManager
    {
        /// <summary>
        /// Save object to file by serialization
        /// </summary>
        /// <typeparam name="T">Object's type</typeparam>
        /// <param name="objectToSave">Object to be serialized</param>
        /// <param name="pathToFile">Path to file where to save serialization</param>
        /// <param name="serializerType">Serializer type</param>
        /// <returns>True if successed, False otherwise</returns>
        /// <exception cref="ArgumentNullException">Path cannot be null</exception>
        public static bool SaveToFile<T>(T objectToSave, string pathToFile, SerializerType serializerType)
        {
            if(string.IsNullOrEmpty(pathToFile)) throw new ArgumentNullException("Path cannot be null");
            if (objectToSave == null)
                return false;
            return WriteToFile(objectToSave, pathToFile, serializerType);
        }

        private static bool WriteToFile<T>(T objectToSave, string pathToFile, SerializerType serializerType)
        {
            string? directory = Path.GetDirectoryName(pathToFile);
            if (string.IsNullOrEmpty(directory))
                return false;
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            using StreamWriter streamWriter = new StreamWriter(pathToFile);
            switch (serializerType)
            {
                case SerializerType.JSON:
                    return JSONSerialize(objectToSave, streamWriter);
                case SerializerType.XML:
                    return XMLSerialize(objectToSave, streamWriter);
                case SerializerType.CSV:
                    return CSVSerialize<T>(objectToSave,streamWriter);
                default: throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Load object from file
        /// </summary>
        /// <typeparam name="T">Object to be deserialized</typeparam>
        /// <param name="pathToFile">Path to file</param>
        /// <param name="serializerType">Serializer type</param>
        /// <returns>Deserialized object or default, if file does not exist</returns>
        /// <exception cref="ArgumentNullException">Path cannot be null</exception>
        public static T? LoadFromFile<T>(string pathToFile, SerializerType serializerType)
        {
            if (string.IsNullOrEmpty(pathToFile)) throw new ArgumentNullException("Path cannot be null");
            return ReadFromFile<T>(pathToFile, serializerType);
        }

        private static T? ReadFromFile<T>(string pathToFile, SerializerType serializerType)
        {
            if (!File.Exists(pathToFile))
                return default(T);

            using StreamReader streamReader = new StreamReader(pathToFile);
            switch (serializerType)
            {
                case SerializerType.JSON:
                    return JSONDeserialize<T>(streamReader);
                case SerializerType.XML:
                    return XMLDeserialize<T>(streamReader);
                case SerializerType.CSV:
                    return CSVDeserialize<T>(streamReader);
                default: throw new NotImplementedException();
            }
        }

        private static bool JSONSerialize<T>(T objToSerialize, StreamWriter streamWriter)
        {
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(jsonWriter, objToSerialize);
            return true;
        }

        private static T? JSONDeserialize<T>(StreamReader streamReader)
        {
            using JsonReader jsonReader = new JsonTextReader(streamReader);
            JsonSerializer jsonSerializer = new JsonSerializer();
            var ret = jsonSerializer.Deserialize<T>(jsonReader);
            return ret;
        }

        private static bool XMLSerialize<T>(T objToSerialize, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(streamWriter, objToSerialize);
            return true;
        }

        private static T? XMLDeserialize<T>(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            var ret = xmlSerializer.Deserialize(streamReader);
            if (ret == null)
                return default(T);
            return (T)ret;
        }

        private static bool CSVSerialize<T>(T objToSerialize, StreamWriter streamWriter)
        {
            ServiceStack.Text.CsvSerializer.SerializeToWriter(objToSerialize, streamWriter);
            return true;
        }
        private static T? CSVDeserialize<T>(StreamReader streamReader)
        {
            var ret = ServiceStack.Text.CsvSerializer.DeserializeFromReader<T>(streamReader);
            if (ret == null)
                return default(T);
            return (T)ret;
        }
        
        /// <summary>
        /// Resave file to other serializer Type
        /// </summary>
        /// <typeparam name="T">Type of object previosly serialized</typeparam>
        /// <param name="oldPathToFile">Path to old file</param>
        /// <param name="oldSerializerType">Type of old serializator</param>
        /// <param name="newSerializerType">Type of expectated serializator</param>
        public static void Rewrite<T>(string oldPathToFile, SerializerType oldSerializerType, SerializerType newSerializerType)
        {
            var obj = ReadFromFile<T>(oldPathToFile, oldSerializerType);
            if(obj != null)
            {
                string directory = Path.GetDirectoryName(oldPathToFile);
                string fileName = Path.GetFileNameWithoutExtension(oldPathToFile);
                string newPathToFile = Path.Combine(directory, fileName + GetProperExtension(newSerializerType));
                SaveToFile<T>(obj, newPathToFile, newSerializerType);
            }
            File.Delete(oldPathToFile);
        }

        /// <summary>
        /// Get extension proper for serializer type
        /// </summary>
        /// <param name="serializerType">Serializer type</param>
        /// <returns>Extension like .xml</returns>
        /// <exception cref="NotImplementedException">This serializer type hasn't been yet implemented</exception>
        public static string GetProperExtension(SerializerType serializerType)
        {
            switch(serializerType)
            {
                case SerializerType.CSV:
                    return ".csv";
                case SerializerType.JSON: 
                    return ".json";
                case SerializerType.XML:
                    return ".xml";
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Return folder in documents for this app
        /// User Documents / MSzopa / E-School Manager
        /// </summary>
        /// <returns></returns>
        public static string GetFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MSzopa", "E-School Manager");
        }

    }
    public enum SerializerType { XML, JSON, CSV};
}
