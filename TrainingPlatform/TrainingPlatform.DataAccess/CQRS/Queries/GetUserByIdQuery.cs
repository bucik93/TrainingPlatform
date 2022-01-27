using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Queries
{
   public class GetUserByIdQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(TrainingPlatformContext context)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == this.Id);

            return user;

        }
    }
}
