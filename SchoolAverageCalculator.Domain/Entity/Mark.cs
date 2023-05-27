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

        public Mark(decimal value, decimal weight, string? description)
        {
            Value = value;
            Weight = weight;
            Description = description;
        }
        public Mark(int id, decimal value, decimal weight, string? description) : this(value,weight, description)
        {
            Id = id;
        }
        public Mark(int id, decimal value, decimal weight) : this(value, weight)
        {
            Id = id;
        }
        public Mark(decimal value, decimal weight) : this(value, weight, string.Empty) { }
        public Mark ShallowCopy()
        {
            return (Mark)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Value: {Value} Weight: {Weight} Description: \"{Description}\"";
        }

    }
}
