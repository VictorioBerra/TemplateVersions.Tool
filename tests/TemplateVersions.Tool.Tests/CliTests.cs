using Xunit;
using FluentAssertions;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace TemplateVersions.Tool.Tests
{
    public class CliTests : IDisposable
    {
        private readonly StringWriter sw;
        private readonly TestConsole testConsole;

        public CliTests()
        {
            sw = new StringWriter();
            testConsole = new TestConsole(sw);
        }

        [Fact]
        public void CLI_Should_List_Installed_SDK_Versions_In_Template_Directory()
        {
            // Arrange
            var cli = new Program(testConsole);

            // Act
            cli.InvokeMain(new[] { "--list" });

            // Assert
            // We assume they have an SDK installed
            sw.ToString().Should().Contain("v");

        }

        [Fact]
        public void CLI_Should_List_Installed_Template_Versions_For_Latest_SDK()
        {
            // Arrange
            var cli = new Program(testConsole);

            // Act
            cli.InvokeMain(new string[] {});

            // Assert
            // We assume theres at least one...
            sw.ToString().Should().Contain("nupkg");

        }

        [Fact]
        public void CLI_Should_List_Installed_Template_Versions_For_Specific_SDK()
        {
            // Arrange
            var cli = new Program(testConsole);
            cli.InvokeMain(new string[] { "--list" });
            var latestSDK = sw.ToString().Split(new[] { '\r', '\n' }).First();

            // Act
            cli.InvokeMain(new string[] { "--sdkversion", latestSDK });

            // Assert
            // We assume theres at least one...
            sw.ToString().Should().Contain("nupkg");

        }

        public void Dispose()
        {
            sw.Dispose();
        }
    }
}
