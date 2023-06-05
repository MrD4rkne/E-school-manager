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
        /// <summary>
        /// Get all subjects assigned to teacher
        /// </summary>
        /// <param name="id">Teacher's id</param>
        /// <returns>List of assigned subjects or empty if there are none</returns>
        public Subject[] GetSubjectsForTeacher(int id)
        {
            return Items.Where(x=>x.TeacherId== id).ToArray();
        }

    }
}
