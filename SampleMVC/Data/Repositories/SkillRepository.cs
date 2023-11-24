using SampleMVC.Models.Entities;

namespace SampleMVC.Data.Repositories;

public class SkillRepository: ISkillRepository
{
    private readonly DatabaseContext _context;

    public SkillRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Skill> Add(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
        if (await _context.SaveChangesAsync() < 1)
            throw new Exception("could not save data");

        return skill;
    }

    public async Task<Skill?> GetSkillById(string skillId)
    {
        return await _context.Skills.FindAsync(skillId);
    }

    public async Task<Skill> Update(Skill updatedSkill)
    {
        _context.Skills.Update(updatedSkill);
        if (await _context.SaveChangesAsync() < 1)
            throw new Exception("could not save data");

        return updatedSkill;
    }

    public async Task Delete(Skill skill)
    {
        _context.Skills.Remove(skill);
        if (await _context.SaveChangesAsync() < 1)
            throw new Exception("could not delete data");
    }
}