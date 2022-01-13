using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class ValidateUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public ValidateUserHandler(IMapper mapper, IQueryExecutor queryExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                UserName = request.Username
            };

            var user = this.queryExecutor.Execute(query).Result;

            if (user == null)
            {
                return new ValidateUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var hashedRequestPassword = this.passwordHasher.HashPassword(request.Password, user.Salt).Result;
            var isPasswordConfirmed = this.passwordHasher.IsPasswordConfirmed(user.HashedPassword, hashedRequestPassword).Result;

            if (!isPasswordConfirmed)
            {
                return new ValidateUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.ValidationError)
                };
            }

            return new ValidateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(user)
            };
        }
    }
}