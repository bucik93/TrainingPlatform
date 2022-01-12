using AutoMapper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.Components.OpenWeather
{
    public class WeatherConnector : IWeatherConnector
    {
        private readonly RestClient restClient;
        private readonly string baseUrl = "https://api.openweathermap.org/";
        private readonly string apiKey = "e3cbb82c60e2bc0d1d512d42faa943b6";
        public WeatherConnector()
        {
            this.restClient = new RestClient(baseUrl);
        }
        public async Task<Rootobject> Fetch(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.Get);
            request.AddParameter("appid", this.apiKey);
            request.AddParameter("q", city);
            var queryResult = await restClient.ExecuteAsync(request);
            var weather = JsonConvert.DeserializeObject<Rootobject>(queryResult.Content);
            return weather;
        }
    }
}
