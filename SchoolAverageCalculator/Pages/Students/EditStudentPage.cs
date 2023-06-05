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
    public class EditStudentPage : MenuPage
    {
        private int _studentId;

        private Student _student;

        public override string Title => "Edit";

        public override string[] Options => new string[] { "First Name", "Middle Name", "Last Name", "Save & Return", "Abort & Return", "Marks", "Delete" };

        public EditStudentPage(int id)
        {
            _studentId = id;
        }

        public override bool Prepare()
        {
            var student = MyApp.DataService.StudentsService.GetItemById(_studentId);
            if (student == null)
            {
                throw new InvalidDataException("Student doesn't exist");
            }
            _student = (Student)student.ShallowCopy();
            return true;
        }

        public override void Action()
        {
            Console.WriteLine($"First Name: {_student.FirstName}");
            Console.WriteLine($"Middle Name: {_student.MiddleName}");
            Console.WriteLine($"Last Name: {_student.LastName}");
            Console.WriteLine();
        }

        public override void HandleChoice(int option)
        {
            switch (option)
            {
                default:
                    base.HandleChoice(option);
                    return;
                case 1:
                    _student.FirstName = InputManager.GetTextInput("New first Name*: ", false);
                    break;
                case 2:
                    _student.MiddleName = InputManager.GetTextInput("New middle Name: ", true);
                    break;
                case 3:
                    _student.LastName = InputManager.GetTextInput("New last Name*: ", false);
                    break;
                case 4:
                    MyApp.DataService.StudentsService.UpdateItem(_student);
                    return;
                case 5:
                    return;
                case 6:
                    MyApp.Navigation.GoTo(new Marks.ListMarksPage(null, _student.Id));
                    break;
                case 7:
                    Console.Clear();
                    bool isSuccess = MyApp.DataService.StudentsService.RemoveItem(_student);
                    if (isSuccess)
                    {
                        Console.WriteLine("Success!");
                    }
                    else
                        Console.WriteLine("Something went wrong.");
                    InputManager.WaitForAnyKey();
                    return;
            }
            MyApp.Navigation.RefreshPage();
        }
    }
}
