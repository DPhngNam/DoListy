using DoListy.Pages;
using DoListy.Weather;
namespace DoListy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddAppointmentPage), typeof(AddAppointmentPage));
            Routing.RegisterRoute(nameof(WeatherPage), typeof(WeatherPage));
            Routing.RegisterRoute(nameof(EditAppointmentPage), typeof(EditAppointmentPage));
            SetTabBarBackgroundColor(this, Color.FromHex("#081B25"));
            SetTabBarForegroundColor(this, Colors.White);
        }
    }
}