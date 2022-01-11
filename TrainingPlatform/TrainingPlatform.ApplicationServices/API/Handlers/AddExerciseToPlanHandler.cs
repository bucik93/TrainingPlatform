using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.ApplicationServices.API.Domain.Models;
using TrainingPlatform.DataAccess.CQRS;
using TrainingPlatform.DataAccess.CQRS.Commands;
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class AddExerciseToPlanHandler : IRequestHandler<AddExerciseToPlanRequest, AddExerciseToPlanResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public AddExerciseToPlanHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<AddExerciseToPlanResponse> Handle(AddExerciseToPlanRequest request, CancellationToken cancellationToken)
        {
            var exercisePlan = this.mapper.Map<DataAccess.Entities.ExercisePlan>(request);
            var command = new AddExerciseToPlanCommand() { Parameter = exercisePlan };
            var exercisePlanFromDb = await this.commandExecutor.Execute(command);
            return new AddExerciseToPlanResponse()
            {
                Data = this.mapper.Map<Domain.Models.ExercisePlan>(exercisePlanFromDb)
            };

        }
    }
}