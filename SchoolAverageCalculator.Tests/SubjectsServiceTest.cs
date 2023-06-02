using FluentAssertions;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolAverageCalculator.Tests
{
    public class SubjectsServiceTest
    {
        [Fact]
        public void GetSubjectsForTeacher()
        {
            // Arrange
            SubjectsService subjectsService = new SubjectsService();

            Subject[] subjects = new Subject[] { new("Biology", 1), new("Maths", 2), new("English", 2) };

            int firstSubject = subjectsService.AddItem(subjects[0]);
            int secondSubject = subjectsService.AddItem(subjects[1]);
            int thirdSubject = subjectsService.AddItem(subjects[2]);

            // Action
            var firstSubjects = subjectsService.GetSubjectsForTeacher(1);
            var secondSubjects = subjectsService.GetSubjectsForTeacher(2);
            var thirdSubjects = subjectsService.GetSubjectsForTeacher(3);

            // Assert

            firstSubjects.Should().AllBeOfType(typeof(Subject));
            firstSubjects.Count().Should().Be(1);
            firstSubjects.Should().Contain(subjects[0]);

            secondSubjects.Should().AllBeOfType(typeof(Subject));
            secondSubjects.Count().Should().Be(2);
            secondSubjects.Should().Contain(subjects[1]);
            secondSubjects.Should().Contain(subjects[2]);

            thirdSubjects.Should().BeEmpty();


        }
    }
}
