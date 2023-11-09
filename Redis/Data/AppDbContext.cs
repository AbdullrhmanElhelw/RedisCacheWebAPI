using Microsoft.EntityFrameworkCore;

namespace Redis;

public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; } 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Person>().HasData(
              new Person { Id = 1, Name = "John", Age = 20 },
              new Person { Id = 2, Name = "Jane", Age = 30 },
              new Person { Id = 3, Name = "Jack", Age = 40 }
            );
    }


}

