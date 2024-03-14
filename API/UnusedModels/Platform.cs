using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Platform
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Link { get; set; }

    public virtual ICollection<CoursesPlatform> CoursesPlatforms { get; set; } = new List<CoursesPlatform>();

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual ICollection<SchoolsPlatform> SchoolsPlatforms { get; set; } = new List<SchoolsPlatform>();
}
