using NLog;
using NLog.Config;
using NLog.Targets;
using nlogconsoleapp.Services;

namespace nlogconsoleapp.Tests.Services;

public class LoggerServiceTests
{

    private readonly LoggerService _loggerService;
    private readonly MemoryTarget _memoryTarget;


    public LoggerServiceTests()
    {
        var config = new LoggingConfiguration();
        _memoryTarget = new MemoryTarget { Layout = "${message}" };
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, _memoryTarget);
        LogManager.Configuration = config;
        _loggerService = new LoggerService();
    }

    [Fact]
    public void LogDebug_ShouldLogMessage()
    {
        // Arrange
        var message = "debug message";

        // Act
        _loggerService.LogDebug(message);

        // Assert
        Assert.Contains(message,_memoryTarget.Logs);
    }    
    
    [Fact]
    public void LogError_ShouldLogMessage()
    {
        // Arrange
        var message = "error message";

        // Act
        _loggerService.LogDebug(message);

        // Assert
        Assert.Contains(message,_memoryTarget.Logs);
    }    
    
    [Fact]
    public void LogInfo_ShouldLogMessage()
    {
        // Arrange
        var message = "Info message";

        // Act
        _loggerService.LogDebug(message);

        // Assert
        Assert.Contains(message,_memoryTarget.Logs);
    }    
    
    [Fact]
    public void LogWarn_ShouldLogMessage()
    {
        // Arrange
        var message = "warn message";

        // Act
        _loggerService.LogDebug(message);

        // Assert
        Assert.Contains(message,_memoryTarget.Logs);
    }
}
