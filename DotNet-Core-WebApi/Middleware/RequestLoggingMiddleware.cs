using DotNet_Core_WebApi.IServices;
using System.Text;

namespace DotNet_Core_WebApi.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILoggerService logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //อ่านข้อมูลจาก Httpcontext และ บันทึก Log
        var req = context.Request;
        var baseUrl = $"{req.Path}";
        var bodyStr = "";
        _logger.LogDebug($"Handling request: {context.Request.Method} {context.Request.Path}");


        if(context.Request.Body is not null && req.Method == "POST" && baseUrl.IndexOf("testnlog") > -1)
        {
            context.Request.EnableBuffering();
            using StreamReader reader = new StreamReader(req.Body, Encoding.UTF8,true,1024,true);
            bodyStr = await reader.ReadToEndAsync();
            if(bodyStr is not null)
            {
                _logger.LogDebug(bodyStr);
            }
            req.Body.Position = 0;
        }
        await _next(context);          
    }    
}
