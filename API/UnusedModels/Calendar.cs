using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Calendar
{
    public int Id { get; set; }

    public int? ScheduleId { get; set; }

    public int ActivityId { get; set; }

    public DateOnly? DueDate { get; set; }

    public int PackageId { get; set; }

    public int SchoolId { get; set; }

    public string? Title { get; set; }

    public bool Active { get; set; }

    public int? CategoryId { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Category? Category { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual Schedule? Schedule { get; set; }

    public virtual School School { get; set; } = null!;
}
