namespace API.UnusedModels;

public partial class ProfileActivity
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public int ProfileId { get; set; }

    public DateTime Created { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Profile Profile { get; set; } = null!;
}
