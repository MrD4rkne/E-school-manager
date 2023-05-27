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
    public class SummaryPage : ActionPage
    {

        public override string Title => "Summary";
        public override void Action()
        {
            var marks = MyApp.MarksService.Items;
            decimal average = MyApp.MarksService.CountAverage();

            Console.WriteLine($"Your marks's average is {average}");
            foreach(Mark mark in marks)
            {
                Console.WriteLine(mark.ToString());
            }
            Console.WriteLine();
            InputManager.WaitForAnyKey();
            MyApp.Navigation.GoBack();
        }
        public override bool Prepare()
        {
            // if there is anything to summarise
            if (!MyApp.MarksService.HasAnyItems())
            {
                Console.WriteLine("You don't have any marks!");
                InputManager.WaitForAnyKey();
                MyApp.Navigation.GoBack();
                return false;
            }
            return true;
        }
    }
}
