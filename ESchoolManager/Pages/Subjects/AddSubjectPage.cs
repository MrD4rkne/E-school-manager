﻿using ESchoolManager.App.Abstract;
using ESchoolManager.App.Helpers;
using ESchoolManager.Domain.Entity;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Subjects
{
    public class AddSubjectPage : ActionPage
    {
        public override string Title => "Add";

        public override void Action()
        {
            Console.WriteLine("Please enter subject's properties:");
            string name = InputManager.GetTextInput("Name*: ", false);

            Subject subject = new Subject(name);

            Teacher? teacher = DrawManager.SelectEntityOrSkip("Select teacher to be assigned or skip", "Skip", MyApp.DataService.TeachersService);
            if (teacher != null)
            {
                subject.TeacherId = teacher.Id;
            }

            MyApp.DataService.SubjectsService.AddItem(subject);

            Console.WriteLine();
            Console.WriteLine("Subject added successfully!");
            InputManager.WaitForAnyKey();
        }


    }
}
