using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Answered
{
    public int Id { get; set; }

    public int? ProgressId { get; set; }

    public int? QuestsQuestionsId { get; set; }

    public bool Result { get; set; }

    public int? Elapsed { get; set; }

    public int? Chance { get; set; }

    public int QuestionOrder { get; set; }

    public int? QuestionId { get; set; }

    public int? ProfileId { get; set; }

    public int? AnswerId { get; set; }

    public string? FilePath { get; set; }

    public bool Corrected { get; set; }

    public virtual Progress? Progress { get; set; }
}
