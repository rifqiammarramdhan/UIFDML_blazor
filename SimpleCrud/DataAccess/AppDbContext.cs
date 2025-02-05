using Microsoft.EntityFrameworkCore;
using SimpleCrud.DataAccess.Entities;

namespace SimpleCrud.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.GenerateSeed();
        }
    }
}
