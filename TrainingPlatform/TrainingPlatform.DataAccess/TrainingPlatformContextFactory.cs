using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess
{
    public class TrainingPlatformContextFactory : IDesignTimeDbContextFactory<TrainingPlatformContext>
    {
        public TrainingPlatformContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainingPlatformContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-21D1QB4;Initial Catalog=TrainingPlatform;Integrated Security=True");
            return new TrainingPlatformContext(optionsBuilder.Options);
        }
    }
}
