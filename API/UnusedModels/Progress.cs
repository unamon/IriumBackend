namespace API.UnusedModels;

public partial class Progress
{
    public int Id { get; set; }

    public int ProfileSchoolsPackageId { get; set; }

    public int CoursesPackagesId { get; set; }

    public int CoursesSubjectsId { get; set; }

    public int QuestsSubjectsId { get; set; }

    public int Lifes { get; set; }

    public bool Completed { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public int Status { get; set; }

    public int GradeNth { get; set; }

    public virtual ICollection<Answered> Answereds { get; set; } = new List<Answered>();

    public virtual CoursesPackage CoursesPackages { get; set; } = null!;

    public virtual CoursesSubject CoursesSubjects { get; set; } = null!;

    public virtual ProfilesSchoolsPackage ProfileSchoolsPackage { get; set; } = null!;

    public virtual QuestsSubject QuestsSubjects { get; set; } = null!;
}
