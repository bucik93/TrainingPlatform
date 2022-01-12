using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.Components.OpenWeather
{
    public interface IWeatherConnector
    {
        Task<Rootobject> Fetch(string city);
    }
}
