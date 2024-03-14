namespace API.UnusedModels;

public partial class Strip
{
    public int Id { get; set; }

    public decimal StripBegin { get; set; }

    public decimal StripEnd { get; set; }

    public int Type { get; set; }

    public int Nth { get; set; }
}
