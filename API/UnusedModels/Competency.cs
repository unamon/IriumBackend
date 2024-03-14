namespace API.UnusedModels;

public partial class Competency
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Area { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
