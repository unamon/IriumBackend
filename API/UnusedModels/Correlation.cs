﻿namespace API.UnusedModels;

public partial class Correlation
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public int AnswerId { get; set; }

    public int CorrespId { get; set; }

    public virtual Answer Answer { get; set; } = null!;
}