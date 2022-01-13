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
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var users = await this.queryExecutor.Execute(query);
            if (users == null)
            {
                return new GetUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);
            var response = new GetUsersResponse() { Data = mappedUsers };
            return response;
        }
    }
}

