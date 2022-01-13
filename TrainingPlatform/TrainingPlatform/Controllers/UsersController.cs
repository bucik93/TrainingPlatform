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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator mediator;
        public UsersController(IMediator mediator) : base(mediator)
        {         
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            //var request = new GetUsersRequest();
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
        public Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, AddUserReValidateUserResponse>(request);
        }
    }
}
