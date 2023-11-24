using Microsoft.AspNetCore.Mvc;
using SampleMVC.Data.Dtos;
using SampleMVC.Data.Repositories;
using SampleMVC.Models.Entities;

namespace SampleMVC.Controllers;

[Route("skills")]
public class SkillController : Controller
{
    private readonly ISkillRepository _skillRepository;

    public SkillController(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    [HttpGet("{userId}")]
    public IActionResult AddSkill(string userId)
    {
        ViewBag.UserId = userId;
        return View();
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddSkill(string userId, [FromForm] AddSkillDto addSkillDto)
    {
        var skill = new Skill
        {
            UserId = userId,
            Title = addSkillDto.Title,
            Text = addSkillDto.Text,
            CreatedAt = DateTime.Now,
        };

        await _skillRepository.Add(skill);

        return RedirectToAction("GetUserPortfolio", "User", new {userId = userId});
    }

    [HttpGet("edit/{skillId}")]
    public async Task<IActionResult> Edit(string skillId)
    {
        var skill = await _skillRepository.GetSkillById(skillId);
        
        if (skill == null)
            return BadRequest();
        
        var skillDto = new AddSkillDto
        {
            Title = skill.Title,
            Text = skill.Text
        };
        
        ViewBag.SkillId = skillId;
        
        return View(skillDto);
    }

    [HttpPost("edit/{skillId}")]
    public async Task<IActionResult> Edit(string skillId, [FromForm] AddSkillDto editSkillDto)
    {
        var skill = await _skillRepository.GetSkillById(skillId);
        
        if (skill == null)
            return BadRequest();

        skill.Title = editSkillDto.Title;
        skill.Text = editSkillDto.Text;

        await _skillRepository.Update(skill);

        return RedirectToAction("GetUserPortfolio", "User", new {userId = skill.UserId});
    }

    [HttpPost("delete/{skillId}")]
    public async Task<IActionResult> Delete(string skillId)
    {
        var skill = await _skillRepository.GetSkillById(skillId);

        await _skillRepository.Delete(skill);

        return RedirectToAction("GetUserPortfolio", "User", new {userId = skill.UserId});
    }
}