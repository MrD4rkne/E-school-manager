using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.App.Common;

namespace SchoolAverageCalculator.App.Concrete
{
    public class SettingsService
    {
        public SettingsService() {
            Load();
        }

        private Settings _settings;
        #region LoadAndSave
        private void Load()
        {
            string path = Path.Combine(FileManager.GetFolder(), "settings.xml");

            _settings = FileManager.LoadFromFile<Settings>(path, SerializerType.XML);

            if(_settings == null)
                _settings= new Settings();
        }
        private void Save()
        {
            string path = Path.Combine(FileManager.GetFolder(), "settings.xml");
            FileManager.SaveToFile<Settings>(_settings, path, SerializerType.XML);
        }
        #endregion

        private const string serializerTypeVariable = "serializer";
        public SerializerType GetSerializerType()
        {
            return _settings.SerializerType;
        }
        public void SetSerializerType(SerializerType serializer)
        {
            if (_settings.SerializerType != serializer)
            {
                _settings.SerializerType = serializer;
                Save();
            }
        }
    }
}
