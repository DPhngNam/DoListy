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
		var result = await ApiService.getWeather(10.875, 106.625);
		Humidity.Text = result.current.relative_humidity_2m.ToString();
		temperature.Text = result.current.temperature_2m.ToString();
        wind.Text = result.current.wind_speed_10m.ToString();
    }
}