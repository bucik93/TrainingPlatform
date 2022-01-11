using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Commands
{
    public class UpdateExerciseCommand : CommandBase<Exercise, Exercise>
    {
        public override async Task<Exercise> Execute(TrainingPlatformContext context)
        {
            context.Exercises.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
