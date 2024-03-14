namespace API.UnusedModels;

public partial class Character
{
    public int Id { get; set; }

    public int ImageIndex { get; set; }

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
