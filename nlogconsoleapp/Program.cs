using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using nlogconsoleapp.IServices;
using nlogconsoleapp.Services;

namespace nlogconsoleapp;
public static class Program
{
    public static async Task Main(string[] args)
    {
        var isTestMode = args.Length > 0 && args[0] == "test"; 
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false,reloadOnChange:true)
            .Build();

        var services = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .AddScoped<ILoggerService,LoggerService>()
            .AddScoped<IWorker,Worker>();

        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        var serviceProvider = services.BuildServiceProvider();
        var runing = serviceProvider.GetService<IWorker>();
        if(!isTestMode)
        {
            await runing.WorkerRunner();

        }
        else
        {
            Environment.ExitCode = 0;
        }

    }
}
