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
    public class GetPlanByIdHandler : IRequestHandler<GetPlanByIdRequest, GetPlanByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlanByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetPlanByIdResponse> Handle(GetPlanByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlanQuery() { Id = request.PlanId };
            var plan = await this.queryExecutor.Execute(query);
            if(plan==null)
            {
                return new GetPlanByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPlan = this.mapper.Map<Domain.Models.Plan>(plan);
            var response = new GetPlanByIdResponse() { Data = mappedPlan };
            return response;
        }
    }
}
