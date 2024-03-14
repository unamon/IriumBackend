using System;
using System.Collections.Generic;

namespace API.UnusedModels;

public partial class Activity
{
    public int Id { get; set; }

    public DateTime? DueDate { get; set; }

    public int? CreateUser { get; set; }

    public string? Message { get; set; }

    public int PackageId { get; set; }

    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public int? ScheduleId { get; set; }

    public bool? Active { get; set; }

    public bool? DefaultCalendar { get; set; }

    public bool IsOpen { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<Performed> Performeds { get; set; } = new List<Performed>();

    public virtual ICollection<ProfileActivity> ProfileActivities { get; set; } = new List<ProfileActivity>();

    public virtual Schedule? Schedule { get; set; }
}
