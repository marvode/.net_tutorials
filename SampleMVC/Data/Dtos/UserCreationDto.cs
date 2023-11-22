using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Data.Dtos;

public class UserCreationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string About { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public IFormFile Resume { get; set; }
}