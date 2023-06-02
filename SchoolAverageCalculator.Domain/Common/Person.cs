using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Common
{
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string? middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        public Person(string firstName, string lastName) : this(firstName, null, lastName) { }

        public override string ToString()
        {
            string ret = FirstName + " ";
            if (!string.IsNullOrEmpty(MiddleName))
            {
                ret += MiddleName + " ";
            }
            ret += LastName;

            return ret;
        }
    }
}
