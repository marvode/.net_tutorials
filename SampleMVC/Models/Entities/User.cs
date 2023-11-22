namespace SampleMVC.Models.Entities;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
    public string? Image { get; set; }
    public string? Resume { get; set; }
    public DateTime CreatedAt { get; set; }

    public IEnumerable<Skill> Skills { get; set; }
}