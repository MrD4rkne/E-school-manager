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
    public class ManageMarksPage : ActionPage
    {
        public override string Title => "Manage marks";

        public override void Action()
        {
            List<string> options = MyApp.MarksService.Items.Select(x => x.ToString()).ToList();
            options.Add("Return");

            int id = DrawManager.DrawMenu("Please select mark to manage or return:", options) ;
            if(id == MyApp.MarksService.Items.Count + 1)
            {
                MyApp.Navigation.GoBack();
                return;
            }

            Mark? mark = MyApp.MarksService.Items.ElementAt(id - 1);
            if (mark == null)
            {
                Console.WriteLine("Error occured: Mark with this id does not exist.");
                return;
            }

            MyApp.Navigation.GoTo(new EditMarkPage(mark.Id));

        }

        public override bool Prepare()
        {
            // if there is anything to manage
            if (!MyApp.MarksService.HasAnyItems())
            {
                Console.WriteLine("You don't have any marks!");
                InputManager.WaitForAnyKey();
                return false;
            }
            return true;
        }
    }
}
