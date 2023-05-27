using SchoolAverageCalculator.App.Abstract;
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
    public class EditMarkPage : MenuPage
    {
        private int _markId;
        public EditMarkPage(int id) { _markId = id; }
        public override string Title => "Edit mark";

        public override string[] Options => new string[] {"Value","Weight","Description","Delete","Abort", "Save & Return"};

        private Mark _mark;

        public override void Action()
        {
            // present mark
            Console.WriteLine($"Value: {_mark.Value}");
            Console.WriteLine($"Weight: {_mark.Weight}");
            Console.WriteLine($"Description: {_mark.Description}");
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
                    _mark.Value = InputManager.GetDecimalInput("New value: ");
                    break;
                case 2:
                    _mark.Weight = InputManager.GetDecimalInput("New weight: ");
                    break;
                case 3:
                    _mark.Description = InputManager.GetTextInput("New description: ", true);
                    break;
                case 4:
                    Console.Clear();
                    bool isSuccess = MyApp.MarksService.RemoveItem( _mark );
                    if (isSuccess)
                    {
                        Console.WriteLine("Success!");
                    }
                    else
                        Console.WriteLine("Something went wrong.");
                    InputManager.WaitForAnyKey();
                    MyApp.Navigation.GoBack();
                    return;
                case 5:
                    MyApp.Navigation.GoBack();
                    return;
                case 6:
                    MyApp.MarksService.UpdateItem(_mark);
                    MyApp.Navigation.GoBack();
                    return;
            }
            MyApp.Navigation.RefreshPage();
        }

        public override bool Prepare()
        {
            _mark = Mark.Duplicate(MyApp.MarksService.WithId(_markId));
            if (_mark == null)
            {
                Console.WriteLine("Mark doesn't exist");
                InputManager.WaitForAnyKey();
                MyApp.Navigation.GoBack();
                return false;
            }
            return true;
        }
    }
}
