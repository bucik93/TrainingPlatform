using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Commands
{
    public class RemovePlanCommand : CommandBase<Plan, Plan>
    {
        public override async Task<Plan> Execute(TrainingPlatformContext context)
        {
            context.Plans.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
