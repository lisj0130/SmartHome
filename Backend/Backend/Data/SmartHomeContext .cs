using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class SmartHomeContext : DbContext
{
    public SmartHomeContext(DbContextOptions<SmartHomeContext> options)
        : base(options)
    {
    }

    public DbSet<Log> Logs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
