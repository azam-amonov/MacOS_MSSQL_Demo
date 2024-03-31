using Microsoft.AspNetCore.Mvc;

namespace Demo_MSSQL_MacOS.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult Home()
    {
        return Ok("Hello, Mario Princess in another castle!");
    }
}