using Microsoft.EntityFrameworkCore;
using SampleMVC.Models.Entities;

namespace SampleMVC.Data.Repositories;

public class UserRepository: IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<User> Add(User user)
    {
        await _context.Users.AddAsync(user);
        var response = await _context.SaveChangesAsync();

        if (response < 1) 
            throw new Exception("could not save data");
        
        return user;
    }

    public async Task<User> GetUserWithSkillsById(string userId)
    {
        // var user = await _context.Users.FindAsync(userId);
        var user = await _context.Users.Where(user => user.Id == userId)
            .Include(user => user.Skills)
            .FirstAsync();
        // var user = await _context.Users.FirstAsync(user => user.Id == userId);

        return user;
    }
}