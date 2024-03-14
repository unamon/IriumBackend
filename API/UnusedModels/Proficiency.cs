using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Proficiency
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? ProfileId { get; set; }

    public double? Participation { get; set; }

    public double? Performance { get; set; }

    public double? ProficiencyNumber { get; set; }
}
