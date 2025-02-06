using DotNet_Core_WebApi.IServices;
using DotNet_Core_WebApi.Middleware;
using DotNet_Core_WebApi.Services;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//NLog use AddTransient or AddSingleton 
builder.Services.AddTransient<ILoggerService, LoggerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configure NLog
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
