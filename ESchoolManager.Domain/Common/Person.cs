using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ESchoolManager.Domain.Common
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

        public string GetFullName()
        {
            string fullName = FirstName + " ";
            if (!string.IsNullOrEmpty(MiddleName))
            {
                fullName += MiddleName + " ";
            }
            fullName += LastName;

            return fullName;
        }

        public override string ToString()
        {
            return GetFullName();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Person)) return false;
            Person comparedPerson = (Person)obj;
            return (comparedPerson.Id == Id && comparedPerson.FirstName == FirstName && comparedPerson.MiddleName == MiddleName && comparedPerson.LastName == LastName);
        }
    }
}
