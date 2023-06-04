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
        private int _id = -1;

        private TeacherVM _teacher;

        public SummaryTeacherPage(int studentId)
        {
            _id= studentId;
        }

        public override void Action()
        {
            Console.WriteLine(_teacher);
            Console.WriteLine();
            InputManager.WaitForAnyKey();
        }

        public override bool Prepare()
        {
            if (_id == -1)
                return false;

            _teacher = MyApp.DataService.GetTeacherVM(_id);
            return _teacher != null;
        }
    }
}
