using SchoolAverageCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Entity
{
    public class Mark : BaseEntity
    {
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string? Description { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        public Mark(int studentId, int subjectId, decimal value, decimal weight, string? description)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            Value = value;
            Weight = weight;
            Description = description;
        }
        public Mark(int studentId, int subjectId, decimal value, decimal weight) : this(studentId, subjectId, value, weight, string.Empty) { }
        public override string ToString()
        {
            return $"Value: {Value} Weight: {Weight} Description: \"{Description}\"";
        }

    }
}
