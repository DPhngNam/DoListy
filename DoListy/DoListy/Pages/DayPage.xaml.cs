namespace DoListy.Pages;
using Appointment = DoListy.ViewModel.Appointment;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Scheduler;
public partial class DayPage : ContentPage
{
   
    public DayPage()
    {
        InitializeComponent();
        SetIniDisplayDate();
        
    }

    private void SetIniDisplayDate()
    {
        DateTime today = DateTime.Today;
        int delta = DayOfWeek.Monday - today.DayOfWeek; // Calculate the offset to Monday
        if (delta > 0)
            delta -= 7; // Adjust if today is later in the week than Monday

        mon.DisplayDate = today.AddDays(delta);
        tue.DisplayDate = today.AddDays(delta + 1);
        wed.DisplayDate = today.AddDays(delta + 2);
        thus.DisplayDate = today.AddDays(delta + 3);
        fri.DisplayDate = today.AddDays(delta + 4);
        sat.DisplayDate = today.AddDays(delta + 5);
        sun.DisplayDate = today.AddDays(delta + 6);

    }


    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddAppointmentPage());
    }

    
    private void LeftimaBut_Clicked(object sender, EventArgs e)
    {
        mon.DisplayDate = mon.DisplayDate.AddDays(-7);
        tue.DisplayDate = tue.DisplayDate.AddDays(-7);
        wed.DisplayDate = wed.DisplayDate.AddDays(-7);
        thus.DisplayDate = thus.DisplayDate.AddDays(-7);
        fri.DisplayDate = fri.DisplayDate.AddDays(-7);
        sat.DisplayDate = sat.DisplayDate.AddDays(-7);
        sun.DisplayDate = sun.DisplayDate.AddDays(-7);
    }

    private void RightimaBut_Clicked(object sender, EventArgs e)
    {
        mon.DisplayDate = mon.DisplayDate.AddDays(7);
        tue.DisplayDate = tue.DisplayDate.AddDays(7);
        wed.DisplayDate = wed.DisplayDate.AddDays(7);
        thus.DisplayDate = thus.DisplayDate.AddDays(7);
        fri.DisplayDate = fri.DisplayDate.AddDays(7);
        sat.DisplayDate = sat.DisplayDate.AddDays(7);
        sun.DisplayDate = sun.DisplayDate.AddDays(7);
    }

    private void AlwaysOnDisplay(DateTime currentDate)
    {
        
    }

    

  

    private void Butmon_Clicked(object sender, EventArgs e)
    {
        RefreshCurrentFrame();
        AlwaysOnDisplay(mon.DisplayDate);
        
    }

    private void Buttue_Clicked(object sender, EventArgs e)
    {
        RefreshCurrentFrame();
        AlwaysOnDisplay(tue.DisplayDate);

    }

    private void Butwed_Clicked(object sender, EventArgs e)
    {

        RefreshCurrentFrame();

        AlwaysOnDisplay(wed.DisplayDate);

    }

    private void Butthus_Clicked(object sender, EventArgs e)
    {
        RefreshCurrentFrame();
        AlwaysOnDisplay(thus.DisplayDate);

    }

    private void Butfri_Clicked(object sender, EventArgs e)
    {
        RefreshCurrentFrame();
        AlwaysOnDisplay(fri.DisplayDate);

    }

    private void Butsat_Clicked(object sender, EventArgs e)
    {   
        RefreshCurrentFrame();
        AlwaysOnDisplay(sat.DisplayDate);

    }

    private void Butsun_Clicked(object sender, EventArgs e)
    {
        RefreshCurrentFrame();
        AlwaysOnDisplay(sun.DisplayDate);

    }

    private async void NewButton_Clicked(object sender, EventArgs e)
    {
        await frame_A.TranslateTo(-300, 0, 250, Easing.Linear);
        Grid.SetColumn(frame_A, 0);
        Grid.SetRow(frame_A, 1);
        // Scale back to original size

        // Animate the visibility change for frame_B
        frame_B.IsVisible = true;
        await frame_B.FadeTo(1, 500, Easing.SinInOut); // Fade in


    }

    //Reset position
    private async void RefreshCurrentFrame()
    {
        // Move frame_A back to its original position
        await frame_A.TranslateTo(0, 0, 250, Easing.Linear);
        Grid.SetColumn(frame_A, 0);
        Grid.SetRow(frame_A, 0);

        // Reverse the visibility change for frame_B
        await frame_B.FadeTo(0, 500, Easing.SinInOut); // Fade out
        frame_B.IsVisible = false;

    }
}