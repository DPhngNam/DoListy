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


}