namespace API.UnusedModels;

public partial class Content
{
    public int Id { get; set; }

    public int ContentTypeId { get; set; }

    public int? ParentId { get; set; }

    public string? Description { get; set; }

    public int ActivityId { get; set; }

    public string? Link { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public int PlatformId { get; set; }

    public bool Video { get; set; }

    public string? Code { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual ContentType ContentType { get; set; } = null!;
}
