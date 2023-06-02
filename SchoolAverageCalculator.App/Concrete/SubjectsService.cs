using SchoolAverageCalculator.App.Common;
using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Concrete
{
    public class SubjectsService : BaseService<Subject>
    {
        public Subject[] GetSubjectsForTeacher(int id)
        {
            return Items.Where(x=>x.TeacherId== id).ToArray();
        }

    }
}
