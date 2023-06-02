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

namespace SchoolAverageCalculator.Pages.Marks
{
    public class AddMarkPage : ActionPage
    {

        public override string Title => "Add mark";
        public override void Action()
        {
            Console.WriteLine("Please enter mark's properties:");
            decimal value = InputManager.GetDecimalInput("Value*: ");
            decimal weight = InputManager.GetDecimalInput("Weight*: ");
            string? description = InputManager.GetTextInput("Description: ", true);
            //create new mark
            Mark mark = new(_studentId.Value, _subjectId.Value,value, weight, description);
            MyApp.DataService.MarksService.AddItem(mark);

            Console.WriteLine();
            Console.WriteLine("Mark created successfully!");
            InputManager.WaitForAnyKey();
        }

        private int? _subjectId;
        private int? _studentId;

        public AddMarkPage(int? subjectId, int? studentId)
        {
            _subjectId = subjectId;
            _studentId = studentId;
        }

        public override bool Prepare()
        {
            if(_subjectId == null || !MyApp.DataService.SubjectsService.Exists(_subjectId.Value))
            {
                throw new InvalidDataException("Subject's id is invalid!");
            }
            if (_studentId == null || !MyApp.DataService.StudentsService.Exists(_studentId.Value))
            {
                throw new InvalidDataException("Student's id is invalid!");
            }

            return true;
        }
    }
}
