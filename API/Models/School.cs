﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class School
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Inep { get; set; }

    public int? ArvorePartnerId { get; set; }

    public string? EduQuestPartnerId { get; set; }

    public string? ArvoreReferenceId { get; set; }

    public string? EduQuestPath { get; set; }

    public bool? DefaultCalendar { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<SchoolsPackage> SchoolsPackages { get; set; } = new List<SchoolsPackage>();

    public virtual ICollection<SchoolsPlatform> SchoolsPlatforms { get; set; } = new List<SchoolsPlatform>();

    public virtual ICollection<SchoolsStudent> SchoolsStudents { get; set; } = new List<SchoolsStudent>();
}
