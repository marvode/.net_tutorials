namespace SampleMVC.Models;

public class HomePageVM
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string JobTitle { get; set; }
    public string Description { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
    public IEnumerable<Portfolio> Portfolios { get; set; }
}

public class Skill
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class Portfolio
{
    public string Title { get; set; }
    public string Description { get; set; }
}