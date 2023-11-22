namespace SampleMVC.Models.Entities;

public class Skill
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
}