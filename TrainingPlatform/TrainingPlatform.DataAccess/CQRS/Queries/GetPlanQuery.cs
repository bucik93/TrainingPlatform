using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Queries
{
    public class GetPlanQuery : QueryBase<Plan>
    {
        public int Id { get; set; }
        public override async Task<Plan> Execute(TrainingPlatformContext context)
        {
            //var plan = await context.Plans.AsNoTracking().FirstOrDefaultAsync(x => x.Id == this.Id);
            var plan = await context.Plans.Include(x=>x.Exercises).AsNoTracking().FirstOrDefaultAsync(x => x.Id == this.Id);
            return plan;

        }
    }
}