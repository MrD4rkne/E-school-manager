﻿using ESchoolManager.App.Abstract;
using ESchoolManager.App.Helpers;
using ESchoolManager.Domain.Entity;
using ESchoolManager.Domain.ViewModel;
using ESchoolManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Pages.Subjects
{
    public class SummarySubjectPage : ActionPage
    {
        public override string Title => "Summary";

        private int _id = -1;

        private SubjectVM _subject;

        public SummarySubjectPage(int subjectId)
        {
            _id= subjectId;
        }

        public override bool Prepare()
        {
            if (_id == -1)
                return false;

            _subject = MyApp.DataService.GetSubjectVM(_id);
            return _subject != null;
        }

        public override void Action()
        {
            Console.WriteLine($"Name: {_subject.Name}");
            Console.Write("Teacher: ");
            if (_subject.Teacher != null)
            {
                Console.WriteLine(_subject.Teacher);
            }
            Console.WriteLine();
            if (_subject.Averages.Count() > 0)
            {
                Console.WriteLine("Averages:");
                foreach (var tuple in _subject.Averages)
                {
                    Console.WriteLine($"{tuple.Item1}: {(Math.Truncate(tuple.Item2 * 1000) / 1000)}");
                }
            }
            else
            {
                Console.WriteLine("Subject hasn't got any marks yet.");
            }

            Console.WriteLine();
            InputManager.WaitForAnyKey();
        }
    }
}
