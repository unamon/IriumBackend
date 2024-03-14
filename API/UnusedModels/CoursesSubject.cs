namespace API.UnusedModels;

public partial class CoursesSubject
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int SubjectId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    public virtual Subject Subject { get; set; } = null!;
}
