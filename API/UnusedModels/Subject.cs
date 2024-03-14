﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? ImageAlt { get; set; }

    public virtual ICollection<CoursesSubject> CoursesSubjects { get; set; } = new List<CoursesSubject>();

    public virtual ICollection<QuestsSubject> QuestsSubjects { get; set; } = new List<QuestsSubject>();
}
