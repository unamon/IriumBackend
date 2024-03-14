namespace API.UnusedModels;

public partial class Document
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public string? Name { get; set; }

    public string? FileAlt { get; set; }

    public string? FileName { get; set; }

    public int? TypeId { get; set; }

    public string? Description { get; set; }

    public string? Link { get; set; }

    public string? Video { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public bool? Conclusion { get; set; }

    public bool? Active { get; set; }

    public bool IsOpen { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<DocumentAnnotation> DocumentAnnotations { get; set; } = new List<DocumentAnnotation>();

    public virtual ICollection<DocumentQuestion> DocumentQuestions { get; set; } = new List<DocumentQuestion>();

    public virtual DocumentType? Type { get; set; }
}
