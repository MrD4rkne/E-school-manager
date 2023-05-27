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

        public Mark(decimal value, decimal weight) : this(value, weight, string.Empty) { }
        public static Mark Duplicate(Mark origin)
        {
            if (origin == null)
                return null;
            Mark ret = new Mark(origin.Value,origin.Weight,origin.Description);
            ret.Id = origin.Id;
            return ret;
        }

        public override string ToString()
        {
            return $"Value: {Value} Weight: {Weight} Description: \"{Description}\"";
        }

    }
}
