using ESchoolManager.App.Abstract;
using ESchoolManager.App.Helpers;
using ESchoolManager.Domain.Entity;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Teachers
{
    public class EditTeacherPage : MenuPage
    {
        public override string Title => "Edit";

        public override string[] Options => new string[] { "First Name", "Middle Name", "Last Name", "Save & Return", "Abort & Return", "Subjects", "Delete"  };

        private int _teacherId;

        private Teacher _teacher;
        public EditTeacherPage(int id)
        {
            _teacherId = id;
        }

        public override bool Prepare()
        {
            var teacher = MyApp.DataService.TeachersService.GetItemById(_teacherId);
            if (teacher == null)
            {
                throw new InvalidDataException("Teacher doesn't exist");
            }
            _teacher = (Teacher)teacher.ShallowCopy();
            return true;
        }

        public override void Action()
        {
            Console.WriteLine($"First Name: {_teacher.FirstName}");
            Console.WriteLine($"Middle Name: {_teacher.MiddleName}");
            Console.WriteLine($"Last Name: {_teacher.LastName}");
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
                    _teacher.FirstName = InputManager.GetTextInput("New first Name*: ", false);
                    break;
                case 2:
                    _teacher.MiddleName = InputManager.GetTextInput("New middle Name: ", true);
                    break;
                case 3:
                    _teacher.LastName = InputManager.GetTextInput("New last Name*: ", false);
                    break;
                case 4:
                    MyApp.DataService.TeachersService.UpdateItem(_teacher);
                    return;
                case 5:
                    return;
                case 6:
                    //MyApp.Navigation.GoTo(new Marks.ManageMarksPage(_teacher.Id));
                    Console.Clear();
                    break;
                case 7:
                    Console.Clear();
                    bool isSuccess = MyApp.DataService.TeachersService.RemoveItem(_teacher);
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
