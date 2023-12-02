using DoListy.Services;

namespace DoListy.Weather;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var result = await ApiService.getWeather(10.823, 106.6296);
        drop.Source = "drop.png";

        Humidity.Text = result.current.relative_humidity_2m.ToString();
		temperature.Text = result.current.temperature_2m.ToString() + "oC";
		wind.Text = result.current.wind_speed_10m.ToString();

        switch (result.current.weather_code)
		{
			//0
			default:
				weatherCode.Text = "clear sky";
				if(result.current.is_day == 1)
				{
                    weatherImage.Source = "https://img.icons8.com/fluency/96/smiling-sun.png";

				}
				else
				{
                    weatherImage.Source = "https://img.icons8.com/fluency/96/bright-moon.png";
                }

                break;

			case 1:
				weatherCode.Text = "Mainly clear";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/color/96/sun--v1.png";

                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/color/96/night.png";
                }
                break;
			case 2:
                weatherCode.Text = "Partly cloudy";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/partly-cloudy-day.png";

                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/partly-cloudy-night.png";
                }
                break;
			case 3:
                weatherCode.Text = "Overcast";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/color/96/partly-cloudy-day--v1.png";

                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/partly-cloudy-night.png";
                }
                break;

			case 45:
                weatherCode.Text = "Fog";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/fog-day.png";

                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/fog-night.png";
                }
                break;
			case 48:
                weatherCode.Text = "Depositing rime fog";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/fog-day.png";

                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/fog-night.png";
                }
                break;
                

			

			case 61:
                weatherCode.Text = "Slight rain";
                
                weatherImage.Source = "https://img.icons8.com/fluency/96/light-rain.png";

                
                break;

            case 63:
                weatherCode.Text = "Moderate rain";
                weatherImage.Source = "https://img.icons8.com/fluency/96/moderate-rain.png";
                break;
            case 65:
                weatherCode.Text = "Heavy rain";
                weatherImage.Source = "https://img.icons8.com/fluency/96/intense-rain.png";
                break;


			

			
			case 80:
                weatherCode.Text = "Slight rain showers";

                weatherImage.Source = "https://img.icons8.com/fluency/96/light-rain.png";


                break;

            case 81:
                weatherCode.Text = "Moderate rain showers";
                weatherImage.Source = "https://img.icons8.com/fluency/96/moderate-rain.png";
                break;

            case 82:
                weatherCode.Text = "Heavy rain showers";
                weatherImage.Source = "https://img.icons8.com/fluency/96/intense-rain.png";
                break;



            case 95:
                weatherCode.Text = "Slight Thunderstorm";
                if(result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/chance-of-storm.png";
                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/plasticine/100/stormy-night.png";
                }
                break;

            case 96:
                weatherCode.Text = "Moderate Thunderstorm";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/chance-of-storm.png";
                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/plasticine/100/stormy-night.png";
                }
                break;
            case 99:
                weatherCode.Text = "Heavy Thunderstorm";
                if (result.current.is_day == 1)
                {
                    weatherImage.Source = "https://img.icons8.com/fluency/96/chance-of-storm.png";
                }
                else
                {
                    weatherImage.Source = "https://img.icons8.com/plasticine/100/stormy-night.png";
                }
                break;

        }
	}
}