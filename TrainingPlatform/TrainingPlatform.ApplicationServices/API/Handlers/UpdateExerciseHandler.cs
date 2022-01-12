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
    public class UpdateExerciseHandler : IRequestHandler<UpdateExerciseRequest, UpdateExerciseResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateExerciseHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<UpdateExerciseResponse> Handle(UpdateExerciseRequest request, CancellationToken cancellationToken)
        {
            var query = new GetExerciseQuery()
            {
                Id = request.ExerciseId
            };

            var exerciseToUpdate = await this.queryExecutor.Execute(query);

            if (exerciseToUpdate != null)
            {
                exerciseToUpdate = this.mapper.Map<DataAccess.Entities.Exercise>(request);
                var command = new UpdateExerciseCommand()
                {
                    Parameter = exerciseToUpdate
                };

                var updatedExercise = await this.commandExecutor.Execute(command);

                return new UpdateExerciseResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Exercise>(updatedExercise)
                };
            }
            else
            {
                return new UpdateExerciseResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }
    }
}


