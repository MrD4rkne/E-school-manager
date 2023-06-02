using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.ViewModel
{
    public class SubjectVM
    {
        public string Name { get; set; }
        public Teacher? Teacher { get; set; }
        public Tuple<Student, decimal>[] Averages { get; set; }
        public SubjectVM(string name, Tuple<Student, decimal>[] averages) : this(name, null, averages){ 
        }
        public SubjectVM(string name, Teacher? teacher, Tuple<Student, decimal>[] averages)
        {
            Name = name;
            Teacher = teacher;
            Averages = averages;
        }
    }
}
