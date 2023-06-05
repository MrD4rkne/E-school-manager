using FluentAssertions;
using ESchoolManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESchoolManager.Tests
{
    public class StudentVMTest
    {

        [Fact]
        public void StudentVMEquality()
        {
            // Arrange
            List<StudentVM> students = new List<StudentVM>();

            students.Add(new StudentVM("NAME", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });

            students.Add(new StudentVM("NAME", "", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });

            students.Add(new StudentVM("NAME", "MIDDLE", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });

            students.Add(new StudentVM("NAME", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.1,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });

            students.Add(new StudentVM("NAME", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.1,4))
                }
            });
            students.Add(new StudentVM("NAME", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });

            students.Add(new StudentVM("NAME2", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });
            students.Add(new StudentVM("NAME", "SURNAME2")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });
            students.Add(new StudentVM("NAME", "SURNAME")
            {
                Averages = new List<Tuple<string, decimal>>()
                {
                    new Tuple<string, decimal>("Biology",(decimal)Math.Round(10000/180.0,4)),
                    new Tuple<string, decimal>("Math",(decimal)Math.Round(5000/70.0,4))
                }
            });

            // Action

            bool differentNames = students[0].Equals(students[6]);
            bool differentLastnames = students[0].Equals(students[7]);
            bool nullEmptyMiddleNames = students[0].Equals(students[1]);
            bool differentMiddleNames = students[0].Equals(students[2]);
            bool differentSubjectAverage = students[0].Equals(students[3]);
            bool differentSubjectsCount = students[3].Equals(students[5]);
            bool theSameEverything = students[0].Equals(students[8]);

            // Assert
            differentNames.Should().BeFalse("First names are different");
            differentLastnames.Should().BeFalse("Last names are different");
            nullEmptyMiddleNames.Should().BeTrue("Middle names are null or empty (so equal), rest the same");
            differentMiddleNames.Should().BeFalse("Middle names are different");
            differentSubjectAverage.Should().BeFalse("Biology has different average");
            differentSubjectsCount.Should().BeFalse("Averages count is different");
            theSameEverything.Should().BeTrue("All is the same");
        }
    }
}
