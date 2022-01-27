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
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
     public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                Id = request.Id
            };

            var user = await this.queryExecutor.Execute(query);

            if (user != null)
            {
                var userToUpdate = this.mapper.Map<DataAccess.Entities.User>(request);
                userToUpdate.Salt = user.Salt;
                userToUpdate.HashedPassword = user.HashedPassword;
                var command = new UpdateUserCommand()
                {
                    Parameter = userToUpdate
                };

                var updatedUser = await this.commandExecutor.Execute(command);

                return new UpdateUserResponse()
                {
                    Data = this.mapper.Map<Domain.Models.User>(updatedUser)
                };
            }
            else
            {
                return new UpdateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }
    }
}

