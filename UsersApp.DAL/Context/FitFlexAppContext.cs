using FitFlexApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitFlexApp.DAL.Context
{
    public class FitFlexAppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TrainingPlan> TrainingPlans { get; set; } = null!;
        public DbSet<TrainingPlanType> TrainingPlanTypes { get; set; } = null!;
        public DbSet<AccessLevel> AccessLevel { get; set; } = null!;

        public FitFlexAppContext(DbContextOptions<FitFlexAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
