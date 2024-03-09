using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SchoolsController : ControllerBase
{
    [HttpGet]
    public String GetSchools()
    {
        return "A list of schools";
    }

    [HttpPost]
    public String PostSchool()
    {
        return "posted! pog!";
    }
}