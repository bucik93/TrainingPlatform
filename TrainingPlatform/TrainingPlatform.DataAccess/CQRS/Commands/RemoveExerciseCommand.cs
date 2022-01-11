using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Commands
{
    public class RemoveExerciseCommand : CommandBase<Exercise, Exercise>
    {
        public override async Task<Exercise> Execute(TrainingPlatformContext context)
        {
            context.Exercises.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
