using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages
{
    public class AddMarkPage : ActionPage
    {

        public override string Title => "Add Mark";
        public override void Action()
        {
            Console.WriteLine("Please enter mark's properties:");
            decimal value = InputManager.GetDecimalInput("Value: ");
            decimal weight = InputManager.GetDecimalInput("Weight: ");
            string? description = InputManager.GetTextInput("Description: ", true);
            // create new mark
            Mark mark = new Mark(value, weight, description);
            MyApp.MarksService.AddItem(mark);
            Console.WriteLine();
            Console.WriteLine("Mark created successfully!");
            InputManager.WaitForAnyKey();
            MyApp.Navigation.GoBack();
        }

        public override bool Prepare()
        {
            return true;
        }
    }
}
