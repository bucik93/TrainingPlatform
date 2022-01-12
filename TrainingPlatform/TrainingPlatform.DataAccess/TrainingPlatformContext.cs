using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess
{
    public class TrainingPlatformContext : DbContext
    {
        public TrainingPlatformContext(DbContextOptions<TrainingPlatformContext> opt) : base(opt)
        {
        }

        public DbSet<ExercisePlan> ExercisePlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingPlatformContext).Assembly);

            modelBuilder.Entity<ExercisePlan>()
                .HasKey(bc => new { bc.PlanId, bc.ExerciseId });
            modelBuilder.Entity<ExercisePlan>()
                .HasOne(bc => bc.Plan)
                .WithMany(b => b.ExercisePlans)
                .HasForeignKey(bc => bc.PlanId);
            modelBuilder.Entity<ExercisePlan>()
                .HasOne(bc => bc.Exercise)
                .WithMany(c => c.ExercisePlans)
                .HasForeignKey(bc => bc.ExerciseId);
        }
    }
}
