using API.Data;
using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests;

public class SchoolServiceTests
{
    private readonly Mock<IriumContext> _ctxMock = new();
    private readonly SchoolService _sut;

    public SchoolServiceTests()
    {
        _sut = new SchoolService(_ctxMock.Object);
    }

    [Fact]
    public async Task GetAllSchoolsAsync_ShouldReturnList()
    {
        // Arrange
        var mockDbContext = new Mock<IriumContext>();
        var schoolsData = new List<School>
        {
            new() { Id = 1, Name = "School A" },
            new() { Id = 2, Name = "School B" },
            new() { Id = 3, Name = "School C" }
        }.AsQueryable();

        var mockDbSet = new Mock<DbSet<School>>();
        mockDbSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(schoolsData.Provider);
        mockDbSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(schoolsData.Expression);
        mockDbSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(schoolsData.ElementType);
        mockDbSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(schoolsData.GetEnumerator());

        mockDbContext.Setup(x => x.Set<School>()).Returns(mockDbSet.Object);

        var schoolService = new SchoolService(mockDbContext.Object);

        // Act
        var result = await schoolService.GetAllSchools();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count); // Assuming we have 3 schools in the mocked data
    }
}