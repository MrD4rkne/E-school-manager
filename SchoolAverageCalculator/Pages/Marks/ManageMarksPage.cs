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
    //public class ManageMarksPage : ActionPage
    //{
    //    public override string Title => "Manage";

    //    public override void Action()
    //    {
    //        var mark = DrawManager.SelectEntityOrSkip<Mark>($"Please select mark to manage or return:", "Return", MyApp.DataService.MarksService);
    //        if (mark == null)
    //        {
    //            return;
    //        }
    //        MyApp.Navigation.GoTo(new EditMarkPage(mark.Id));

    //    }

    //    private int _studentId;
    //    private List<Mark> _marks;

    //    public ManageMarksPage(int studentId)
    //    {
    //        _studentId = studentId;
    //    }

    //    public override bool Prepare()
    //    {
    //        _marks = MyApp.DataService.MarksService.GetStudentMarks(_studentId);

    //        // if there is anything to manage
    //        if (_marks== null || _marks.Count==0)
    //        {
    //            throw new InvalidDataException("This student don't have any marks or doesn't exist!");
    //        }
    //        return true;
    //    }
    //}
}
