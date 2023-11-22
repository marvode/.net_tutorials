using Microsoft.EntityFrameworkCore;
using SampleMVC.Models.Entities;

namespace SampleMVC.Data;

public class DatabaseContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
    {
        
    }
}