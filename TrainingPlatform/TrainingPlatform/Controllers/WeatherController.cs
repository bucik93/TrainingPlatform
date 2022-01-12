using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.Components.OpenWeather;

namespace TrainingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ApiControllerBase
    {
        private readonly IMediator mediator;
        public WeatherController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{city}")]
        public Task<IActionResult> GetWeatherByCity([FromRoute] string city)
        {
            var request = new GetWeatherRequest() { City = city };            
            return this.HandleRequest<GetWeatherRequest, GetWeatherResponse>(request);
        }

    }
}
