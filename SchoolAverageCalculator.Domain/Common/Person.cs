using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchoolAverageCalculator.Domain.Common
{
    public abstract class Person : BaseEntity
    {
        [DataMember(Name ="FirstName")]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Only for serialization
        /// </summary>
        public Person() { }

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
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Person)) return false;
            Person toCompare = (Person)obj;
            return (toCompare.Id == Id && toCompare.FirstName == FirstName && toCompare.MiddleName == MiddleName && toCompare.LastName == LastName);
        }
    }
}
