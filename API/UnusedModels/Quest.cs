using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Quest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Video { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public virtual ICollection<QuestsQuestion> QuestsQuestions { get; set; } = new List<QuestsQuestion>();

    public virtual ICollection<QuestsSubject> QuestsSubjects { get; set; } = new List<QuestsSubject>();
}
