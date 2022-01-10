using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Queries
{
    public class GetExercisesQuery : QueryBase<List<Exercise>>
    {
        public override Task<List<Exercise>> Execute(TrainingPlatformContext context)
        {
            return context.Exercises.ToListAsync();
        }
    }
}
