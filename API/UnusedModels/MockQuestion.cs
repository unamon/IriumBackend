namespace API.UnusedModels;

public partial class MockQuestion
{
    public int Id { get; set; }

    public int MockId { get; set; }

    public int QuestionId { get; set; }

    public string? Video { get; set; }

    public bool? BaseText { get; set; }

    public bool? FileAnswer { get; set; }

    public virtual Mock Mock { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
