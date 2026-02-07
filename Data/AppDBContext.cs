using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Models;

namespace YourProjectNamespace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users => Set<User>();
    }
}
