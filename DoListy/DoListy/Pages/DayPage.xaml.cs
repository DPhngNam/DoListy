using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;

namespace DoListy.Pages;
public partial class DayPage : ContentPage
{
    //Color for task inn frame A
    private Color transparentColor = Color.FromRgba(255, 255, 255, 0);
    private Color blackColor = Color.FromRgb(0, 0, 0);

    //set the setting task's day is Now (for tempo)
    private DateTime temp = DateTime.Now;

    public DayPage()
    {
        InitializeComponent();
        AlwaysOnDisplay(DateTime.Now);
        SetIniDisplayDate();
    }

    private void SetIniDisplayDate()
    {
        DateTime today = DateTime.Today;
        int delta = DayOfWeek.Monday - today.DayOfWeek; // Calculate the offset to Monday

        if (delta > 0)
            delta -= 7; // Adjust if today is later in the week than Monday

        // Adjust the condition to handle Monday separately
        if (delta == 0)
        {
            mon.DisplayDate = today;
        }
        else
        {
            mon.DisplayDate = today.AddDays(delta);
        }

        tue.DisplayDate = mon.DisplayDate.AddDays(1);
        wed.DisplayDate = mon.DisplayDate.AddDays(2);
        thus.DisplayDate = mon.DisplayDate.AddDays(3);
        fri.DisplayDate = mon.DisplayDate.AddDays(4);
        sat.DisplayDate = mon.DisplayDate.AddDays(5);
        sun.DisplayDate = mon.DisplayDate.AddDays(6);
    }

    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        var result = await Application.Current.MainPage.DisplayAlert("Alert", $"Do you really want to add more tasks on {temp:dd/MM/yyyy}?", "No", "Yes");

        if (!result)
        {
            var addAppointmentPage = new AddAppointmentPage();
            await Navigation.PushModalAsync(addAppointmentPage);
            var add = (AddAppointmentPage)Shell.Current.CurrentPage;
            add.entryEndTime.Text = temp.ToString("F");
            add.pickerDateTime2.SelectedDate = temp;
            // Handle the closing event of the AddAppointmentPage
            addAppointmentPage.Disappearing += OnAddAppointmentPageDisappearing;
        }

    }
    private void OnAddAppointmentPageDisappearing(object sender, EventArgs e)
    {
        RefreshCurrentFrame();
        AlwaysOnDisplay(temp);
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
        List<Appointment> appointmentsForDate = new ObservableCollection<Appointment>(ControlViewModel.ControlViewModel.GetAppointments())
            .Where(app => app.EventStart.Date == currentDate.Date)
            .ToList();

        foreach (Appointment app in appointmentsForDate)
        {
            // Create labels for displaying appointment information
            Label nameLabel = new Label { Text = app.Name, TextColor = blackColor };
            Label dateLabel = new Label { Text = $"{app.EventStart:hh/mm,dd/mm/yy}-{app.EventEnd:hh/mm,dd/mm/yy}", TextColor = blackColor };

            // Create a StackLayout to hold labels
            StackLayout infoStack = new StackLayout();
            infoStack.Children.Add(nameLabel);
            infoStack.Children.Add(dateLabel);

            // Create a Frame to contain appointment information
            Frame appointmentFrame = new Frame
            {
                BackgroundColor = transparentColor,
                Content = infoStack
            };

            // Add TapGestureRecognizer to the appointmentFrame
            appointmentFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    // Call the method containing the common animation logic
                    await AnimateFrames();
                })
            });

            // Create a StackLayout to hold the frame
            StackLayout frameStack = new StackLayout();
            frameStack.Children.Add(appointmentFrame);


            // Add the combined StackLayout to TaskDailyStack
            TaskDailyStack.Children.Add(frameStack);
        }

    }
    private void Butmon_Clicked(object sender, EventArgs e)
    {
        temp = this.mon.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(mon.DisplayDate);

    }

    private void Buttue_Clicked(object sender, EventArgs e)
    {
        temp = this.tue.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(tue.DisplayDate);
    }

    private void Butwed_Clicked(object sender, EventArgs e)
    {
        temp = this.wed.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(wed.DisplayDate);
    }

    private void Butthus_Clicked(object sender, EventArgs e)
    {
        temp = this.thus.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(thus.DisplayDate);

    }

    private void Butfri_Clicked(object sender, EventArgs e)
    {
        temp = this.fri.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(fri.DisplayDate);

    }

    private void Butsat_Clicked(object sender, EventArgs e)
    {
        temp = this.sat.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(sat.DisplayDate);

    }

    private void Butsun_Clicked(object sender, EventArgs e)
    {
        temp = this.sun.DisplayDate;
        RefreshCurrentFrame();
        AlwaysOnDisplay(sun.DisplayDate);

    }
}