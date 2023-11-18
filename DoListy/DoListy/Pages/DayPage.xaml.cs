using Appointment = DoListy.ViewModel.Appointment;
using ControlViewModel = DoListy.ControlViewModel;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;


namespace DoListy.Pages;
public partial class DayPage : ContentPage
{
    //Color for task inn frame A
    private Color transparentColor = Color.FromRgba(255, 255, 255, 0);
    private Color whiteColor = Color.FromRgb(255, 255, 255); // White color
    private Color blackColor = Color.FromRgb(0, 0, 0);
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
        TaskDailyStack.Clear();
        //List<Appointment> appointmentsForDate = new ObservableCollection<Appointment>(ControlViewModel.ControlViewModel.GetAppointments())
        //    .Where(app => app.EventStart.Date == currentDate.Date)
        //    .ToList();

        //foreach (Appointment app in appointmentsForDate)
        //{
        //    // Create labels for displaying appointment information
        //    Label nameLabel = new Label { Text = app.Name, TextColor = blackColor };
        //    Label dateLabel = new Label { Text = $"{app.EventStart:hh/mm,dd/mm/yy}-{app.EventEnd:hh/mm,dd/mm/yy}", TextColor = blackColor };

        //    // Create a StackLayout to hold labels
        //    StackLayout infoStack = new StackLayout();
        //    infoStack.Children.Add(nameLabel);
        //    infoStack.Children.Add(dateLabel);

        //    // Create a Frame to contain appointment information
        //    Frame appointmentFrame = new Frame { BackgroundColor = blackColor };
        //    appointmentFrame.Content = infoStack;

        //    // Create a transparent button
        //    Button transparentButton = new Button
        //    {
        //        BackgroundColor = blackColor,
        //        //Opacity = 0, // Set the opacity to 0 for it to be invisible
        //    };

        //    // Optional: Add a click event handler for the button
        //    transparentButton.Clicked += async (s, args) =>
        //    {
        //        // Call the method containing the common animation logic
        //        await AnimateFrames();
        //    };

        //    // Create a StackLayout to hold the frame and transparent button
        //    StackLayout frameWithButtonStack = new StackLayout();
        //    frameWithButtonStack.Children.Add(appointmentFrame);
        //    frameWithButtonStack.Children.Add(transparentButton);

        //    // Add the combined StackLayout to TaskDailyStack
        //    TaskDailyStack.Children.Add(frameWithButtonStack);
        //}

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

    private async Task AnimateFrames()
    {
        await frame_A.TranslateTo(-300, 0, 250, Easing.Linear);
        Grid.SetColumn(frame_A, 0);
        Grid.SetRow(frame_A, 1);

        // Scale back to original size (if there's relevant code for this)

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