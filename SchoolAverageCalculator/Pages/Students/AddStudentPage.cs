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
    public class AddStudentPage : ActionPage
    {
        public override string Title => "Add";
        public override void Action()
        {
            Console.WriteLine("Please enter student's properties:");
            string firstName = InputManager.GetTextInput("First Name*: ", false);
            string? middleName = InputManager.GetTextInput("Middle Name: ", true);
            string lastName = InputManager.GetTextInput("Last Name*: ", false);

            Student student = new Student(firstName, middleName, lastName);
            MyApp.DataService.StudentsService.AddItem(student);

            Console.WriteLine();
            Console.WriteLine("Student added successfully!");
            InputManager.WaitForAnyKey();
        }
    }
}
