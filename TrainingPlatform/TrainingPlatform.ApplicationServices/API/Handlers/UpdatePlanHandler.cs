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
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class UpdatePlanHandler : IRequestHandler<UpdatePlanRequest, UpdatePlanResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdatePlanHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<UpdatePlanResponse> Handle(UpdatePlanRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlanQuery()
            {
                Id = request.Id
            };

            var planToUpdate = await this.queryExecutor.Execute(query);

            if (planToUpdate != null)
            {
                planToUpdate = this.mapper.Map<DataAccess.Entities.Plan>(request);
                var command = new UpdatePlanCommand()
                {
                    Parameter = planToUpdate
                };

                var updatedPlan = await this.commandExecutor.Execute(command);

                return new UpdatePlanResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Plan>(updatedPlan)
                };
            }
            else
            {
                return null;
            }
        }
    }

}


