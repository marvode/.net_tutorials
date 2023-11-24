using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Data.Dtos;

public class AddSkillDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Text { get; set; }
}