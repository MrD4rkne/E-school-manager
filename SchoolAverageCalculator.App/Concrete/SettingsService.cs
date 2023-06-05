using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.App.Common;
using SchoolAverageCalculator.Domain.Entity;

namespace SchoolAverageCalculator.App.Concrete
{
    public class SettingsService
    {
        private const string serializerTypeVariable = "serializer";

        private Settings _settings;

        public SettingsService() {
            Load();
        }

        private void Load()
        {
            string settingsFilePath = Path.Combine(FileManager.GetFolder(), "settings.xml");

            _settings = FileManager.LoadFromFile<Settings>(settingsFilePath, SerializerType.XML);

            if(_settings == null)
                _settings= new Settings();
        }

        private void Save()
        {
            string settingsFilePath = Path.Combine(FileManager.GetFolder(), "settings.xml");
            FileManager.SaveToFile<Settings>(_settings, settingsFilePath, SerializerType.XML);
        }

        public SerializerType GetSerializerType()
        {
            return _settings.SerializerType;
        }

        public void SetSerializerType(SerializerType serializer)
        {
            if (_settings.SerializerType != serializer)
            {
                // rewrite previously saved files in this extension
                string directory = FileManager.GetFolder();
                FileManager.Rewrite<List<Mark>>(Path.Combine(directory, "marks" + FileManager.GetProperExtension(_settings.SerializerType)), _settings.SerializerType, serializer);
                FileManager.Rewrite<List<Teacher>>(Path.Combine(directory, "teachers" + FileManager.GetProperExtension(_settings.SerializerType)), _settings.SerializerType, serializer);
                FileManager.Rewrite<List<Student>>(Path.Combine(directory, "students" + FileManager.GetProperExtension(_settings.SerializerType)), _settings.SerializerType, serializer);
                FileManager.Rewrite<List<Subject>>(Path.Combine(directory, "subjects" + FileManager.GetProperExtension(_settings.SerializerType)), _settings.SerializerType, serializer);

                _settings.SerializerType = serializer;
                Save();
            }
        }
    }
}
