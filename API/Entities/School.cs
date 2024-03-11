using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class School : BaseEntity
{
    [Required]
    public string? Name { get; set; }
    
    public string? Inep { get; set; }
    public string? EduQuestPartnerId { get; set; }
    public string? ArvorePartnerId { get; set; }
    public string? ArvoreReferenceId { get; set; }
    public string? EduQuestPath { get; set; }
    
}