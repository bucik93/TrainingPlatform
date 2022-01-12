using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.Components.OpenWeather
{
    public class GetWeatherRequest : IRequest<GetWeatherResponse>
    {
        public string City { get; set; }

    }
}