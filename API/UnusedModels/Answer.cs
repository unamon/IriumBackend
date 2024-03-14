using API.Models;

namespace API.UnusedModels;

public partial class Answer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int QuestionId { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public virtual ICollection<AnswerKey> AnswerKeys { get; set; } = new List<AnswerKey>();

    public virtual ICollection<Correlation> Correlations { get; set; } = new List<Correlation>();

    public virtual ICollection<Gap> Gaps { get; set; } = new List<Gap>();

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<Veritable> Veritables { get; set; } = new List<Veritable>();
}
