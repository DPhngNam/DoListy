using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherAppClone.Helpers;
using Newtonsoft.Json;

namespace DoListy.Services
{
    public class ApiService
    {
        public static  async Task<Root> getWeather(double latitude, double longtitude)
        {
            var httpClient =  new HttpClient();
            var response=await httpClient.GetStringAsync(string.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m&timezone=Asia%2FBangkok", latitude,longtitude) );

            return JsonConvert.DeserializeObject<Root>(response);  
        }

       
    }
}
