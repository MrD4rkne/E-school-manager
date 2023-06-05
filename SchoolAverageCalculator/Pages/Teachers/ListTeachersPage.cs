using Microsoft.VisualBasic;
using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages.Teachers
{
    public class ListTeachersPage : ActionPage
    {
        private ViewMode _viewMode;

        public override string Title => Enum.GetName(typeof(ViewMode), _viewMode);

        public ListTeachersPage(ViewMode viewMode) : base()
        {
            _viewMode = viewMode;
        }

        public override bool Prepare()
        {
            if (MyApp.DataService.TeachersService == null)
            {
                throw new InvalidDataException("TeachersService isn't initialized!");
            }
            if (!MyApp.DataService.TeachersService.HasAnyItems())
            {
                throw new InvalidDataException("There aren't any registered teachers!");
            }
            return true;
        }

        public override void Action()
        {
            switch (_viewMode)
            {
                case ViewMode.List:
                    var input = DrawManager.SelectEntityOrSkip($"Please select teacher to view info return:", "Return", MyApp.DataService.TeachersService);
                    if (input == null)
                        return;

                    MyApp.Navigation.GoTo(new Teachers.SummaryTeacherPage(input.Id));
                    return;
                case ViewMode.Manage:

                    var input2 = DrawManager.SelectEntityOrSkip($"Please select teacher to manage or return:", "Return", MyApp.DataService.TeachersService);
                    if (input2 == null)
                        return;
                    MyApp.Navigation.GoTo(new Teachers.EditTeacherPage(input2.Id));

                    return;
            }
        }
    }
    public enum ViewMode { List, Manage };
}
