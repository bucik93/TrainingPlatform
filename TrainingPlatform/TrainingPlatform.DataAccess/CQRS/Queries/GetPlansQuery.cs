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
        public override Task<List<Plan>> Execute(TrainingPlatformContext context)
        {
            return context.Plans.ToListAsync();
        }
    }
}
