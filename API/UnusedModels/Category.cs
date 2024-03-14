using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public string? Platform { get; set; }

    public int? FrontId { get; set; }

    public string? ShortName { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Front? Front { get; set; }
}
