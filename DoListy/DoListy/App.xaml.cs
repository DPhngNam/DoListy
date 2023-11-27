using DoListy.Database;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace DoListy
{
    public partial class App : Application
    {
        public static AppointmentRepository AppointmentRepo { get; private set; }
        public App(AppointmentRepository AppRepo)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjgxOTEzMUAzMjMzMmUzMDJlMzBFdGVwOEhQTGxVdXZrMmxxYlNjUGZKM1NTSUNZYWNsam5DYTdVOHp2SXNRPQ==");
            InitializeComponent();
            AppointmentRepo = AppRepo;  
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
            double newWidth = 1100;
            double newHeight = 600;
           
            window.Width = newWidth;
            window.Height = newHeight;

            

            return window;
        }
    }
}