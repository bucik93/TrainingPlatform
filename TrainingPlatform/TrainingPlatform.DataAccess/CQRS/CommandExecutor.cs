using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.CQRS.Commands;

namespace TrainingPlatform.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly TrainingPlatformContext context;

        public CommandExecutor(TrainingPlatformContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
