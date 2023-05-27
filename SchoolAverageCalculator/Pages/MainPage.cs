using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages
{
    public class MainPage : MenuPage
    {

        public override string Title => "Main menu";

        public override string[] Options => new string[]{"See summary", "Add new mark", "Manage existing marks", "Close app"};

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                default: base.HandleChoice(option);
                    return;
                case 1:
                    MyApp.Navigation.GoTo(new SummaryPage());
                    break;
                case 2:
                    MyApp.Navigation.GoTo(new AddMarkPage());
                    break;
                case 3:
                    MyApp.Navigation.GoTo(new ManageMarksPage());
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Closing...");
                    Console.WriteLine("Have a nice day!");
                    InputManager.WaitForAnyKey();
                    Environment.Exit(0);
                    break;
            }
        }

        public override bool Prepare()
        {
            return true;
        }
    }
}
