using ESchoolManager.App.Abstract;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Marks
{
    public class MenuMarksPage : MenuPage
    {
        public override string Title => "Marks";

        public override string[] Options => (_subjectId.HasValue && _studentId.HasValue) ? new string[] { "List", "Add", "Return" } : new string[] { "List", "Return" };

        private int? _subjectId;

        private int? _studentId;

        public MenuMarksPage(int? subjectId, int? studentId)
        {
            _subjectId = subjectId;
            _studentId = studentId;
        }

        public override bool Prepare()
        {
            // atleast one is should not be null
            if (!_subjectId.HasValue || !MyApp.DataService.SubjectsService.Exists(_subjectId.Value))
            {
                if (!_studentId.HasValue || !MyApp.DataService.StudentsService.Exists(_studentId.Value))
                {
                    throw new InvalidDataException("Student's id is invalid!");
                }
            }
            return true;
        }

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                case 1:
                    MyApp.Navigation.GoTo(new Marks.ListMarksPage(_subjectId, _studentId));
                    break;
                case 2:
                    if ((_subjectId.HasValue && _studentId.HasValue))
                    {
                        MyApp.Navigation.GoTo(new Marks.AddMarkPage(_subjectId, _studentId));
                    }
                    else
                        return;
                    break;
                case 3:
                    return;
            }
            MyApp.Navigation.RefreshPage(false);
        }
    }
}
