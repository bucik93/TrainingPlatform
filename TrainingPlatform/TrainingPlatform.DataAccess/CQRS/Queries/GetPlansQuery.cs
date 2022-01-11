using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Queries
{
    public class GetPlansQuery : QueryBase<List<Plan>>
    {
        public string Name { get; set; }
        public override Task<List<Plan>> Execute(TrainingPlatformContext context)
        {               
            return Name != null ? context.Plans.Include(x => x.ExercisePlans).ThenInclude(x => x.Exercise).AsNoTracking().Where(x => x.Name == this.Name).ToListAsync() 
                :  context.Plans.Include(x => x.ExercisePlans).ThenInclude(x => x.Exercise).AsNoTracking().ToListAsync();
        }
    }
}
