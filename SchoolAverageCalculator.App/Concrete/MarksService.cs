using SchoolAverageCalculator.App.Common;
using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Concrete
{
    public class MarksService : BaseService<Mark>
    {
        public decimal CountAverage()
        {
            if (Items == null || Items.Count == 0)
                return 0;
            decimal numerator = 0, denominator = 0;
            foreach (Mark mark in Items)
            {
                numerator += mark.Value * mark.Weight;
                denominator += mark.Weight;
            }
            if (denominator == 0)
                return 0;
            return numerator / denominator;
        }
        public Mark? WithId(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
    }
}
