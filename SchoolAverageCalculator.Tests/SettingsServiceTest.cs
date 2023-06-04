using FluentAssertions;
using SchoolAverageCalculator.App.Common;
using SchoolAverageCalculator.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolAverageCalculator.Tests
{
    public class SettingsServiceTest
    {
        [Fact]
        public void SaveLoad()
        {
            // Arrange
            SettingsService settings = new SettingsService();

            // Action
            settings.SetSerializerType(App.Helpers.SerializerType.JSON);
            settings = new SettingsService();

            // Assert

            settings.GetSerializerType().Should().Be(App.Helpers.SerializerType.JSON);
        }
    }
}
