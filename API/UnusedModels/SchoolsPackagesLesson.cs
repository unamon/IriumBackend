using System;
using System.Collections.Generic;

namespace API.Models;

public partial class SchoolsPackagesLesson
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int SchoolsPackagesId { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual SchoolsPackage SchoolsPackages { get; set; } = null!;
}
