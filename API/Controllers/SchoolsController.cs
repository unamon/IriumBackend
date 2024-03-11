using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    [HttpGet]
    public string GetSchools()
    {
        return "Schools";
    }
}