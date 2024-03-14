using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Gap
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string? Placeholder { get; set; }

    public string? Value { get; set; }

    public int GapNumber { get; set; }

    public int? AnswerId { get; set; }

    public virtual Answer? Answer { get; set; }
}
