using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ContentType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Order { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}
