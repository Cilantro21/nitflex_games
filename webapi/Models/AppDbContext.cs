using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}
