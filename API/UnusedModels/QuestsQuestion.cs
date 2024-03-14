using System;
using System.Collections.Generic;

namespace API.Models;

public partial class QuestsQuestion
{
    public int Id { get; set; }

    public int QuestId { get; set; }

    public int QuestionId { get; set; }

    public virtual Quest Quest { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
