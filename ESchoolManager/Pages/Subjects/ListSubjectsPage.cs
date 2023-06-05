using ESchoolManager.App.Abstract;
using ESchoolManager.App.Helpers;
using ESchoolManager.Domain.Entity;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Subjects
{
    public class ListSubjectsPage : ActionPage
    {
        private ViewMode _viewMode;

        public override string Title => Enum.GetName(typeof(ViewMode), _viewMode);

        public ListSubjectsPage(ViewMode viewMode) : base()
        {
            _viewMode = viewMode;
        }

        public override bool Prepare()
        {
            if (MyApp.DataService.SubjectsService == null)
            {
                throw new InvalidDataException("SubjectsService isn't initialized!");
            }
            if (!MyApp.DataService.SubjectsService.HasAnyItems())
            {
                throw new InvalidDataException("There aren't any registered subjects!");
            }
            return true;
        }

        public override void Action()
        {
            switch (_viewMode)
            {
                case ViewMode.List:
                    var input = DrawManager.SelectEntityOrSkip<Subject>($"Please select subject to view info return:", "Return", MyApp.DataService.SubjectsService);
                    if (input == null)
                        return;

                    MyApp.Navigation.GoTo(new Subjects.SummarySubjectPage(input.Id));
                    return;
                case ViewMode.Manage:
                    var input2 = DrawManager.SelectEntityOrSkip<Subject>($"Please select subject to manage return:", "Return", MyApp.DataService.SubjectsService);
                    if (input2 == null)
                        return;

                    MyApp.Navigation.GoTo(new Subjects.EditSubjectPage(input2.Id));
                    return;
            }
        }
    }
    public enum ViewMode { List, Manage };
}
