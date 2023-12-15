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
            Routing.RegisterRoute(nameof(PomodoroPage), typeof(PomodoroPage));
            Routing.RegisterRoute(nameof(WeatherPage), typeof(WeatherPage));
            Routing.RegisterRoute(nameof(EditAppointmentPage), typeof(EditAppointmentPage));
            SetTabBarBackgroundColor(this, Color.FromArgb("#ffcdf5fd"));
            SetTabBarForegroundColor(this, Colors.White);
        }
    }
}