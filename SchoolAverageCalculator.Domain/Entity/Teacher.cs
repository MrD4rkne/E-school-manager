using Newtonsoft.Json.Linq;
using SchoolAverageCalculator.Domain.Common;
using SchoolAverageCalculator.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Entity
{
    public class Teacher : Person
    {
        public Teacher(string firstName, string? secondName, string lastName) : base(firstName, secondName, lastName)
        {
        }

        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        /// <summary>
        /// Only for serialization
        /// </summary>
        public Teacher() { }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Teacher)) return false;
            Teacher comparedTeacher = (Teacher)obj;
            return (comparedTeacher.Id == Id && comparedTeacher.FirstName == FirstName && comparedTeacher.MiddleName == MiddleName && comparedTeacher.LastName == LastName);
        }
    }
}
