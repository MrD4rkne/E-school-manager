using ESchoolManager.App.Abstract;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Teachers
{
    public class MenuTeachersPage : App.Abstract.MenuPage
    {
        public override string[] Options => new string[] { "List", "Add", "Manage", "Return" };

        public override string Title => "Teachers";

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                case 1:
                    MyApp.Navigation.GoTo(new Teachers.ListTeachersPage(ViewMode.List));
                    break;
                case 2:
                    MyApp.Navigation.GoTo(new Teachers.AddTeacherPage());
                    break;
                case 3:
                    MyApp.Navigation.GoTo(new Teachers.ListTeachersPage(ViewMode.Manage));
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
