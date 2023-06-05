using ESchoolManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.Domain.Entity
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }

        public int? TeacherId { get; set; }

        public Subject(string name, int? teacherId) {
            Name = name;
            TeacherId = teacherId;
        }

        public Subject(string name) : this(name, null) { }

        /// <summary>
        /// Only for serialization
        /// </summary>
        public Subject() { }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(Subject)) return false;
            Subject comparedSubject = (Subject)obj;
            return (comparedSubject.Name == Name && comparedSubject.TeacherId == TeacherId);
        }
    }
}
