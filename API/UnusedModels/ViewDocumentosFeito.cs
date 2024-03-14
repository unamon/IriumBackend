using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ViewDocumentosFeito
{
    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Expr1 { get; set; }

    public string ReferenceName { get; set; } = null!;

    public int ReferenceId { get; set; }

    public int PlatformId { get; set; }

    public string? FilePath { get; set; }

    public string? Expr2 { get; set; }

    public int? ProfileId { get; set; }
}
