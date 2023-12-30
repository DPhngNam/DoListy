using DoListy.Database;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace DoListy
{
    public partial class App : Application
    {
        public static AppointmentRepository appointmentRepo { get; private set; }
        public App(AppointmentRepository AppRepo)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWGhIYVJxWmFZfVpgdVdMYF1bQHVPMyBoS35RdURhWHdcc3RQRmZcWUVy");
            Current.UserAppTheme = AppTheme.Light;

            InitializeComponent();
            appointmentRepo = AppRepo;  
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            MainPage = new AppShell();
            var window = base.CreateWindow(activationState);

            /*
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            double screenWidth = displayInfo.Width;
            double screenHeight = displayInfo.Height;
            */
            double newWidth = 1200;
            double newHeight = 650;
           
            window.Width = newWidth;
            window.Height = newHeight;
            window.MinimumHeight = newHeight * 0.9;
            window.MinimumWidth = newWidth * 0.9;
          

            return window;
        }
        
    }
}