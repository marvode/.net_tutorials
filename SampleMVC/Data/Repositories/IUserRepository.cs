using SampleMVC.Models.Entities;

namespace SampleMVC.Data.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllUsers();
    public Task<User> Add(User user);
    public Task<User> GetUserWithSkillsById(string userId);
}