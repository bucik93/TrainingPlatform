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
    public class ExercisesController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public ExercisesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllExercises([FromQuery] GetExercisesRequest request)
        {
            return this.HandleRequest<GetExercisesRequest, GetExercisesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddExercise([FromQuery] AddExerciseRequest request)
        {
            return this.HandleRequest<AddExerciseRequest, AddExerciseResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetExerciseByIdRequest() { ExerciseId = id };
            return this.HandleRequest<GetExerciseByIdRequest, GetExerciseByIdResponse>(request);
        }
        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemoveExerciseRequest() { ExerciseId = id };
            return this.HandleRequest<RemoveExerciseRequest, RemoveExerciseResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdateExercise([FromRoute] int id, [FromQuery] UpdateExerciseRequest request)
        {
            request.ExerciseId = id;
            return this.HandleRequest<UpdateExerciseRequest, UpdateExerciseResponse>(request);
        }
    }
}
