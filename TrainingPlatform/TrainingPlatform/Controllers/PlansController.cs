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
    public class PlansController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlansController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPlans()
        {
            var request = new GetPlansRequest();
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("search-plan-with-exercises/{planName}")]
        public async Task<IActionResult> Search([FromRoute] string planName)
        {
            var request = new SearchPlanNameRequest() { Name = planName };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
  
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetPlanByIdRequest() { PlanId = id };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemovePlanRequest() { PlanId = id };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePlan([FromRoute] int id, [FromQuery] UpdatePlanRequest request)
        {
            request.PlanId = id;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddPlan([FromQuery] AddPlanRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("{planId}/{exerciseId}")]
        public async Task<IActionResult> AddExerciseToPlan([FromRoute] int planId, [FromRoute] int exerciseId)
        {
            var request = new AddExerciseToPlanRequest()
            {
                PlanId = planId,
                ExerciseId = exerciseId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}