using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly ISchoolService _service;
    
    public SchoolsController(ISchoolService service)
    {
        _service = service;
    }
    public async Task<IActionResult> getAllSchools()
    {
        var schools = await _service.GetAllSchools();

        return Ok(schools);
    }

    public async Task<object> getSchoolById(int i)
    {
        throw new NotImplementedException();
    }
}