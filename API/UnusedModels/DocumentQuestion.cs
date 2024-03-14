namespace API.UnusedModels;

public partial class DocumentQuestion
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public string? Enunciation { get; set; }

    public bool? FileAnswer { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual ICollection<DocumentAnnotation> DocumentAnnotations { get; set; } = new List<DocumentAnnotation>();
}
