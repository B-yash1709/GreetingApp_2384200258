using Microsoft.EntityFrameworkCore;
using ModelLayer.Model; // Import your models

namespace RepositoryLayer.Context
{
    public class HelloGreetingDbContext : DbContext
    {
        public HelloGreetingDbContext(DbContextOptions<HelloGreetingDbContext> options) : base(options) { }

        public DbSet<GreetingEntity> Greetings { get; set; } // Your table
    }
}
