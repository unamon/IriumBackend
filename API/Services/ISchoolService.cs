using API.Models;

namespace API.Services;

public interface ISchoolService
{
    Task<IReadOnlyList<School>> GetAllSchools();
    Task<School?> GetSchoolById(int id);
    Task AddSchoolAsync(School school);
}