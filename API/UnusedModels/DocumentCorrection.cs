namespace API.UnusedModels;

public partial class DocumentCorrection
{
    public int Id { get; set; }

    public string? Correction { get; set; }

    public int? DocumentAnnotationId { get; set; }

    public int? ProfileId { get; set; }

    public virtual DocumentAnnotation? DocumentAnnotation { get; set; }

    public virtual Profile? Profile { get; set; }
}
