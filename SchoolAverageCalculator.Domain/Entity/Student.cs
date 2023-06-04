﻿using SchoolAverageCalculator.Domain.Common;
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
        /// <summary>
        /// Only for serialization
        /// </summary>
        public Student() { }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Student)) return false;
            Student toCompare = (Student)obj;
            return (toCompare.Id == Id && toCompare.FirstName == FirstName && toCompare.MiddleName == MiddleName && toCompare.LastName == LastName);
        }
    }
}
