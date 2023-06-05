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

namespace SchoolAverageCalculator.Pages.Marks
{
    public class ListMarksPage : ActionPage
    {
        public override string Title => "List";

        private int? _subjectId;

        private int? _studentId;

        private List<Mark> _marks;

        public ListMarksPage(int? subjectId, int? studentId)
        {
            _subjectId = subjectId;
            _studentId = studentId;
        }

        public override bool Prepare()
        {
            if (MyApp.DataService.MarksService == null)
            {
                throw new InvalidDataException("MarksService isn't initialized!");
            }
            if (!MyApp.DataService.StudentsService.HasAnyItems())
            {
                throw new InvalidDataException("There aren't any registered marks!");
            }

            if (_subjectId == _studentId)
            {
                if (_subjectId == null)
                    throw new InvalidDataException("Id's cannot be null");
            }


            if (_subjectId != null && _studentId != null)
            {
                _marks = MyApp.DataService.MarksService.GetStudentMarks(_studentId.Value, _subjectId.Value);
            }
            else
            {
                if (_subjectId != null)
                {
                    _marks = MyApp.DataService.MarksService.GetSubjectMarks(_subjectId.Value);
                }
                else
                {
                    _marks = MyApp.DataService.MarksService.GetStudentMarks(_studentId.Value);
                }
            }

            return true;
        }

        public override void Action()
        {
            var input = DrawManager.SelectEntityOrSkip($"Please select mark to view info return:", "Return", _marks);
            if (input == null)
                return;

            MyApp.Navigation.GoTo(new Marks.EditMarkPage(input.Id));
        }
    }
    public enum ViewMode { Subject,Mark };
}
