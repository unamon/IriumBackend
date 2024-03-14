namespace API.UnusedModels;

public partial class MockResult
{
    public int Id { get; set; }

    public int? MockId { get; set; }

    public int? ProfileId { get; set; }

    public int? Area { get; set; }

    public int? Rsum { get; set; }

    public int? Miliseconds { get; set; }

    public virtual Mock? Mock { get; set; }

    public virtual Profile? Profile { get; set; }
}
