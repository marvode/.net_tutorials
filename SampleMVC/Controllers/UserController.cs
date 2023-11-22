using Microsoft.AspNetCore.Mvc;
using SampleMVC.Data.Dtos;
using SampleMVC.Data.Repositories;
using SampleMVC.Models.Entities;

namespace SampleMVC.Controllers;

[Route("auth")]
public class UserController: Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("register")]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(UserCreationDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            About = userDto.About,
            CreatedAt = DateTime.Now
        };

        var response = await _userRepository.Add(user);

        return RedirectToAction("User", "Home", new {userId = user.Id});
    }
}