namespace DoListy
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc3NjI0MEAzMjMzMmUzMDJlMzBBdTlSZXUxUUNGNzZyYkU2RjhhUFdQUS9TODlTTTllTUxVdzBxRXAwdnVrPQ==");
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}