using CommunityToolkit.Maui.Views;
using System.Collections.Generic;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
namespace DoListy.Pages;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		Feedback fb = new Feedback();
        this.ShowPopup(fb);
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