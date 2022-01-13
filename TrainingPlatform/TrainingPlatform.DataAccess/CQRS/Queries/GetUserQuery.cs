using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string UserName { get; set; }
        public override Task<User> Execute(TrainingPlatformContext context)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Username == this.UserName);
        }
    }
}