using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Front
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
