using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int ProgressId { get; set; }

    public decimal GradeNumber { get; set; }

    public DateTime Created { get; set; }

    public int Chance { get; set; }

    public int? MockId { get; set; }

    public int? ProfileId { get; set; }
}
