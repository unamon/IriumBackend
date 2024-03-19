using API.Data;
using API.Models;
using API.Models.DTOs;
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

    public async Task<IActionResult> getSchoolById(int i)
    {
        var school = await _service.GetSchoolById(i);
        if (school != null)
        {
            return Ok(school);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<object> AddSchool([FromBody] SchoolDto schoolDto)
    {
        var school = new School()
        {
            Name = schoolDto.Name,
            Inep = schoolDto.Inep
        };

        try
        {
            await _service.AddSchoolAsync(school);
            return CreatedAtRoute("GetSchoolById", new { id = school.Id }, school);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}