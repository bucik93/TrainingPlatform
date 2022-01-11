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
    public class ExercisesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExercisesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllExercises([FromQuery] GetExercisesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddExercise([FromQuery] AddExerciseRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetExerciseByIdRequest() { ExerciseId = id };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemoveExerciseRequest() { ExerciseId = id };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] int id, [FromQuery] UpdateExerciseRequest request)
        {
            request.ExerciseId = id;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
