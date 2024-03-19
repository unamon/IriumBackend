namespace API.Models.DTOs;

public class SchoolDto(string name, string inep)
{
    public string Name { get; set; } = name;
    public string Inep { get; set; } = inep;
}