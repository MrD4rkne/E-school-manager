using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages.Students
{
    public class MenuStudentsPage : App.Abstract.MenuPage
    {
        public override string[] Options => new string[] { "List", "Add", "Manage", "Return" };

        public override string Title => "Students";

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                case 1:
                    MyApp.Navigation.GoTo(new Students.ListStudentsPage(ViewMode.List));
                    break;
                case 2:
                    MyApp.Navigation.GoTo(new Students.AddStudentPage());
                    break;
                case 3:
                    MyApp.Navigation.GoTo(new Students.ListStudentsPage(ViewMode.Manage));
                    break;
                case 4:
                    return;
                default:
                    base.HandleChoice(option);
                    return;
            }
            MyApp.Navigation.RefreshPage(false);
        }
    }
}
