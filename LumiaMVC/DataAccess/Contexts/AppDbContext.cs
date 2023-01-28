using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {


    }

    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}
