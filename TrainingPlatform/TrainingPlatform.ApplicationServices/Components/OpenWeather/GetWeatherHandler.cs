using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.Components.OpenWeather
{
    public class GetWeatherHandler : IRequestHandler<GetWeatherRequest, GetWeatherResponse>
    {
        private readonly IMapper mapper;
        private readonly IWeatherConnector weatherConnector;

        public GetWeatherHandler(IMapper mapper, IWeatherConnector weatherConnector)
        {
            this.mapper = mapper;
            this.weatherConnector = weatherConnector;
        }
     
        public async Task<GetWeatherResponse> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
        {
            var weather = await this.weatherConnector.Fetch(request.City);
            var response = new GetWeatherResponse()
            {
                Data = weather
            };
            return response;
        }
    }
}
