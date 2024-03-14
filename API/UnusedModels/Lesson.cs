using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public string? Title { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual ICollection<SchoolsPackagesLesson> SchoolsPackagesLessons { get; set; } = new List<SchoolsPackagesLesson>();
}
