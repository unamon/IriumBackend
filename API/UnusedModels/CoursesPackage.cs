namespace API.UnusedModels;

public partial class CoursesPackage
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
