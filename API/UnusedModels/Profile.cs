namespace API.UnusedModels;

public partial class Profile
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<AspNetUser> AspNetUsers { get; set; } = new List<AspNetUser>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<DocumentAnnotation> DocumentAnnotations { get; set; } = new List<DocumentAnnotation>();

    public virtual ICollection<DocumentCorrection> DocumentCorrections { get; set; } = new List<DocumentCorrection>();

    public virtual ICollection<MockResult> MockResults { get; set; } = new List<MockResult>();

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    public virtual ICollection<Performed> Performeds { get; set; } = new List<Performed>();

    public virtual ICollection<ProfileActivity> ProfileActivities { get; set; } = new List<ProfileActivity>();

    public virtual ICollection<ProfilesSchoolsPackage> ProfilesSchoolsPackages { get; set; } = new List<ProfilesSchoolsPackage>();

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual ICollection<SchoolsStudent> SchoolsStudents { get; set; } = new List<SchoolsStudent>();
}
