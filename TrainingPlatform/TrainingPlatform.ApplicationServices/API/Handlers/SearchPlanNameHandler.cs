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
    public class SearchPlanNameHandler : IRequestHandler<SearchPlanNameRequest, SearchPlanNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public SearchPlanNameHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<SearchPlanNameResponse> Handle(SearchPlanNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlansQuery() { Name = request.Name };
            var plans = await this.queryExecutor.Execute(query);
            var mappedPlan = this.mapper.Map<List<Domain.Models.Plan>>(plans);
            var response = new SearchPlanNameResponse() { Data = mappedPlan };
            return response;
        }
    }
}
