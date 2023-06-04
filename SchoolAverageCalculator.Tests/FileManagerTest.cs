using FluentAssertions;
using SchoolAverageCalculator.App.Helpers;
using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolAverageCalculator.Tests
{
    public class FileManagerTest
    {
        [Fact]
        public void CSV()
        {
            FileTest(SerializerType.CSV);
        }

        [Fact]
        public void XML()
        {
            FileTest(SerializerType.XML);
        }

        [Fact]
        public void JSON()
        {
            FileTest(SerializerType.JSON);
        }


        private void FileTest(SerializerType serializerType)
        {
            // Arrange
            List<Subject> subjects= new List<Subject>();
            subjects.Add(new Subject("Biology",1));
            subjects.Add(new Subject("Math", 2));
            subjects.Add(new Subject("PE", 3));

            string path = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());

            // Action

            FileManager.SaveToFile(subjects, path, serializerType);

            var loaded = FileManager.LoadFromFile<List<Subject>>(path, serializerType);

            // Assert

            loaded.Should().NotBeNull();
            loaded.Count.Should().Be(subjects.Count);
            
            foreach(var subject in loaded)
            {
                subjects.Should().Contain(subject);
            }
        }       
    }
}
