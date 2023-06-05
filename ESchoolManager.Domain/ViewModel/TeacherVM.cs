using ESchoolManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Domain.ViewModel
{
    public class TeacherVM
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public List<Subject> Subjects { get; set; }


        public TeacherVM(string firstName, string? middleName, string lastName, List<Subject> subjects) {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Subjects = subjects;
        }
        public TeacherVM(string firstName, string lastName, List<Subject> subjects) : this(firstName, null, lastName, subjects) { }

        public override string ToString()
        {
            string ret = string.Empty;
            ret += "Personal data:" + Environment.NewLine;

            ret += $"First Name: {FirstName}" + Environment.NewLine;
            ret += $"Middle Name: {MiddleName}" + Environment.NewLine;
            ret += $"Last Name: {LastName}" + Environment.NewLine;
            ret += Environment.NewLine;
            if (Subjects.Count > 0)
            {
                ret += "Assigned subjects:" + Environment.NewLine;
                foreach (var subject in Subjects)
                {
                    ret += $"{subject}" + Environment.NewLine;
                }
            }
            else
            {
                ret += "Teacher hasn't got any subjects assigned yet." + Environment.NewLine;
            }
            return ret;
        }
    }
}
