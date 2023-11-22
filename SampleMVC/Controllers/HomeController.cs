using Microsoft.AspNetCore.Mvc;
using SampleMVC.Data.Repositories;
using SampleMVC.Models;

namespace SampleMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepository;

    public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        var model = new HomePageVM
        {
            Name = "Marvellous Odemwingie",
            Image = "/assets/image/home-img.png",
            JobTitle = "Senior Backend Developer",
            Description = "I have a passion for software. I enjoy creating tools that make life easier for people.",
            Skills = new[]
            {
                new Skill()
                {
                    Title = "High experience",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur <br> adipiscing elit, sed do eiusmod tempor <br> incididunt ut labore et dolore magna aliqua."
                },
                new Skill()
                {
                    Title = "Work Independently",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur <br> adipiscing elit, sed do eiusmod tempor <br> incididunt ut labore et dolore magna aliqua."
                },
                new Skill()
                {
                    Title = "High experience",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur <br> adipiscing elit, sed do eiusmod tempor <br> incididunt ut labore et dolore magna aliqua."
                },
            },
            Portfolios = new Portfolio[]
            {
                new ()
                {
                    Title = "Demo API Generator",
                    Description = "A dummy data free and documented API generator to facilitate <br> the process of testing the front-end portion of projects.",
                },
                new ()
                {
                    Title = "Demo API Generator",
                    Description = "A dummy data free and documented API generator to facilitate <br> the process of testing the front-end portion of projects.",
                },
                new ()
                {
                    Title = "Demo API Generator",
                    Description = "A dummy data free and documented API generator to facilitate <br> the process of testing the front-end portion of projects.",
                },
                new ()
                {
                    Title = "Demo API Generator",
                    Description = "A dummy data free and documented API generator to facilitate <br> the process of testing the front-end portion of projects.",
                },
            }
        };
        
        return View(model);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> User(string userId)
    {
        var user = await _userRepository.GetUserWithSkillsById(userId);

        var userVm = new UserVM
        {
            Name = user.Name,
            Description = user.About,
            Image = user.Image ?? ""
        };

        var skills = new List<Skill>();

        foreach (var skill in user.Skills)
        {
            skills.Add(new Skill
            {
                Description = skill.Text,
                Title = skill.Title,
            });
        }

        userVm.Skills = skills;
        
        return View(userVm);
    }
}