namespace API.UnusedModels;

public partial class CoursesPlatform
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int PlatformId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Platform Platform { get; set; } = null!;
}
