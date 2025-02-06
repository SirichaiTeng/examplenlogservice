using DotNet_Core_WebApi.IServices;
using DotNet_Core_WebApi.Middleware;
using DotNet_Core_WebApi.Services;
using NLog;
public static class Program
{

    public static WebApplication CreateApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ตรวจสอบโหมดทดสอบ
        var isTestMode = args.Contains("test");

        builder.Services.AddTransient<ILoggerService, LoggerService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        var app = builder.Build();

        app.UseMiddleware<RequestLoggingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app; 
    }

    public static async Task Main(string[] args)
    {
        var app = CreateApp(args);

        if (!args.Contains("test"))
        {
            await app.RunAsync(); 
        }
    }
}
