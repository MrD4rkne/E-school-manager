using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Pages.Subjects
{
    public class EditSubjectPage : MenuPage
    {
        public override string Title => "Edit";

        public override string[] Options => new string[] { "Name", "Teacher", "Save & Return", "Abort & Return", "Marks","Delete" };

        public override void Action()
        {
            Console.WriteLine($"Name: {_subject.Name}");
            Console.Write("Teacher: ");
            if(_subject.TeacherId.HasValue && MyApp.DataService.TeachersService.GetItemById(_subject.TeacherId.Value) is Teacher t)
            {
                Console.WriteLine(t);
            }
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
                    _subject.Name = InputManager.GetTextInput("New Name*: ", false);
                    break;
                case 2:
                    Console.Clear();
                    Teacher? teacher = DrawManager.SelectEntityOrSkip("Select teacher to be assigned or none", "None", MyApp.DataService.TeachersService);
                    if (teacher != null)
                    {
                        _subject.TeacherId = teacher.Id;
                    }
                    else
                        _subject.TeacherId = null;
                    break;
                case 3:
                    MyApp.DataService.SubjectsService.UpdateItem(_subject);
                    return;                
                case 4:
                    return;
                case 5:
                    Console.Clear();
                    Student? receive = DrawManager.SelectEntityOrSkip("Select student to manage marks or return", "Return", MyApp.DataService.StudentsService);
                    if (receive != null)
                    {
                        MyApp.Navigation.GoTo(new Marks.MenuMarksPage(_subjectId, receive.Id));
                    }
                    break;
                case 6:
                    Console.Clear();
                    bool isSuccess = MyApp.DataService.SubjectsService.RemoveItem(_subject);
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
        private int _subjectId;
        private Subject _subject;
        public EditSubjectPage(int id)
        {
            _subjectId = id;
        }

        public override bool Prepare()
        {
            var subject = MyApp.DataService.SubjectsService.GetItemById(_subjectId);
            if (subject == null)
            {
                throw new InvalidDataException("Subject doesn't exist");
            }
            _subject = (Subject)subject.ShallowCopy();
            return true;
        }
    }
}
