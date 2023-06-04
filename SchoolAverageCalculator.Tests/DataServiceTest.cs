using FluentAssertions;
using Moq;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Domain.ViewModel;
using Xunit;

namespace SchoolAverageCalculator.Tests
{
    public class DataServiceTest
    {
        [Fact]
        public void GetStudentVM()
        {
            // Arrange
            // Arrange student
            DataService dataService = new DataService();
            int studentId = dataService.StudentsService.AddItem(new Student("First", "Middle", "Last"));
            // Arrange subjects
            int[] subjects = { dataService.SubjectsService.AddItem(new Subject("Biology")), dataService.SubjectsService.AddItem(new Subject("Math")) };
            // Arange marks
            dataService.MarksService.AddItem(new(studentId, subjects[0], 100, 40));
            dataService.MarksService.AddItem(new(studentId, subjects[0], 20, 60));
            dataService.MarksService.AddItem(new(studentId, subjects[0], 60, 80));

            dataService.MarksService.AddItem(new(studentId, subjects[1], 100, 40));
            dataService.MarksService.AddItem(new(studentId, subjects[1], 20, 20));
            dataService.MarksService.AddItem(new(studentId, subjects[1], 60, 10));

            // Action
            var studentVM = dataService.GetStudentVM(studentId);

            // Asert
            studentVM.Should().BeOfType<StudentVM>();
            studentVM.Should().NotBeNull();
            studentVM.Averages.Count.Should().Be(subjects.Length);

            studentVM.Should().Be(new StudentVM("First", "Middle", "Last")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            }
            );

        }
        [Fact]
        public void GetSubjectVM()
        {
            // Arrange

            DataService dataService = new DataService();

            // create teacher
            Teacher t1 = new("NAME", "SURNAME");
            dataService.TeachersService.AddItem(t1);

            // create subjects
            Subject sb1 = new Subject("Math", t1.Id);
            Subject sb2 = new Subject("Biology");
            dataService.SubjectsService.AddItem(sb1);
            dataService.SubjectsService.AddItem(sb2);

            // create students
            Student st1 = new("NAME1", "SURNAME1");
            Student st2 = new("NAME2", "SURNAME2");
            Student st3 = new("NAME3", "SURNAME3");
            dataService.StudentsService.AddItem(st1);
            dataService.StudentsService.AddItem(st2);
            dataService.StudentsService.AddItem(st3);

            // add marks for sb1
            // average 50
            dataService.MarksService.AddItem(new(st1.Id, sb1.Id, 100, 20));
            dataService.MarksService.AddItem(new(st1.Id, sb1.Id, 0, 20));
            // average 20
            dataService.MarksService.AddItem(new(st2.Id, sb1.Id, 60, 20));
            dataService.MarksService.AddItem(new(st2.Id, sb1.Id, 0, 40));


            // Action
            var vm1 = dataService.GetSubjectVM(st1.Id);
            var vm2 = dataService.GetSubjectVM(st2.Id);
            var vm3 = dataService.GetSubjectVM(100);


            // Assert
            vm1.Should().NotBeNull();
            vm1.Name.Should().Be(sb1.Name);
            vm1.Teacher.Should().NotBeNull();
            vm1.Teacher.Should().Be(t1);
            vm1.Averages.Count().Should().Be(2);
            vm1.Averages.Should().Contain(new Tuple<Student,decimal>(st1, 50));
            vm1.Averages.Should().Contain(new Tuple<Student, decimal>(st2, 20));

            vm2.Should().NotBeNull();
            vm2.Name.Should().Be(sb2.Name);
            vm2.Teacher.Should().BeNull();
            vm2.Averages.Should().NotBeNull();
            vm2.Averages.Should().BeEmpty();

            vm3.Should().BeNull();

        }
        [Fact]
        public void GetStudentsAverages()
        {
            // Arrange

            DataService dataService = new DataService();

            // create subjects
            Subject sb1 = new Subject("Math");
            Subject sb2 = new Subject("Biology");
            dataService.SubjectsService.AddItem(sb1);
            dataService.SubjectsService.AddItem(sb2);

            // create students
            Student st1 = new("NAME1", "SURNAME1");
            Student st2 = new("NAME2", "SURNAME2");
            Student st3 = new("NAME3", "SURNAME3");
            dataService.StudentsService.AddItem(st1);
            dataService.StudentsService.AddItem(st2);
            dataService.StudentsService.AddItem(st3);

            // add marks for sb1
            // average 50
            dataService.MarksService.AddItem(new(st1.Id, sb1.Id, 100, 20));
            dataService.MarksService.AddItem(new(st1.Id, sb1.Id, 0, 20));
            // average 20
            dataService.MarksService.AddItem(new(st2.Id, sb1.Id, 60, 20));
            dataService.MarksService.AddItem(new(st2.Id, sb1.Id, 0, 40));


            // Action
            var averages1 = dataService.GetStudentsAverages(sb1.Id);
            var averages2 = dataService.GetStudentsAverages(sb2.Id);
            var averages3 = dataService.GetStudentsAverages(100);


            // Assert
            averages1.Should().NotBeNull();
            averages1.Count().Should().Be(2);
            averages1.Should().Contain(new Tuple<Student, decimal>(st1, 50));
            averages1.Should().Contain(new Tuple<Student, decimal>(st2, 20));

            averages2.Should().NotBeNull();
            averages2.Should().BeEmpty();

            averages3.Should().NotBeNull();
            averages3.Should().BeEmpty();
        }

        [Fact]
        public void GetTeacherVM()
        {
            // Arrange
            // Arrange teacher
            DataService dataService = new DataService();
            int teacherId = dataService.TeachersService.AddItem(new Teacher("First", "Middle", "Last"));
            // Arrange subjects
            Subject[] subjects = new Subject[] { new Subject("Biology", teacherId), new Subject("Math", teacherId), new Subject("PE") };
            dataService.SubjectsService.AddItem(subjects[0]);
            dataService.SubjectsService.AddItem(subjects[1]);
            dataService.SubjectsService.AddItem(subjects[2]);

            // Action
            var teacherVM = dataService.GetTeacherVM(teacherId);

            // Asert
            teacherVM.Should().BeOfType<TeacherVM>();
            teacherVM.Should().NotBeNull();
            teacherVM.Subjects.Should().NotBeNull();
            teacherVM.Subjects.Count.Should().Be(2);

            teacherVM.FirstName.Should().Be("First");
            teacherVM.MiddleName.Should().Be("Middle");
            teacherVM.LastName.Should().Be("Last");

            teacherVM.Subjects.Should().Contain(subjects[0]);
            teacherVM.Subjects.Should().Contain(subjects[1]);
            teacherVM.Subjects.Should().NotContain(subjects[2]);
        }

        [Fact]
        public void CSVSaveLoad()
        {
            SaveLoadData(SerializerType.CSV);
        }
        [Fact]
        public void JSONSaveLoad()
        {
            SaveLoadData(SerializerType.JSON);
        }
        [Fact]
        public void XMLSaveLoad()
        {
            SaveLoadData(SerializerType.XML);
        }
        public void SaveLoadData(SerializerType type)
        {
            // Arrange
            DataService dataService = new DataService();

            Student student = new Student("NAME", "SURNAME");
            Teacher teacher = new("BIOLOGY", "ONE", "TEACHER");
            int studentId = dataService.StudentsService.AddItem(student);
            int teacherId = dataService.TeachersService.AddItem(teacher);
            Subject subject = new Subject("Biology", teacherId);
            int subjectId = dataService.SubjectsService.AddItem(subject);
            Mark mark1 = new(studentId, subjectId, 100, 20);
            Mark mark2 = new(studentId, subjectId, 50, 60);
            dataService.MarksService.AddItem(mark1);
            dataService.MarksService.AddItem(mark2);

            // Action

            dataService.SaveData(FileManager.GetFolder(), type);
            dataService.ClearData();
            dataService.LoadData(FileManager.GetFolder(), type);

            // Assert

            dataService.MarksService.Items.Should().Contain(mark1);
            dataService.MarksService.Items.Should().Contain(mark2);
            dataService.StudentsService.Items.Should().Contain(student);
            dataService.SubjectsService.Items.Should().Contain(subject);
            dataService.TeachersService.Items.Should().Contain(teacher);

        }

        [Fact]
        public void ClearData()
        {
            // Arrange
            DataService dataService = new DataService();

            Student student = new Student("NAME", "SURNAME");
            Teacher teacher = new("BIOLOGY", "ONE", "TEACHER");
            int studentId = dataService.StudentsService.AddItem(student);
            int teacherId = dataService.TeachersService.AddItem(teacher);
            Subject subject = new Subject("Biology", teacherId);
            int subjectId = dataService.SubjectsService.AddItem(subject);
            Mark mark1 = new(studentId, subjectId, 100, 20);
            Mark mark2 = new(studentId, subjectId, 50, 60);
            dataService.MarksService.AddItem(mark1);
            dataService.MarksService.AddItem(mark2);

            // Action
            dataService.ClearData();

            // Assert

            dataService.MarksService.Items.Should().BeEmpty();
            dataService.StudentsService.Items.Should().BeEmpty();
            dataService.TeachersService.Items.Should().BeEmpty();
            dataService.SubjectsService.Items.Should().BeEmpty();
        }
    }
}