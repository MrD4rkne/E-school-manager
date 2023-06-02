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

namespace SchoolAverageCalculator.Pages.Students
{
    public class ListStudentsPage : ActionPage
    {
        private ViewMode _viewMode;
        public override string Title => Enum.GetName(typeof(ViewMode), _viewMode);


        public ListStudentsPage(ViewMode viewMode) : base()
        {
            _viewMode = viewMode;
        }

        public override void Action()
        {
            switch (_viewMode)
            {
                case ViewMode.List:
                    var input = DrawManager.SelectEntityOrSkip<Student>($"Please select student to view info return:", "Return", MyApp.DataService.StudentsService);
                    if (input == null)
                        return;

                    MyApp.Navigation.GoTo(new Students.SummaryStudentPage(input.Id));
                    return;
                case ViewMode.Manage:

                    var input2 = DrawManager.SelectEntityOrSkip<Student>($"Please select student to manage or return:", "Return", MyApp.DataService.StudentsService);
                    if (input2 == null)
                        return;
                    MyApp.Navigation.GoTo(new Students.EditStudentPage(input2.Id));

                    return;
            }
        }

        public override bool Prepare()
        {
            if (MyApp.DataService.MarksService == null)
            {
                throw new InvalidDataException("StudentsService isn't initialized!");
            }
            if (!MyApp.DataService.StudentsService.HasAnyItems())
            {
                throw new InvalidDataException("There aren't any registered students!");
            }
            return true;
        }
    }
    public enum ViewMode { List, Manage };
}
