namespace API.UnusedModels;

public partial class Period
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Seq { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
