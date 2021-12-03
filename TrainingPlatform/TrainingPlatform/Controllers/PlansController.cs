﻿using MediatR;
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
    [Route("[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlansController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPlans([FromQuery] GetPlansRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}