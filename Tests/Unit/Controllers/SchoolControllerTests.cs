using API.Controllers;
using API.Models;
using API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.Unit.Controllers;

public class SchoolControllerTests
{
    private readonly Mock<ISchoolService> schoolService;

    public SchoolControllerTests()
    {
        schoolService = new Mock<ISchoolService>();
    }
    
    [Fact]
    public async void GetAllSchoolsAsync_ReturnSchools()
    {
        var schoolList = getSchoolsData();
        schoolService.Setup(x => x.GetAllSchools()).ReturnsAsync(schoolList);
        var schoolController = new SchoolsController(schoolService.Object);

        var actionResult = await schoolController.getAllSchools();
        
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
        var returnedSchools = Assert.IsAssignableFrom<IEnumerable<School>>(okObjectResult.Value);
        Assert.Equal(schoolList.Count, returnedSchools.Count());
    }

    [Fact]
    public async void getSchoolById_ReturnsSchool()
    {
        var mockSchool = new School()
        {
            Id = 1,
            Name = "Intellectus",
            Active = true,
            Hash = "gkjsaçlgjkldas"
        };
        schoolService.Setup(x => x.GetSchoolById(1)).ReturnsAsync(mockSchool);
        var schoolController = new SchoolsController(schoolService.Object);

        var actionResult = await schoolController.getSchoolById(1);

        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        var returnedSchool = Assert.IsAssignableFrom<School>(okResult.Value);
        Assert.Equal(returnedSchool, mockSchool );

    }

    public async void getSchoolById_ReturnsNotFound()
    {
        
    }
    public List<School> getSchoolsData()
    {
        List<School> schools = new List<School>()
        {
            new School()
            {
                Id = 0,
                Name = "Irium",
                Active = true,
                Hash = "gkjsaçlgjkldas"
            },
            new School()
            {
                Id = 1,
                Name = "Intellectus",
                Active = true,
                Hash = "gkjsaçlgjkldas"
            },
            new School()
            {
                Id = 2,
                Name = "Unintellectus",
                Active = false,
                Hash = "gkjsaçlgjkldas"
            },
            new School()
            {
                Id = 3,
                Name = "Orion",
                Active = true,
                Hash = "gkjsaçlgjkldas"
            },
        };
        return schools;
    }
}
