using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs;

public class SchoolDto(string name, string inep)
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; } = name;
    [Required(AllowEmptyStrings = false)]
    public string Inep { get; set; } = inep;
}