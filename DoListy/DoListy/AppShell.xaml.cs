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
           
            if (App.appointmentRepo.GetSettings().mode)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;

                SetTabBarBackgroundColor(this, Color.FromArgb("#ff081b25"));
                SetTabBarForegroundColor(this, Colors.White);
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                SetTabBarBackgroundColor(this, Color.FromArgb("#ffcdf5fd"));
                SetTabBarForegroundColor(this, Colors.Black);
            }
        }
    }
}