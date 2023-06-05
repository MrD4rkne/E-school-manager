using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Domain.ViewModel;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages.Teachers
{
    public class SummaryTeacherPage : ActionPage
    {
        public override string Title => "Summary";

        private int _teacherId = -1;

        private TeacherVM _teacher;

        public SummaryTeacherPage(int studentId)
        {
            _teacherId= studentId;
        }

        public override bool Prepare()
        {
            if (_teacherId == -1)
                return false;

            _teacher = MyApp.DataService.GetTeacherVM(_teacherId);
            return _teacher != null;
        }

        public override void Action()
        {
            Console.WriteLine(_teacher);
            Console.WriteLine();
            InputManager.WaitForAnyKey();
        }
    }
}
