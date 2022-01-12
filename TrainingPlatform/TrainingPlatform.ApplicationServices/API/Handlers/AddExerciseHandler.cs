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

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class AddExerciseHandler : IRequestHandler<AddExerciseRequest, AddExerciseResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddExerciseHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddExerciseResponse> Handle(AddExerciseRequest request, CancellationToken cancellationToken)
        {
            var exercise = this.mapper.Map<DataAccess.Entities.Exercise>(request);
            var command = new AddExerciseCommand() { Parameter = exercise };
            var exerciseFromDb = await this.commandExecutor.Execute(command);
            return new AddExerciseResponse()
            {
                Data = this.mapper.Map<Domain.Models.Exercise>(exerciseFromDb)
            };
        }
    }
}