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
    [HttpGet]
    public async Task<IActionResult> getAllSchools()
    {
        var schools = await _service.GetAllSchools();

        return Ok(schools);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getSchoolById(int id)
    {
        var school = await _service.GetSchoolById(id);
        if (school != null)
        {
            return Ok(school);
        }

        return NotFound();
    }

    [HttpGet("{id}/packages")]
    public async Task<IActionResult> GetPackagesOfSchool(int id)
    {
        var school = await _service.GetSchoolById(id);
        if (school != null)
        {
            return NotFound();
        }
        var packages =  await _service.GetPackagesOfSchool(id);
        return Ok(packages);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddSchool([FromBody] SchoolDto schoolDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
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

    [HttpPost("{schoolId}/packages/{packageId}")]
    public async Task<IActionResult> AddPackageToSchool([FromBody] int schoolId, int packageId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var school = await _service.GetSchoolById(schoolId);
        if (school == null)
        {
            return StatusCode(404, $"School {schoolId} not found.");
        }
        await _service.AddPackageToSchool(schoolId, packageId);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSchool(int schoolId)
    {
        try
        {
            await _service.DeleteSchool(schoolId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSchool(int id, SchoolDto updatedSchool)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _service.UpdateSchoolAsync(id, updatedSchool);
            return NoContent();
        }
        
        catch (NotFoundException)
        {
            return NotFound();
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}