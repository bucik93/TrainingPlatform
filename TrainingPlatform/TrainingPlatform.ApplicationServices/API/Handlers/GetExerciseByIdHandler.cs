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
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class GetExerciseByIdHandler : IRequestHandler<GetExerciseByIdRequest, GetExerciseByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetExerciseByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetExerciseByIdResponse> Handle(GetExerciseByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetExerciseQuery() { Id = request.ExerciseId };
            var exercise = await this.queryExecutor.Execute(query);
            var mappedExercise = this.mapper.Map<Domain.Models.Exercise>(exercise);
            var response = new GetExerciseByIdResponse() { Data = mappedExercise };
            return response;
        }
    }
}
