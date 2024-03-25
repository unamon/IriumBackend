namespace API.Models;

public class Package : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public string? NameEduQuest { get; set; }

    // public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
    //
    // public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
    //
    // public virtual ICollection<CoursesPackage> CoursesPackages { get; set; } = new List<CoursesPackage>();
    //
    // public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    //
    public virtual ICollection<SchoolsPackage> SchoolsPackages { get; set; } = new List<SchoolsPackage>();
}