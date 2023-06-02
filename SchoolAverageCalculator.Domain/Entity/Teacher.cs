using SchoolAverageCalculator.Domain.Common;
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
    }
}
