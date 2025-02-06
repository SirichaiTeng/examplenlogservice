using nlogconsoleapp.IServices;

namespace nlogconsoleapp.Services;

public class Worker : IWorker
{
    private readonly ILoggerService _loggerService;
    public Worker(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }
    public Task WorkerRunner()
    {

        Console.WriteLine("Hello, World.");
        _loggerService.LogInfo($"Proocess runnings {DateTime.Now}");
        return Task.CompletedTask;
    }
}
