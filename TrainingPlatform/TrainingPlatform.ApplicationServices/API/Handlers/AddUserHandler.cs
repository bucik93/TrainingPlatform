using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.DataAccess.CQRS;
using TrainingPlatform.DataAccess.CQRS.Commands;
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public AddUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var usersQuery = new GetUsersQuery();
         
            var getUsers = await this.queryExecutor.Execute(usersQuery);

            if (getUsers.Select(x => x.UserName).Contains(request.UserName))
            {
                return new AddUserResponse()
                {
                    Error = new ErrorModel("A user with that name already exists in the database.")
                };
            }

            var hashPassword = ExtensionMethods.ExtensionMethods.EncodeBase64(request.Password);
            request.Password = hashPassword;

            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var command = new AddUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}
