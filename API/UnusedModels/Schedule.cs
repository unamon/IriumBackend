using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public string? Name { get; set; }

    public int? PeriodId { get; set; }

    public int? WeekNumber { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual Package Package { get; set; } = null!;

    public virtual Period? Period { get; set; }
}
