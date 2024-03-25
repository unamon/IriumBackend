using API.Models;
using API.Models.DTOs;

namespace API.Services;

public interface ISchoolService
{
    Task<IReadOnlyList<School>> GetAllSchools();
    Task<School?> GetSchoolById(int id);
    Task AddSchoolAsync(School school);
    Task<List<Package>> GetPackagesOfSchool(int schoolId);
    Task AddPackageToSchool(int schooldId, int packageId);
    Task DeleteSchool(int schoolId);
    Task UpdateSchoolAsync(int id, SchoolDto updatedSchool);
}