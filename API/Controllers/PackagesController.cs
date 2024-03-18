using API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PackagesController : ControllerBase
{
    private readonly IriumContext _dbContext;
    
    public PackagesController(IriumContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetPackages()
    {
        var schools = await _dbContext.Packages.ToListAsync();
        return Ok(schools);
    }
    
    
    [HttpGet("/pkgs")]
    public async Task<IActionResult> GetPkgs()
    {
        var schools = await _dbContext.Packages.ToListAsync();
        return Ok(schools);
    }

    [HttpGet("/schpkgs")]
    public async Task<IActionResult> GetScPkgs()
    {
        var schools = await _dbContext.SchoolsPackages.ToListAsync();
        return Ok(schools);
    }
}