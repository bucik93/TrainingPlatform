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
using TrainingPlatform.ApplicationServices.Components.PasswordHasher;
using TrainingPlatform.DataAccess.CQRS;
using TrainingPlatform.DataAccess.CQRS.Commands;
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        private readonly IMapper mapper;

        public AddUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IPasswordHasher passwordHasher)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
            this.mapper = mapper;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            //var usersQuery = new GetUsersQuery();

            //var getUsers = await this.queryExecutor.Execute(usersQuery);

            //if (getUsers.Select(x => x.Username).Contains(request.UserName))
            //{
            //    return new AddUserResponse()
            //    {
            //        Error = new ErrorModel("A user with that name already exists in the database.")
            //    };
            //}

            //var hashPassword = ExtensionMethods.ExtensionMethods.EncodeBase64(request.Password);
            //request.Password = hashPassword;

            //var user = this.mapper.Map<DataAccess.Entities.User>(request);
            //var command = new AddUserCommand() { Parameter = user };
            //var userFromDb = await this.commandExecutor.Execute(command);
            //return new AddUserResponse()
            //{
            //    Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            //};
            var usersQuery = new GetUsersQuery();

            var getUsers = await this.queryExecutor.Execute(usersQuery);

            if (getUsers.Select(x => x.Username).Contains(request.UserName))
            {
                return new AddUserResponse()
                {
                    Error = new ErrorModel("A user with that name already exists in the database.")
                };
            }
            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var salt = this.passwordHasher.GenerateSalt().Result;
            var hashedPassword = this.passwordHasher.HashPassword(request.Password, salt).Result;

            user.Salt = salt;
            user.HashedPassword = hashedPassword;

            var addUserCommand = new AddUserCommand()
            {
                Parameter = user
            };
            var addedUser = this.commandExecutor.Execute(addUserCommand).Result;

            if (addedUser == null)
            {
                return new AddUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.ValidationError)
                };
            }

            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(addedUser)
            };
        }
    }
}
