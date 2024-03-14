namespace API.UnusedModels;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public string? Platform { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<CoursesPackage> CoursesPackages { get; set; } = new List<CoursesPackage>();

    public virtual ICollection<CoursesPlatform> CoursesPlatforms { get; set; } = new List<CoursesPlatform>();

    public virtual ICollection<CoursesSubject> CoursesSubjects { get; set; } = new List<CoursesSubject>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Mock> Mocks { get; set; } = new List<Mock>();

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
