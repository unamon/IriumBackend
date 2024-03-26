using API.Data;
using API.Exceptions;
using API.Models;
using API.Models.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<List<Package>> GetAllPackagesAssociatedToSchool(int schoolId)
    {
        return await _context.Schools
            .Where(s => s.Id == schoolId)
            .SelectMany(s => s.SchoolsPackages)
            .Select(sp => sp.Package)
            .ToListAsync();
    }

    public async Task AddPackageToSchool(int schoolId, int packageId)
    {
        var schoolPackage = new SchoolsPackage()
        {
            SchoolId = schoolId,
            PackageId = packageId
        };
        
        await _context.SchoolsPackages.AddAsync(schoolPackage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSchool(int schoolId)
    {
        var school = await _context.Schools
            .FirstOrDefaultAsync(s => s.Id == schoolId);
        if (school != null)
        {
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateSchoolAsync(int id, SchoolDto schoolDto)
    {
        var school = await _context.Schools.FirstOrDefaultAsync(s => s.Id == id);
        if (school != null)
        {
            var updatedSchool = new School()
            {
                Id = id,
                Name = schoolDto.Name,
                Inep = schoolDto.Inep
            };
            _context.Schools.Update(updatedSchool);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException($"School with ID {id} not found.");
        }
    }


}