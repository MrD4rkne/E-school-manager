using ESchoolManager.App.Abstract;
using ESchoolManager.App.Concrete;
using ESchoolManager.App.Helpers;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages
{
    public class MainPage : MenuPage
    {

        public override string Title => "Main menu";

        public override string[] Options => new string[]{"Students", "Teachers", "Subjects", "Settings","Close app"};

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                default: base.HandleChoice(option);
                    return;
                case 1:
                    MyApp.Navigation.GoTo(new Students.MenuStudentsPage());
                    break;
                case 2:
                    MyApp.Navigation.GoTo(new Teachers.MenuTeachersPage());
                    break;
                case 3:
                    MyApp.Navigation.GoTo(new Subjects.MenuSubjectsPage());
                    break;
                case 4:
                    MyApp.Navigation.GoTo(new Settings.SettingsPage());
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Closing...");
                    Console.WriteLine("Have a nice day!");
                    InputManager.WaitForAnyKey();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
