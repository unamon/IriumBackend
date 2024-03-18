using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class SchoolService
{
    private readonly IriumContext _ctx;

    public SchoolService(IriumContext dbContext)
    {
        _ctx = dbContext;
    }

    public async Task<List<School>> GetAllSchools()
    {
        return await _ctx.Schools.ToListAsync();
    }

    public async Task<School> GetSchoolById(int id)
    {
        return await _ctx.Schools.FindAsync(id);
    }

    public async Task AddSchoolAsync(School school)
    {
        _ctx.Schools.Add(school);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateSchool(School updatedSchool)
    {
        _ctx.Entry(updatedSchool).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteSchool(int id)
    {
        var school = await _ctx.Schools.FindAsync(id);
        if (school != null)
        {
            _ctx.Schools.Remove(school);
            await _ctx.SaveChangesAsync();
        }
    }
}