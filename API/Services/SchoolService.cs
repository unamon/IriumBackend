using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class SchoolService : ISchoolService
{
    private ISchoolsRepository _schoolsRepository;

    public SchoolService(ISchoolsRepository schoolsRepository)
    {
        _schoolsRepository = schoolsRepository;
    }

    public async Task<IReadOnlyList<School>> GetAllSchools()
    {
        return await _schoolsRepository.GetAllSchoolsAsync();
    }

    public async Task<School?> GetSchoolById(int id)
    {
        return await _schoolsRepository.GetSchoolByIdAsync(id);
        
    }

    public async Task AddSchoolAsync(School school)
    {
        await _schoolsRepository.CreateNewSchool(school);
    }

    public async Task<List<Package>> GetPackagesOfSchool(int schoolId)
    {
        return await _schoolsRepository.GetAllPackagesAssociatedToSchool(schoolId);
    }
    // public async Task AddSchoolAsync(School school) 
    // {
    //     _schoolsRepository.Schools.Add(school);
    //     await _schoolsRepository.SaveChangesAsync();
    // }
    //
    // public async Task UpdateSchool(School updatedSchool)
    // {
    //     _schoolsRepository.Entry(updatedSchool).State = EntityState.Modified;
    //     await _schoolsRepository.SaveChangesAsync();
    // }
    //
    // public async Task DeleteSchool(int id)
    // {
    //     var school = await _schoolsRepository.Schools.FindAsync(id);
    //     if (school != null)
    //     {
    //         _schoolsRepository.Schools.Remove(school);
    //         await _schoolsRepository.SaveChangesAsync();
    //     }
    // }
}