using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace DoListy
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc3NjI0MEAzMjMzMmUzMDJlMzBBdTlSZXUxUUNGNzZyYkU2RjhhUFdQUS9TODlTTTllTUxVdzBxRXAwdnVrPQ==");
            InitializeComponent();

            
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