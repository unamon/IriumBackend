namespace API.UnusedModels;

public partial class Front
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
