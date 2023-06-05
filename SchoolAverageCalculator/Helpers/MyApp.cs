using SchoolAverageCalculator.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Helpers
{
    public static class MyApp
    {
        private static NavigationService? _navigation;

        public static NavigationService Navigation
        {
            get
            {
                if(_navigation == null)
                    throw new NotImplementedException("Navigation has not been initialized!");
                return _navigation;
            }
            private set
            {
                _navigation = value;
            }
        }

        private static DataService? _dataService;

        public static DataService DataService
        {
            get
            {
                if (_dataService == null)
                    throw new NotImplementedException("Marks' service has not been initialized!");
                return _dataService;
            }
            private set
            {
                _dataService = value;
            }
        }

        private static SettingsService? _settingsService;

        public static SettingsService SettingsService
        {
            get
            {
                if (_settingsService == null)
                    throw new NotImplementedException("Settins' service has not been initialized!");
                return _settingsService;
            }
            private set
            {
                _settingsService = value;
            }
        }

        public static void Initialize()
        {
            Navigation = new NavigationService();
            DataService = new DataService();
            SettingsService = new SettingsService();
        }
    }
}
