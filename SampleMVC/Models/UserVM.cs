namespace SampleMVC.Models;

public class UserVM
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
}