using System;
using System.Collections.Generic;

namespace API.Models;

public partial class QuestsSubject
{
    public int Id { get; set; }

    public int QuestId { get; set; }

    public int SubjectId { get; set; }

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    public virtual Quest Quest { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
