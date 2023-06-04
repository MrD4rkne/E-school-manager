using SchoolAverageCalculator.App.Common;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Concrete
{
    /// <summary>
    /// Main service merging all data-services
    /// </summary>
    public class DataService
    {
        public MarksService MarksService { get; private set; }
        public SubjectsService SubjectsService { get; private set; }
        public TeachersService TeachersService { get; private set;}
        public StudentsService StudentsService { get; private set; }

        public DataService(MarksService marksService, SubjectsService subjectsService, TeachersService teachersService, StudentsService studentsService)
        {
            MarksService = marksService;
            SubjectsService = subjectsService;
            TeachersService = teachersService;
            StudentsService = studentsService;
        }

        public DataService() : this(new MarksService(), new SubjectsService(), new TeachersService(), new StudentsService())
        {

        }

        /// <summary>
        /// Get view model for student (basic data + marks).
        /// </summary>
        /// <param name="id">Student's id</param>
        /// <returns>View model</returns>
        public StudentVM? GetStudentVM(int id)
        {
            var student = StudentsService.GetItemById(id);
            if (student == null)
                return null;

            StudentVM studentVM = new(student.FirstName, student.MiddleName, student.LastName);

            foreach(var subject in SubjectsService.Items)
            {
                studentVM.Averages.Add(new Tuple<string, decimal>(subject.Name, Math.Round(MarksService.GetAverage(MarksService.GetStudentMarks(student.Id, subject.Id)),4)));
            }

            return studentVM;
        }
        /// <summary>
        /// Get view model for subject (basic info + student with marks).
        /// </summary>
        /// <param name="id">Subject's id</param>
        /// <returns></returns>
        public SubjectVM? GetSubjectVM(int id)
        {
            Subject? obj = SubjectsService.GetItemById(id);

            if (obj == null)
                return null;
            SubjectVM vm = new(obj.Name, GetStudentsAverages(obj.Id));
            if (obj.TeacherId.HasValue)
            {
                vm.Teacher = TeachersService.GetItemById(obj.TeacherId.Value);
            }
            return vm;
        }

        /// <summary>
        /// Get existing student's averages, who has at least one mark from subject.
        /// </summary>
        /// <param name="subjectId">Subject's id</param>
        /// <returns>Tally of students and their averages from subject</returns>
        public Tuple<Student, decimal>[] GetStudentsAverages(int subjectId)
        {
            var groups = MarksService.GetSubjectMarks(subjectId).GroupBy(x => x.StudentId);
            List<Tuple<Student, decimal>> ret = new List<Tuple<Student, decimal>>();

            foreach (var group in groups)
            {
                var studentId = group.Key;
                if(StudentsService.GetItemById(studentId) is Student student && student!=null)
                {
                    ret.Add(new(student, MarksService.GetStudentAverage(studentId, subjectId)));
                }
            }
            return ret.ToArray();
        }

        public TeacherVM? GetTeacherVM(int id)
        {
            Teacher? obj = TeachersService.GetItemById(id);

            if (obj == null)
                return null;
            TeacherVM vm = new(obj.FirstName, obj.MiddleName, obj.LastName, SubjectsService.GetSubjectsForTeacher(id).ToList());
            return vm;
        }

        #region SavingData

        /// <summary>
        /// Save data from each services to files.
        /// </summary>
        /// <param name="directory">Directory where files shoul dbe created</param>
        /// <param name="type">Type of serializator</param>
        public void SaveData(string directory, SerializerType type)
        {
            string studentsFile = Path.Combine(directory, "students" + FileManager.GetProperExtension(type));
            FileManager.SaveToFile(StudentsService.Items, studentsFile, type);

            string teachersFile = Path.Combine(directory, "teachers" + FileManager.GetProperExtension(type));
            FileManager.SaveToFile(TeachersService.Items, teachersFile, type);

            string subjectsFile = Path.Combine(directory, "subjects" + FileManager.GetProperExtension(type));
            FileManager.SaveToFile(SubjectsService.Items, subjectsFile, type);

            string marksFile = Path.Combine(directory, "marks" + FileManager.GetProperExtension(type));
            FileManager.SaveToFile(MarksService.Items, marksFile, type);
        }
        /// <summary>
        /// Load data from files.
        /// </summary>
        /// <param name="directory">Directory with saved files</param>
        /// <param name="type">Type of serializator</param>
        public void LoadData(string directory, SerializerType type)
        {
            string studentsFile = Path.Combine(directory, "students" + FileManager.GetProperExtension(type));
            var students = FileManager.LoadFromFile<List<Student>>(studentsFile, type);
            if (students != null)
                StudentsService.Items = students;

            string teachersFile = Path.Combine(directory, "teachers" + FileManager.GetProperExtension(type));
            var teachers = FileManager.LoadFromFile<List<Teacher>>(teachersFile, type);
            if (teachers != null)
                TeachersService.Items = teachers;

            string subjectsFile = Path.Combine(directory, "subjects" + FileManager.GetProperExtension(type));
            var subjects = FileManager.LoadFromFile<List<Subject>>(subjectsFile, type);
            if (subjects != null)
                SubjectsService.Items = subjects;

            string marksFile = Path.Combine(directory, "marks" + FileManager.GetProperExtension(type));
            var marks = FileManager.LoadFromFile<List<Mark>>(marksFile, type);
            if (marks != null)
                MarksService.Items = marks;
        }
        #endregion
        /// <summary>
        /// Clear data from each of services.
        /// </summary>
        public void ClearData()
        {
            MarksService.Items.Clear();
            TeachersService.Items.Clear();
            SubjectsService.Items.Clear();
            StudentsService.Items.Clear();
        }

    }
}
