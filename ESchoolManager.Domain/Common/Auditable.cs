using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ESchoolManager.Domain.Common
{
    public abstract class AuditableModel
    {
        [IgnoreDataMember]
        public int CreatedBy { get; set; }

        [IgnoreDataMember]
        public DateTime CreatedDateTime { get; set; }

        [IgnoreDataMember]
        public int? EditedBy { get; set; }

        [IgnoreDataMember]
        public DateTime? EditedDateTime { get; set; }
    }
}
