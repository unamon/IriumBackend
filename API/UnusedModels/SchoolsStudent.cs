using System;
using System.Collections.Generic;

namespace API.Models;

public partial class SchoolsStudent
{
    public int Id { get; set; }

    public int SchoolId { get; set; }

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual School School { get; set; } = null!;
}
