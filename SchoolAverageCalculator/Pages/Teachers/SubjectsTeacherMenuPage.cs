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
    public class SubjectsTeacherMenuPage : ActionPage
    {
        public override string Title => "Teaching subjects";

        private int? _teacherId;
        private Subject[] _subjects;
        public SubjectsTeacherMenuPage(int? teacherId)
        {
            _teacherId = teacherId;
        }

        public override bool Prepare()
        {
            if (!_teacherId.HasValue)
            {
                throw new InvalidDataException("Teacher id cannot be null");
            }

            _subjects = MyApp.DataService.SubjectsService.GetSubjectsForTeacher(_teacherId.Value);

            if (_subjects == null || _subjects.Length == 0)
            {
                throw new InvalidDataException("Teacher has not got any subjects assigned!");
            }
            return true;

        }

        public override void Action()
        {
            Console.WriteLine("Subjects:");
            for(int i = 0; i< _subjects.Length; i++)
            {
                Console.WriteLine(_subjects[i].Name);
            }

            Console.WriteLine();
            InputManager.WaitForAnyKey();
        }
    }
}
