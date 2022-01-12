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
using TrainingPlatform.DataAccess;
using TrainingPlatform.DataAccess.CQRS;
using TrainingPlatform.DataAccess.CQRS.Queries;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class GetPlansHandler : IRequestHandler<GetPlansRequest, GetPlansResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlansHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetPlansResponse> Handle(GetPlansRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlansQuery();
            var plans = await this.queryExecutor.Execute(query);
            if (plans == null)
            {
                return new GetPlansResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPlan = this.mapper.Map<List<Domain.Models.Plan>>(plans);
            var response = new GetPlansResponse() { Data = mappedPlan };
            return response;
        }
    }
}
