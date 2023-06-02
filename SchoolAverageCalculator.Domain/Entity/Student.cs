using SchoolAverageCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Entity
{
    public class Student : Person
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }
        public Student(string firstName, string? middleName, string lastName) : base(firstName, middleName,lastName)
        {
        }
    }
}
