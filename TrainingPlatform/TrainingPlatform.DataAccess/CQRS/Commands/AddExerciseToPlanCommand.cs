using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Commands
{
    public class AddExerciseToPlanCommand : CommandBase<ExercisePlan, ExercisePlan>
    {
        public override async Task<ExercisePlan> Execute(TrainingPlatformContext context)
        {
            await context.ExercisePlans.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}