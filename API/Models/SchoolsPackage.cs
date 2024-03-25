using API.Models;

namespace API.Models;

public partial class SchoolsPackage : BaseEntity
{
    public int SchoolId { get; set; }
    public virtual School School { get; set; } = null!;

    public int PackageId { get; set; }
    public virtual Package Package { get; set; } = null!;

    public string? Name { get; set; }

    public int? ArvorePartnerId { get; set; }

    public string? ArvoreReferenceId { get; set; }

    //
    // public virtual ICollection<ProfilesSchoolsPackage> ProfilesSchoolsPackages { get; set; } = new List<ProfilesSchoolsPackage>();
    //
    // public virtual ICollection<Record> Records { get; set; } = new List<Record>();
    //
    //
    // public virtual ICollection<SchoolsPackagesLesson> SchoolsPackagesLessons { get; set; } = new List<SchoolsPackagesLesson>();
}
