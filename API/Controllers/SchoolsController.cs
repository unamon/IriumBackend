using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly IriumContext _dbContext;
    
    public SchoolsController(IriumContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetSchools()
    {
        var schools = await _dbContext.Schools.ToListAsync();
        return Ok(schools);
    }

}