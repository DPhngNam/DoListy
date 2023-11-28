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
		Humidity.Text = result.current.relative_humidity_2m.ToString();
		temperature.Text = result.current.temperature_2m.ToString() +"oC";
        wind.Text = result.current.wind_speed_10m.ToString();

		switch (result.current.weather_code)
		{
			//0
			default:
				weatherCode.Text = "clear sky";
				weatherImage.Source = "";
				break;

			case 1:
				weatherCode.Text = "Mainly clear";
				weatherImage.Source = "";
				break;
			case 2:
                weatherCode.Text = "Partly cloudy";
                weatherImage.Source = "";
                break;
			case 3:
                weatherCode.Text = "Overcast";
                weatherImage.Source = "";
                break;

			case 45:
                weatherCode.Text = "Fog";
                weatherImage.Source = "";
                break;
			case 48:
                weatherCode.Text = "Depositing rime fog";
                weatherImage.Source = "";
                break;

			case 51:
				break;
			case 53:
				break;
			case 55:
				break;
			case 56:
				break;
			case 57:
				break;

			case 61:

				break;

            case 63:

                break;
            case 65:

                break;


			case 66:
				break;
			case 67:
				break;

			case 71:
				break;
			case 73:
				break;
			case 75:
				break;

			case 77:
				break;
			case 80:
				break;

			case 81:
                break;

            case 82:
                break;

			case 85:
				break;
			case 86:
				break;
			
        }
    }
}