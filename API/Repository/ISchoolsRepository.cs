using API.Models;

namespace API.Services;

public interface ISchoolsRepository
{
    Task<IReadOnlyList<School>> GetAllSchoolsAsync();
    Task<School?> GetSchoolByIdAsync(int id); 
    Task CreateNewSchool(School newSchool);

}