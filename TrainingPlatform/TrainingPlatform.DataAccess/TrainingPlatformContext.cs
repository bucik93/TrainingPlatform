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
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
