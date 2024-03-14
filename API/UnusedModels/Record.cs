using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Record
{
    public int Id { get; set; }

    public decimal GradeNumber { get; set; }

    public int SchoolsPackagesId { get; set; }

    public int CourseId { get; set; }

    public int PlatformId { get; set; }

    public int ReferenceId { get; set; }

    public int ProfileId { get; set; }

    public string ReferenceName { get; set; } = null!;

    public int? Year { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedUser { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Platform Platform { get; set; } = null!;

    public virtual Profile Profile { get; set; } = null!;

    public virtual SchoolsPackage SchoolsPackages { get; set; } = null!;
}
