using System;
using System.Collections.Generic;

namespace API.Models;

public partial class SchoolsPlatform
{
    public int Id { get; set; }

    public int PlatformId { get; set; }

    public int SchoolId { get; set; }

    public virtual Platform Platform { get; set; } = null!;

    public virtual School School { get; set; } = null!;
}
