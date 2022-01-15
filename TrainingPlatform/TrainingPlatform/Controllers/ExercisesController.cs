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
    [Route("api/exercises")]
    public class ExercisesController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ExercisesController> logger;

        public ExercisesController(IMediator mediator, ILogger<ExercisesController> logger) : base(mediator)
        {
            this.logger = logger;
            logger.LogInformation("We are in ExerciseController.");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllExercises([FromQuery] GetExercisesRequest request)
        {
            logger.LogInformation("Get All Exercises.");
            return this.HandleRequest<GetExercisesRequest, GetExercisesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddExercise([FromQuery] AddExerciseRequest request)
        {
            logger.LogInformation($"Add exercise {request.Name} to database.");
            return this.HandleRequest<AddExerciseRequest, AddExerciseResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetExerciseByIdRequest() { ExerciseId = id };
            logger.LogInformation($"Get exercise by Id: {id}.");
            return this.HandleRequest<GetExerciseByIdRequest, GetExerciseByIdResponse>(request);
        }
        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemoveExerciseRequest() { ExerciseId = id };
            logger.LogInformation($"Remove exercise by Id: {id}.");
            return this.HandleRequest<RemoveExerciseRequest, RemoveExerciseResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdateExercise([FromRoute] int id, [FromQuery] UpdateExerciseRequest request)
        {
            request.ExerciseId = id;
            logger.LogInformation($"Update exercise by Id: {id}.");
            return this.HandleRequest<UpdateExerciseRequest, UpdateExerciseResponse>(request);
        }
    }
}
