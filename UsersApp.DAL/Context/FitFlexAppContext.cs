using Microsoft.EntityFrameworkCore;
using UsersApp.DAL.Entities;

namespace UsersApp.DAL.Context
{
    public class FitFlexAppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public FitFlexAppContext(DbContextOptions<FitFlexAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
