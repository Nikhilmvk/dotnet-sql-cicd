using Microsoft.EntityFrameworkCore;
using SimpleDotNetSqlApi.Models;

namespace SimpleDotNetSqlApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees"); // Map to your existing table
        }
    }
}
