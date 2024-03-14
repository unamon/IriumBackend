namespace API.UnusedModels;

public partial class Mock
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? CourseId { get; set; }

    public bool Imported { get; set; }

    public int Difficulty { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public bool? Active { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<MockQuestion> MockQuestions { get; set; } = new List<MockQuestion>();

    public virtual ICollection<MockResult> MockResults { get; set; } = new List<MockResult>();
}
