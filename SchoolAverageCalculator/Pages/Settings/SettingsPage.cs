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
    public class SettingsPage : MenuPage
    {
        public override string Title => "Settings";

        public override string[] Options => new string[] { "Save data", "Reload data", "Clear data","Manage files' extensions", "Return" };

        public override void HandleChoice(int option)
        {
            switch (option) {
                default: 
                    base.HandleChoice(option); 
                    return;
                case 1:
                    if(DrawManager.ConfirmationMenu("Are you sure to save data? Your previous data will be overwritten."))
                    {
                        Console.Clear();
                        MyApp.DataService.SaveData(FileManager.GetFolder(), MyApp.SettingsService.GetSerializerType());
                        Console.WriteLine("Data saved!");
                        Console.WriteLine();
                        InputManager.WaitForAnyKey();
                        
                    }
                    break;
                case 2:
                    if (DrawManager.ConfirmationMenu("Are you sure to reload data? Your unsaved changes will be lost."))
                    {
                        Console.Clear();
                        MyApp.DataService.LoadData(FileManager.GetFolder(), MyApp.SettingsService.GetSerializerType());
                        Console.WriteLine("Data reloaded!");
                        Console.WriteLine();
                        InputManager.WaitForAnyKey();

                    }
                    break;
                case 3:
                    if (DrawManager.ConfirmationMenu("Are you sure to clear data? Your unsaved changes will be lost. This won't remove previosly saved data"))
                    {
                        Console.Clear();
                        MyApp.DataService.ClearData();
                        Console.WriteLine("Data cleared!");
                        Console.WriteLine();
                        InputManager.WaitForAnyKey();

                    }
                    break;
                case 4:
                    MyApp.Navigation.GoTo(new Settings.ExtensionsPage());
                    break;
                case 5:
                    return;
            }
            MyApp.Navigation.RefreshPage();
        }
    }
}
