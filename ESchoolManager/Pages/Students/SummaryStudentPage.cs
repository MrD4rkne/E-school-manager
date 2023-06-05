using ESchoolManager.App.Abstract;
using ESchoolManager.App.Helpers;
using ESchoolManager.Domain.Entity;
using ESchoolManager.Domain.ViewModel;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Students
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
