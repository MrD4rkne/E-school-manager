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
    public class AddTeacherPage : ActionPage
    {
        public override string Title => "Add";
        public override void Action()
        {
            Console.WriteLine("Please enter teacher's properties:");
            string firstName = InputManager.GetTextInput("First Name: ", false);
            string? middleName = InputManager.GetTextInput("Middle Name: ", true);
            string lastName = InputManager.GetTextInput("Last Name: ", false);

            Teacher teacher = new Teacher(firstName, middleName, lastName);
            MyApp.DataService.TeachersService.AddItem(teacher);

            Console.WriteLine();
            Console.WriteLine("Teacher added successfully!");
            InputManager.WaitForAnyKey();
        }


    }
}
