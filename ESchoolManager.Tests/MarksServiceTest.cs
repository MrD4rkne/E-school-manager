using FluentAssertions;
using ESchoolManager.App.Concrete;
using ESchoolManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESchoolManager.Tests
{
    public class MarksServiceTest
    {
        [Fact]
        // Matter of fact, it checks both implementations
        public void GetAverage()
        {
            // Arrange
            MarksService service = new MarksService();
            service.AddItem(new(0, 0, 100, 20));
            service.AddItem(new(0, 0, 100, 40));
            service.AddItem(new(0, 0, 000, 60));

            // Action
            decimal average = service.GetAverage();
            decimal emptyAverage = service.GetAverage(null);

            // Assert
            average.Should().Be(50);
            emptyAverage.Should().Be(0);
        }

        [Fact]
        public void GetStudentAverageForSubject()
        {
            // Arrange
            MarksService service = new MarksService();
            service.AddItem(new(0, 1, 100, 20));
            service.AddItem(new(0, 2, 100, 40));
            service.AddItem(new(0, 2, 000, 60));

            // Action
            decimal average1 = service.GetStudentAverage(0, 1);
            decimal average2 = service.GetStudentAverage(0,2);

            // Assert
            
            average1.Should().Be(100);
            average2.Should().Be(40);
        }

        [Fact]
        public void GetStudentAverage()
        {
            // Arrange
            MarksService service = new MarksService();
            service.AddItem(new(0, 1, 100, 20));
            service.AddItem(new(0, 2, 100, 40));
            service.AddItem(new(0, 2, 000, 60));

            // Action
            decimal average1 = service.GetStudentAverage(0);
            decimal average2 = service.GetStudentAverage(1);


            // Assert

            average1.Should().Be(50);
            average2.Should().Be(0);
        }

        [Fact]
        public void GetStudentMarks()
        {
            // Arrange
            MarksService service = new MarksService();

            Mark[] marks = new Mark[] { new(1, 1, 100, 20), new(1, 2, 100, 40), new(1, 2, 000, 60), new(2, 2, 000, 60) };

            service.AddItem(marks[0]);
            service.AddItem(marks[1]);
            service.AddItem(marks[2]);
            service.AddItem(marks[3]);

            // Action

            var list1 = service.GetStudentMarks(1);
            var list2 = service.GetStudentMarks(2);
            var list3 = service.GetStudentMarks(3);
            
            // Assert

            list1.Should().BeOfType(typeof(List<Mark>));
            list1.Count().Should().Be(3);
            list1.Should().Contain(marks[0]);
            list1.Should().Contain(marks[1]);
            list1.Should().Contain(marks[2]);

            list2.Should().BeOfType(typeof(List<Mark>));
            list2.Count().Should().Be(1);
            list2.Should().Contain(marks[3]);

            list3.Should().BeOfType(typeof(List<Mark>));
            list3.Should().BeEmpty();
        }

        [Fact]
        public void GetStudentMarksWithSubject()
        {
            // Arrange
            MarksService service = new MarksService();

            Mark[] marks = new Mark[] { new(1, 1, 100, 20), new(1, 2, 100, 40), new(1, 2, 000, 60), new(2, 2, 000, 60) };

            service.AddItem(marks[0]);
            service.AddItem(marks[1]);
            service.AddItem(marks[2]);
            service.AddItem(marks[3]);

            // Action

            var list1_1 = service.GetStudentMarks(1,1);
            var list1_2 = service.GetStudentMarks(1, 2);
            var list2 = service.GetStudentMarks(2,2);
            var list3 = service.GetStudentMarks(3);

            // Assert

            list1_1.Should().BeOfType(typeof(List<Mark>));
            list1_1.Count().Should().Be(1);
            list1_1.Should().Contain(marks[0]);

            list1_2.Should().BeOfType(typeof(List<Mark>));
            list1_2.Count().Should().Be(2);
            list1_2.Should().Contain(marks[1]);
            list1_2.Should().Contain(marks[2]);

            list2.Should().BeOfType(typeof(List<Mark>));
            list2.Count().Should().Be(1);
            list2.Should().Contain(marks[3]);

            list3.Should().BeOfType(typeof(List<Mark>));
            list3.Should().BeEmpty();
        }

        [Fact]
        public void GetSubjectMarks()
        {
            // Arrange
            MarksService service = new MarksService();

            Mark[] marks = new Mark[] { new(1, 1, 100, 20), new(1, 2, 100, 40), new(1, 2, 000, 60), new(2, 2, 000, 60) };

            service.AddItem(marks[0]);
            service.AddItem(marks[1]);
            service.AddItem(marks[2]);
            service.AddItem(marks[3]);

            // Action
            var marks1 = service.GetSubjectMarks(1);
            var marks2 = service.GetSubjectMarks(2);
            var marks3 = service.GetSubjectMarks(3);

            // Assert

            marks1.Should().BeOfType(typeof(List<Mark>));
            marks1.Count().Should().Be(1);
            marks1.Should().Contain(marks[0]);

            marks2.Should().BeOfType(typeof(List<Mark>));
            marks2.Count().Should().Be(3);
            marks2.Should().Contain(marks[1]);
            marks2.Should().Contain(marks[2]);
            marks2.Should().Contain(marks[3]);

            marks3.Should().BeOfType(typeof(List<Mark>));
            marks3.Should().BeEmpty();
        }
    }
}
