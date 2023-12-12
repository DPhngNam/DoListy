using Plugin.Maui.Audio;
using System.Collections.ObjectModel;
using DoListy.Services;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.Weather;
using System.Xml;
using Syncfusion.Maui.Scheduler;
using System.Diagnostics;

namespace DoListy.Pages;
public partial class DayPage : ContentPage
{
    private readonly IAudioManager audioManager;


    //set the setting task's day is Now (for tempo)            
    private DateTime temp = DateTime.Now;

    public DayPage(IAudioManager audioManager)
    {

        InitializeComponent();
        SetIniDisplayDate();
        TaskDaily.ItemsSource = null;
        this.audioManager = audioManager;
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

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is int appId)
        {
            Appointment temp = App.appointmentRepo.GetAppointmentByID(appId);
            if (temp != null)
            {
                temp.IsDone = !temp.IsDone;
                checkBox.IsChecked = temp.IsDone;
                App.appointmentRepo.Update(temp);
                var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("tick.mp3"));
                player.Play();
                return;
            }
        }
    }


    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddAppointmentPage));
        var add = (AddAppointmentPage)Shell.Current.CurrentPage;
        add.entryStartTime.Text = temp.ToString();
        add.pickerDateTime1.SelectedDate = temp;

        add.Disappearing += OnAddAppointmentPageDisappearing;
    }
    private void OnAddAppointmentPageDisappearing(object sender, EventArgs e)
    {
        RefreshCurrentFrame();

    }
    private async Task AnimateFrames()
    {

        frame_A.WidthRequest = 350;
        await frame_A.TranslateTo(-220, 0, 250, Easing.Linear);
        Grid.SetColumn(frame_A, 0);
        Grid.SetRow(frame_A, 1);

        frame_B.IsVisible = true;

        await frame_B.FadeTo(1, 500, Easing.SinInOut); // Fade in

    }

    //Reset position
    private async void RefreshCurrentFrame()
    {
        // Reverse the visibility change for frame_B
        await frame_B.FadeTo(0, 500, Easing.SinInOut); // Fade out
        frame_B.IsVisible = false;
        // Move frame_A back to its original position
        frame_A.WidthRequest = 700;
        await frame_A.TranslateTo(0, 0, 250, Easing.Linear);
        Grid.SetColumn(frame_A, 0);
        Grid.SetRow(frame_A, 1);

    }


    public void loadAppointments()
    {
        List<Appointment> appointments = App.appointmentRepo.GetAppointments();
        var AppointmentEvents = new ObservableCollection<Appointment>(appointments);
        mon.AppointmentsSource = AppointmentEvents;
        tue.AppointmentsSource = AppointmentEvents;
        wed.AppointmentsSource = AppointmentEvents;
        thus.AppointmentsSource = AppointmentEvents;
        fri.AppointmentsSource = AppointmentEvents;
        sat.AppointmentsSource = AppointmentEvents;
        sun.AppointmentsSource = AppointmentEvents;
    }
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointment)
        {
            App.appointmentRepo.DeleteAppointment(appointment);
            loadAppointments();
            TaskDaily.ItemsSource = null;
        }
    }

    private void Scheduler_Tapped(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        loadAppointments();
        if (e.Element is SchedulerElement.ViewHeader)
        {
            TaskDaily.ItemsSource = null;
            //if (e.Appointments == null)
            //    return;
            //Tasklist.ItemsSource = e.Appointments;
            //loadAppointments();

            var CurrentAppointment = new ObservableCollection<Appointment>(App.appointmentRepo.GetAppointments());
            List<Appointment> appointmennts = new List<Appointment>();

            foreach (Appointment app in CurrentAppointment)
            {
                if (app.EventStart.Day <= e.Date.Value.Day && e.Date.Value.Day <= app.EventEnd.Day)
                {
                    appointmennts.Add(app);
                }
            }
            TaskDaily.ItemsSource = appointmennts;
            loadAppointments();
        }   
    }


    private async void TasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        if (TaskDaily.SelectedItem != null)
        {
            int temp = ((Appointment)e.SelectedItem).Id;
            await Shell.Current.GoToAsync($"{nameof(EditAppointmentPage)}?AppId={((Appointment)TaskDaily.SelectedItem).Id}");
            TaskDaily.ItemsSource = null;
        }
    }
    private void TasksList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        TaskDaily.SelectedItem = null;
    }

    //Weather
    private string s = "";
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
        var result = await ApiService.getWeather(10.823, 106.6296);


        switch (result.current.weather_code)
        {
            //0
            default:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/smiling-sun.png";

                }
                else
                {
                    s = "https://img.icons8.com/fluency/96/bright-moon.png";
                }

                break;

            case 1:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/color/96/sun--v1.png";

                }
                else
                {
                    s = "https://img.icons8.com/color/96/night.png";
                }
                break;
            case 2:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/partly-cloudy-day.png";

                }
                else
                {
                    s = "https://img.icons8.com/fluency/96/partly-cloudy-night.png";
                }
                break;
            case 3:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/color/96/partly-cloudy-day--v1.png";

                }
                else
                {
                    s = "https://img.icons8.com/fluency/96/partly-cloudy-night.png";
                }
                break;

            case 45:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/fog-day.png";

                }
                else
                {
                    s = "https://img.icons8.com/fluency/96/fog-night.png";
                }
                break;
            case 48:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/fog-day.png";

                }
                else
                {
                    s = "https://img.icons8.com/fluency/96/fog-night.png";
                }
                break;




            case 61:


                s = "https://img.icons8.com/fluency/96/light-rain.png";


                break;

            case 63:

                s = "https://img.icons8.com/fluency/96/moderate-rain.png";
                break;
            case 65:

                s = "https://img.icons8.com/fluency/96/intense-rain.png";
                break;





            case 80:


                s = "https://img.icons8.com/fluency/96/light-rain.png";


                break;

            case 81:

                s = "https://img.icons8.com/fluency/96/moderate-rain.png";
                break;

            case 82:

                s = "https://img.icons8.com/fluency/96/intense-rain.png";
                break;



            case 95:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/chance-of-storm.png";
                }
                else
                {
                    s = "https://img.icons8.com/plasticine/100/stormy-night.png";
                }
                break;

            case 96:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/chance-of-storm.png";
                }
                else
                {
                    s = "https://img.icons8.com/plasticine/100/stormy-night.png";
                }
                break;
            case 99:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/chance-of-storm.png";
                }
                else
                {
                    s = "https://img.icons8.com/plasticine/100/stormy-night.png";
                }
                break;

        }
        weatherImage.Source = s;

    }

    private async void weatherImage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WeatherPage));

    }
}