using API.Data;
using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class SchoolsRepository : ISchoolsRepository
{
    private readonly IriumContext _context;

    public SchoolsRepository(IriumContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<IReadOnlyList<School>> GetAllSchoolsAsync()
    {
        return await _context.Schools.ToListAsync();
    }

    public async Task<School?> GetSchoolByIdAsync(int id)
    {
        return await _context.Schools.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CreateNewSchool(School newSchool)
    {
        await _context.Schools.AddAsync(newSchool);
        await _context.SaveChangesAsync();
         
    }
}