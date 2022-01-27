using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;

namespace TrainingPlatform.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator mediator;
        public UsersController(IMediator mediator) : base(mediator)
        {         
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/create-account-in-API")]
        public Task<IActionResult> AddUser([FromQuery] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUserRequest request)
        {
            return await this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Remove([FromRoute] int id)
        {
            var request = new RemoveUserRequest() { UserId = id };
            return this.HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdateUser([FromRoute] int id, [FromQuery] UpdateUserRequest request)
        {
            request.Id = id;
            return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }
    }
}
