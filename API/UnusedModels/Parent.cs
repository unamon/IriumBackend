namespace API.UnusedModels;

public partial class Parent
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
