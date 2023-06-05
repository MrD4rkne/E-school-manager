using ESchoolManager.App.Abstract;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Subjects
{
    public class MenuSubjectsPage : App.Abstract.MenuPage
    {
        public override string[] Options => new string[] { "List", "Add", "Manage", "Return" };

        public override string Title => "Subjects";

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                case 1:
                    MyApp.Navigation.GoTo(new Subjects.ListSubjectsPage(ViewMode.List));
                    break;
                case 2:
                    MyApp.Navigation.GoTo(new Subjects.AddSubjectPage());
                    break;
                case 3:
                    MyApp.Navigation.GoTo(new Subjects.ListSubjectsPage(ViewMode.Manage));
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
