using DotNet_Core_WebApi.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Core_WebApi.Controllers;

[Route("testnlog/v1")]
[ApiController]
public class TestNLogController : ControllerBase
{
    private readonly ILoggerService _logger;
    public TestNLogController(ILoggerService logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessTest(string name)
    {
        _logger.LogInfo($"parameter { name }");
        return Ok(new { name });
    }

}
