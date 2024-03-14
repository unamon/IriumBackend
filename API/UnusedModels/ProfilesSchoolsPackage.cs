namespace API.UnusedModels;

public partial class ProfilesSchoolsPackage
{
    public int Id { get; set; }

    public int ProfileId { get; set; }

    public int SchoolsPackagesId { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    // public virtual SchoolsPackage SchoolsPackages { get; set; } = null!;
}
