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
            if(obj is StudentVM vm)
            {
                if (vm.FirstName != FirstName)
                    return false;
                if (vm.MiddleName != MiddleName && (!string.IsNullOrEmpty(vm.MiddleName) || !string.IsNullOrEmpty(MiddleName)))
                    return false;
                if (vm.LastName != LastName)
                    return false;

                if ((vm.Averages == null && Averages != null) || (vm.Averages != null && Averages == null))
                    return false;
                if (vm.Averages != null)
                {
                    if (vm.Averages.Count != Averages.Count)
                        return false;

                    return !vm.Averages.Except(Averages).Any() && !Averages.Except(vm.Averages).Any();
                }

                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string ret = string.Empty;
            ret += "Personal data:" + Environment.NewLine;

            ret+= $"First Name: {FirstName}" + Environment.NewLine;
            ret+= $"Middle Name: {MiddleName}" + Environment.NewLine;
            ret += $"Last Name: {LastName}" + Environment.NewLine;
            ret += Environment.NewLine;
            if (Averages.Count > 0)
            {
                ret+= "Averages:" + Environment.NewLine;
                foreach (var tuple in Averages)
                {
                    ret += $"{tuple.Item1}: {(Math.Truncate(tuple.Item2 * 1000) / 1000)}" + Environment.NewLine;
                }
            }
            else
            {
                ret += "Student hasn't got any marks yet." + Environment.NewLine;
            }
            return ret;
        }
    }
}
