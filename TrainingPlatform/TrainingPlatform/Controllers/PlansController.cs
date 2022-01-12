using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.DataAccess;
using TrainingPlatform.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public PlansController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllPlans()
        {
            var request = new GetPlansRequest();
            return this.HandleRequest<GetPlansRequest, GetPlansResponse>(request);
        }

        [HttpGet]
        [Route("search-plan-with-exercises/{planName}")]
        public Task<IActionResult> Search([FromRoute] string planName)
        {
            var request = new SearchPlanNameRequest() { Name = planName };
            return this.HandleRequest<SearchPlanNameRequest, SearchPlanNameResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetPlanByIdRequest() { PlanId = id };
            return this.HandleRequest<GetPlanByIdRequest, GetPlanByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemovePlanRequest() { PlanId = id };
            return this.HandleRequest<RemovePlanRequest, RemovePlanResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdatePlan([FromRoute] int id, [FromQuery] UpdatePlanRequest request)
        {
            request.PlanId = id;
            return this.HandleRequest<UpdatePlanRequest, UpdatePlanResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddPlan([FromQuery] AddPlanRequest request)
        {
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
            return this.HandleRequest<AddExerciseToPlanRequest, AddExerciseToPlanResponse>(request);
        }
    }
}