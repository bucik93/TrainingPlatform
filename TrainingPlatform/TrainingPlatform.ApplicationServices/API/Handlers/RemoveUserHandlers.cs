using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.ApplicationServices.API.ErrorHandling;
using TrainingPlatform.DataAccess.CQRS;
using TrainingPlatform.DataAccess.CQRS.Commands;
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class RemoveUserHandlers : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveUserHandlers(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                Id = request.UserId
            };
            var userToRemove = await this.queryExecutor.Execute(query);

            if (userToRemove != null)
            {

                var command = new RemoveUserCommand()
                {
                    Parameter = userToRemove
                };
                var removedUser = await this.commandExecutor.Execute(command);

                return new RemoveUserResponse()
                {
                    Data = this.mapper.Map<Domain.Models.User>(removedUser)
                };
            }
            else
            {
                return new RemoveUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }
    }
}
