using CommunityToolkit.Maui.Views;

using System.Windows.Input;

namespace DoListy.Pages;

public partial class SettingPage : Popup
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync("https://learn.microsoft.com/dotnet/maui/"));
    public SettingPage()
	{
		InitializeComponent();
        
        this.BindingContext = new ViewModel.Settings();
    }

    private void SoundSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        bool isSwitchOn = e.Value;
    }


    private void Darkmode_Toggled(Object sender, ToggledEventArgs e)
    {
        bool isDarkMode = e.Value;
        if (isDarkMode)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
            
            Shell.SetTabBarBackgroundColor(Shell.Current, Color.FromArgb("#ff081b25"));
            Shell.SetTabBarForegroundColor(Shell.Current, Colors.White);
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            Shell.SetTabBarBackgroundColor(Shell.Current, Color.FromArgb("#ffcdf5fd"));
            Shell.SetTabBarForegroundColor(Shell.Current, Colors.Black);
        }

    }
    
}