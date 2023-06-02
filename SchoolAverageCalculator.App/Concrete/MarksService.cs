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
        /// <summary>
        /// Count average for all Marks
        /// </summary>
        /// <returns>Average of all Items</returns>
        public decimal GetAverage()
        {
            return GetAverage(Items);
        }
        /// <summary>
        /// Count average for list of Marks
        /// </summary>
        /// <param name="marks">List of Marks</param>
        /// <returns>Average of marks</returns>
        public decimal GetAverage(List<Mark> marks)
        {
            if (marks == null || marks.Count == 0)
                return 0;
            decimal numerator = 0, denominator = 0;
            foreach (Mark mark in marks)
            {
                numerator += mark.Value * mark.Weight;
                denominator += mark.Weight;
            }
            if (denominator == 0)
                return 0;
            return numerator / denominator;
        }

        /// <summary>
        /// Count student's average for specific subject
        /// </summary>
        /// <param name="studentId">Student's id</param>
        /// <param name="subjectId">Subject's id</param>
        /// <returns></returns>
        public decimal GetStudentAverage(int studentId, int subjectId)
        {
            return GetAverage(GetStudentMarks(studentId, subjectId));
        }

        /// <summary>
        /// Count student's average from all Marks
        /// </summary>
        /// <param name="studentId">Student's id</param>
        /// <returns></returns>
        public decimal GetStudentAverage(int studentId)
        {
            return GetAverage(GetStudentMarks(studentId));
        }

        /// <summary>
        /// Get student's marks (doesn't check student's existence)
        /// </summary>
        /// <param name="studentId">Mark's owner id</param>
        /// <returns>List of student's marks or empty</returns>
        public List<Mark> GetStudentMarks(int studentId)
        {
            return Items.Where(x=>x.StudentId== studentId).ToList();
        }

        /// <summary>
        /// Get student's marks from subject (doesn't check student's or subject's existence)
        /// </summary>
        /// <param name="studentId">Mark's owner id</param>
        /// <param name="subjectId">Mark's subject id</param>
        /// <returns>List of student's marks or empty</returns>
        public List<Mark> GetStudentMarks(int studentId, int subjectId)
        {
            return GetStudentMarks(studentId).Where(x=>x.SubjectId==subjectId).ToList();
        }
        public List<Mark> GetSubjectMarks(int subjectId)
        {
            return Items.Where(x=>x.SubjectId==subjectId).ToList();
        }
        //public Mark? WithId(int id)
        //{
        //    return Items.FirstOrDefault(x => x.Id == id);
        //}
    }
}
