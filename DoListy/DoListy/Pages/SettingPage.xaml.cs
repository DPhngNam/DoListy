using CommunityToolkit.Maui.Views;
using DoListy.ViewModel;
using System.Windows.Input;

namespace DoListy.Pages;

public partial class SettingPage : Popup
{
    
    public SettingPage()
	{
		InitializeComponent();
        linkwebsite.Command = new Command<string>(async (url) => await Launcher.OpenAsync("https://dttri.github.io/dolisty.github.io/?fbclid=IwAR2e2SJ9--e3iGSiCyrspXVBnzRs8_rRxB6sipfgb5PDj8lGl2ln6ozHzgM"));
        this.BindingContext = new ViewModel.Settings();
    }


    


    private void Darkmode_Toggled(Object sender, ToggledEventArgs e)
    {
        Settings temp = App.appointmentRepo.GetSettings();
        temp.Mode = e.Value;
        App.appointmentRepo.UpdateSettings(temp);
        bool isDarkMode = temp.mode;
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
    /*
    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        Settings temp = App.appointmentRepo.GetSettings();
        temp.Remind = e.Value;
        App.appointmentRepo.UpdateSettings(temp);
    }
    private void SoundSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Settings temp = App.appointmentRepo.GetSettings();
        temp.Sound = e.Value;
        App.appointmentRepo.UpdateSettings(temp);
    }
    */
}