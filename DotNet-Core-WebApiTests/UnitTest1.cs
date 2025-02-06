using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core_WebApiTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Application_Should_Start_In_Test_Mode()
        {
            // Arrange
            var args = new[] { "test" };

            // Act
            var app = Program.CreateApp(args);

            // Assert
            Assert.NotNull(app); 
        }
    }
}