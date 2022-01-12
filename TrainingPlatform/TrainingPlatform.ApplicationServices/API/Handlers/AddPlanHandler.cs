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
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class AddPlanHandler : IRequestHandler<AddPlanRequest, AddPlanResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public AddPlanHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<AddPlanResponse> Handle(AddPlanRequest request, CancellationToken cancellationToken)
        {
            var plansQuery = new GetPlansQuery()
            {
                Name = request.Name
            };
            var getPlans = await this.queryExecutor.Execute(plansQuery);

            if(getPlans.Select(x=>x.Name).Contains(request.Name))
            {
                return new AddPlanResponse()
                {
                    Error = new ErrorModel("A plan with that name already exists in the database.")
                };
            }

            var plan = this.mapper.Map<DataAccess.Entities.Plan>(request);
            var command = new AddPlanCommand() { Parameter = plan };
            var planFromDb = await this.commandExecutor.Execute(command);
            return new AddPlanResponse()
            {
                Data = this.mapper.Map<Domain.Models.Plan>(planFromDb)
            };
        }
    }
}
