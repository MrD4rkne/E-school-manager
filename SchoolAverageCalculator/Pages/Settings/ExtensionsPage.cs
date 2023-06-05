using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages.Settings
{
    public class ExtensionsPage : MenuPage
    {
        public override string[] Options => new string[] {"XML", "JSON", "CSV", "Return"};

        public override string Title => "Manage extensions";

        public override void Draw()
        {
            Console.Clear();
            Console.WriteLine($"Current extension: {Enum.GetName(typeof(SerializerType), MyApp.SettingsService.GetSerializerType())}");
            Console.WriteLine();
            PresentChoice("Choose extension to be used or return");
        }

        public override void HandleChoice(int option)
        {
            switch (option) {
                default:
                    base.HandleChoice(option);
                    break;
                case 1:
                    MyApp.SettingsService.SetSerializerType(SerializerType.XML);
                    break;
                case 2:
                    MyApp.SettingsService.SetSerializerType(SerializerType.JSON);
                    break;
                case 3:
                    MyApp.SettingsService.SetSerializerType(SerializerType.CSV);
                    break;
                case 4:
                    return;
            }
            MyApp.Navigation.RefreshPage();
        }
    }
}
