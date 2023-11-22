using SampleMVC.Models.Entities;

namespace SampleMVC.Data.Repositories;

public interface ISkillRepository
{
    public Task<Skill> Add(Skill skill);
}