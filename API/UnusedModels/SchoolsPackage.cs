using System;
using System.Collections.Generic;

namespace API.Models;

public partial class SchoolsPackage
{
    public int Id { get; set; }

    public int SchoolId { get; set; }

    public int PackageId { get; set; }

    public string? Name { get; set; }

    public int? ArvorePartnerId { get; set; }

    public string? ArvoreReferenceId { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<ProfilesSchoolsPackage> ProfilesSchoolsPackages { get; set; } = new List<ProfilesSchoolsPackage>();

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual School School { get; set; } = null!;

    public virtual ICollection<SchoolsPackagesLesson> SchoolsPackagesLessons { get; set; } = new List<SchoolsPackagesLesson>();
}
