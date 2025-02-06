using System.Diagnostics;

namespace nlogconsoleapp.Tests;

public class ProgramTests
{

    [Fact]
    public async Task MainTest()
    {
        // Arrange
        var args = new[] { "test" };

        // act
        await Program.Main(args);

        // Assert
        Assert.Equal(0, Environment.ExitCode);
    }
}
