using SampleMVC.Models.Entities;

namespace SampleMVC.Data.Repositories;

public interface ISkillRepository
{
    public Task<Skill> Add(Skill skill);
    public Task<Skill?> GetSkillById(string skillId);
    public Task<Skill> Update(Skill updatedSkill);
    public Task Delete(Skill skill);
}