using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.ViewModel
{
    public class StudentVM
    {
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }


        public List<Tuple<string, decimal>> Averages { get; set; }

        public StudentVM(string firstName, string? middleName, string lastName, List<Tuple<string, decimal>> averages) { 
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Averages = averages;
        }

        public StudentVM(string firstName, string lastName) : this(firstName,null,lastName) { }

        public StudentVM(string firstName, string? middleName, string lastName) : this(firstName,middleName,lastName,new()){ }

        public StudentVM(string firstName, string lastName, List<Tuple<string, decimal>> averages) : this(firstName, null, lastName, averages) { }

        public override bool Equals(object? obj)
        {
            if(obj==null)
                return base.Equals(obj);
            if(obj is StudentVM comparedStudentVM)
            {
                if (comparedStudentVM.FirstName != FirstName)
                    return false;
                if (comparedStudentVM.MiddleName != MiddleName && (!string.IsNullOrEmpty(comparedStudentVM.MiddleName) || !string.IsNullOrEmpty(MiddleName)))
                    return false;
                if (comparedStudentVM.LastName != LastName)
                    return false;

                if ((comparedStudentVM.Averages == null && Averages != null) || (comparedStudentVM.Averages != null && Averages == null))
                    return false;
                if (comparedStudentVM.Averages != null)
                {
                    if (comparedStudentVM.Averages.Count != Averages.Count)
                        return false;

                    return !comparedStudentVM.Averages.Except(Averages).Any() && !Averages.Except(comparedStudentVM.Averages).Any();
                }

                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string stringOfObject = string.Empty;
            stringOfObject += "Personal data:" + Environment.NewLine;

            stringOfObject+= $"First Name: {FirstName}" + Environment.NewLine;
            stringOfObject+= $"Middle Name: {MiddleName}" + Environment.NewLine;
            stringOfObject += $"Last Name: {LastName}" + Environment.NewLine;
            stringOfObject += Environment.NewLine;
            if (Averages.Count > 0)
            {
                stringOfObject+= "Averages:" + Environment.NewLine;
                foreach (var tuple in Averages)
                {
                    stringOfObject += $"{tuple.Item1}: {(Math.Truncate(tuple.Item2 * 1000) / 1000)}" + Environment.NewLine;
                }
            }
            else
            {
                stringOfObject += "Student hasn't got any marks yet." + Environment.NewLine;
            }
            return stringOfObject;
        }
    }
}
