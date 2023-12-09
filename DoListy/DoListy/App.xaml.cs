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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjgxOTEzMUAzMjMzMmUzMDJlMzBFdGVwOEhQTGxVdXZrMmxxYlNjUGZKM1NTSUNZYWNsam5DYTdVOHp2SXNRPQ==");
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
            double newWidth = 1300;
            double newHeight = 650;
           
            window.Width = newWidth;
            window.Height = newHeight;

            

            return window;
        }
        
    }
}