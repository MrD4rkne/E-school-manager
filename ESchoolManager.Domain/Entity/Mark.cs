using ESchoolManager.Domain.Common;
using ESchoolManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESchoolManager.Domain.Entity
{
    public class Mark : BaseEntity
    {
        public decimal Value { get; set; }

        public decimal Weight { get; set; }

        public string? Description { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        /// <summary>
        /// Only for serialization
        /// </summary>
        public Mark() { }

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

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Mark)) return false;
            Mark comparedMark = (Mark)obj;
            return (comparedMark.Id == Id && comparedMark.Value == Value && comparedMark.Weight == Weight && (comparedMark.Description == Description || (string.IsNullOrEmpty(comparedMark.Description) && string.IsNullOrEmpty(Description))) && comparedMark.StudentId == StudentId && comparedMark.SubjectId == SubjectId);
        }

    }
}
