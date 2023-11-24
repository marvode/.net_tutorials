using Microsoft.AspNetCore.Mvc;
using SampleMVC.Data.Dtos;
using SampleMVC.Data.Repositories;
using SampleMVC.Models;
using SampleMVC.Models.Entities;

namespace SampleMVC.Controllers;

[Route("")]
public class UserController: Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserPortfolio(string userId)
    {
        var user = await _userRepository.GetUserWithSkillsById(userId);

        var userVm = new UserVM
        {
            Name = user.Name,
            Image = user.Image,
            Description = user.About,
            Skills = user.Skills,
        };

        ViewBag.UserId = userId;
        
        return View(userVm);
    }

    [HttpGet("register")]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromForm] UserCreationDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            About = userDto.About,
            CreatedAt = DateTime.Now,
        };

        var response = await _userRepository.Add(user);

        return RedirectToAction("GetUserPortfolio", new {userId = user.Id});
    }
}