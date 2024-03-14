using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Question
{
    public int Id { get; set; }

    public int Type { get; set; }

    public string? Enunciation { get; set; }

    public string? Comment { get; set; }

    public int? CompetencyId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Competency? Competency { get; set; }

    public virtual ICollection<MockQuestion> MockQuestions { get; set; } = new List<MockQuestion>();

    public virtual ICollection<QuestsQuestion> QuestsQuestions { get; set; } = new List<QuestsQuestion>();
}
