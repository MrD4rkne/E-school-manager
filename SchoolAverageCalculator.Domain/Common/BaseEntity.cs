using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
        public BaseEntity ShallowCopy()
        {
            return (BaseEntity)this.MemberwiseClone();
        }
    }
}
