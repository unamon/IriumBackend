namespace API.UnusedModels;

public partial class Veritable
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public bool Truth { get; set; }

    public int? AnswerId { get; set; }

    public virtual Answer? Answer { get; set; }
}
