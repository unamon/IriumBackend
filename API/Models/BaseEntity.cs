using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class BaseEntity 
{
    public int Id { get; set; }
    [NotMapped]
    public string Hash { get; set; }
    [NotMapped]
    public bool Active { get; set; }
}