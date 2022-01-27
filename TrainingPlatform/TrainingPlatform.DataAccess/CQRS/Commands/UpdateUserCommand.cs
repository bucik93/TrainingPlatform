using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.CQRS.Commands
{
    public class UpdateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(TrainingPlatformContext context)
        {
            context.Users.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
