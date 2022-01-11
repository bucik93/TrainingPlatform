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
    public class RemoveExerciseHandlers : IRequestHandler<RemoveExerciseRequest, RemoveExerciseResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveExerciseHandlers(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }


        public async Task<RemoveExerciseResponse> Handle(RemoveExerciseRequest request, CancellationToken cancellationToken)
        {
            var query = new GetExerciseQuery()
            {
                Id = request.ExerciseId
            };
            var exerciseToRemove = await this.queryExecutor.Execute(query);

            if (exerciseToRemove != null)
            {
                var command = new RemoveExerciseCommand()
                {
                    Parameter = exerciseToRemove
                };
                var removedExercise = await this.commandExecutor.Execute(command);

                return new RemoveExerciseResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Exercise>(removedExercise)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
