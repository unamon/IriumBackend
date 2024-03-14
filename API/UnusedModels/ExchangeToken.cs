using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ExchangeToken
{
    public int Id { get; set; }

    public string? TokenId { get; set; }

    public string? Email { get; set; }
}
