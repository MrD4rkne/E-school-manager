using SchoolAverageCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Entity
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

        public override string ToString()
        {
            return Name;
        }
    }
}
