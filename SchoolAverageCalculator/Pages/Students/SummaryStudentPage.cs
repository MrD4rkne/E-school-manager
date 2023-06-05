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

namespace SchoolAverageCalculator.Pages.Students
{
    public class SummaryStudentPage : ActionPage
    {
        public override string Title => "Summary";
        
        private int _id = -1;

        private StudentVM _student;

        public SummaryStudentPage(int studentId)
        {
            _id= studentId;
        }
        public override bool Prepare()
        {
            if (_id == -1)
                return false;

            _student = MyApp.DataService.GetStudentVM(_id);
            return _student != null;
        }

        public override void Action()
        {
            Console.WriteLine(_student);
            Console.WriteLine();
            InputManager.WaitForAnyKey();
        }
    }
}
