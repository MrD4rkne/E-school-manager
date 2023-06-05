using FluentAssertions;
using ESchoolManager.App.Common;
using ESchoolManager.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESchoolManager.Tests
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
