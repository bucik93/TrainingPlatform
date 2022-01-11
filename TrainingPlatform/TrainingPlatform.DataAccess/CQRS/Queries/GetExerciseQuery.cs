using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Queries
{
    public class GetExerciseQuery : QueryBase<Exercise>
    {
        public int Id { get; set; }
        public override async Task<Exercise> Execute(TrainingPlatformContext context)
        {
            var exercise = await context.Exercises.AsNoTracking().FirstOrDefaultAsync(x => x.Id == this.Id);

            return exercise;

        }
    }
}