using Microsoft.AspNetCore.Mvc;

namespace MyOrca.Controllers;
[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok();
    }
}