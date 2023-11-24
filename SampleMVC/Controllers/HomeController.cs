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

    public async Task<IActionResult> Index()
    {
        var users = await _userRepository.GetAllUsers();
        
        return View(users);
    }
}