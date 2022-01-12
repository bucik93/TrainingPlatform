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
using TrainingPlatform.DataAccess;
using TrainingPlatform.DataAccess.CQRS;
using TrainingPlatform.DataAccess.CQRS.Queries;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class GetExercisesHandler : IRequestHandler<GetExercisesRequest, GetExercisesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetExercisesHandler(IMapper mapper , IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetExercisesResponse> Handle(GetExercisesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetExercisesQuery();
            var exercises = await this.queryExecutor.Execute(query);
            if (exercises == null)
            {
                return new GetExercisesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedExercise = this.mapper.Map<List<Domain.Models.Exercise>>(exercises);
            var response = new GetExercisesResponse() { Data = mappedExercise };
            return response;
        }
    }
}
