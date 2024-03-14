namespace API.UnusedModels;

public partial class DocumentAnnotation
{
    public int Id { get; set; }

    public string? Annotation { get; set; }

    public int? DocumentQuestionId { get; set; }

    public int? ProfileId { get; set; }

    public int? DocumentId { get; set; }

    public int? Page { get; set; }

    public DateTime? Created { get; set; }

    public string? FilePath { get; set; }

    public virtual Document? Document { get; set; }

    public virtual ICollection<DocumentCorrection> DocumentCorrections { get; set; } = new List<DocumentCorrection>();

    public virtual DocumentQuestion? DocumentQuestion { get; set; }

    public virtual Profile? Profile { get; set; }
}
