using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Commands
{
    public class AddExerciseCommand : CommandBase<Exercise, Exercise>
    {
        public override async Task<Exercise> Execute(TrainingPlatformContext context)
        {
            await context.Exercises.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}