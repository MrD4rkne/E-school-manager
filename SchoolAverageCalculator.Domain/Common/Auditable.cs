using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.Domain.Common
{
    public abstract class AuditableModel
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? EditedBy { get; set; }
        public DateTime? EditedDateTime { get; set; }
    }
}
