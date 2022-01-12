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
    public class RemovePlanHandlers : IRequestHandler<RemovePlanRequest, RemovePlanResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemovePlanHandlers(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
      
        public async Task<RemovePlanResponse> Handle(RemovePlanRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlanQuery()
            {
                Id = request.PlanId
            };
            var planToRemove = await this.queryExecutor.Execute(query);

            if (planToRemove != null)
            {

                var command = new RemovePlanCommand()
                {
                    Parameter = planToRemove
                };
                var removedPlan = await this.commandExecutor.Execute(command);

                return new RemovePlanResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Plan>(removedPlan)
                };
            }
            else
            {
                return new RemovePlanResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }
    }
}
