using API.Models;
using API.Models.DTOs;

namespace API.Services;

public interface ISchoolsRepository
{
    Task<IReadOnlyList<School>> GetAllSchoolsAsync();
    Task<School?> GetSchoolByIdAsync(int id); 
    Task CreateNewSchool(School newSchool);
    Task<List<Package>> GetAllPackagesAssociatedToSchool(int schoolId);
    Task AddPackageToSchool(int schoolId, int packageId);
    Task DeleteSchool(int schoolId);
    Task UpdateSchoolAsync(int id, SchoolDto school);
}