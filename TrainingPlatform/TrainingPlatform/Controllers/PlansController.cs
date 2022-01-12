using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.DataAccess;
using TrainingPlatform.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TrainingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<PlansController> logger;
        public PlansController(IMediator mediator, ILogger<PlansController> logger) : base(mediator)
        {
            this.logger = logger;
            logger.LogInformation("We are in PlanController.");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllPlans()
        {
            var request = new GetPlansRequest();
            logger.LogInformation("Get All Plans.");
            return this.HandleRequest<GetPlansRequest, GetPlansResponse>(request);
        }

        [HttpGet]
        [Route("search-plan-with-exercises/{planName}")]
        public Task<IActionResult> Search([FromRoute] string planName)
        {
            var request = new SearchPlanNameRequest() { Name = planName };
            logger.LogInformation($"Search plans by PlanName: {planName}.");
            return this.HandleRequest<SearchPlanNameRequest, SearchPlanNameResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetPlanByIdRequest() { PlanId = id };
            logger.LogInformation($"Get plan by Id: {id}.");
            return this.HandleRequest<GetPlanByIdRequest, GetPlanByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemovePlanRequest() { PlanId = id };
            logger.LogInformation($"Remove plan by Id: {id}.");
            return this.HandleRequest<RemovePlanRequest, RemovePlanResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdatePlan([FromRoute] int id, [FromQuery] UpdatePlanRequest request)
        {
            request.PlanId = id;
            logger.LogInformation($"Update plan by Id: {id}.");
            return this.HandleRequest<UpdatePlanRequest, UpdatePlanResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddPlan([FromQuery] AddPlanRequest request)
        {
            logger.LogInformation($"Add plan to database.");
            return this.HandleRequest<AddPlanRequest, AddPlanResponse>(request);
        }

        [HttpPost]
        [Route("{planId}/{exerciseId}")]
        public Task<IActionResult> AddExerciseToPlan([FromRoute] int planId, [FromRoute] int exerciseId)
        {
            var request = new AddExerciseToPlanRequest()
            {
                PlanId = planId,
                ExerciseId = exerciseId
            };
            logger.LogInformation($"Add exerciseId: {exerciseId} and planId: {planId} to table ExercisePlans.");
            return this.HandleRequest<AddExerciseToPlanRequest, AddExerciseToPlanResponse>(request);
        }
    }
}