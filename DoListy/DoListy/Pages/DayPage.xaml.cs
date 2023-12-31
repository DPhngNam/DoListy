using Plugin.Maui.Audio;
using System.Collections.ObjectModel;
using DoListy.Services;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.Weather;
using Syncfusion.Maui.Scheduler;
using DoListy.ViewModel;
using CommunityToolkit.Maui.Views;
using XCalendar.Core.Extensions;

namespace DoListy.Pages;
public partial class DayPage : ContentPage
{
    private readonly IAudioManager audioManager;
    private void TasksList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        TaskDaily.SelectedItem = null;
    }
    private void Pomodoro_Pressed(object sender, EventArgs e)
    {
        Pomodoro.Opacity = 0.5;
    }
    private void weatherImage_Pressed(object sender, EventArgs e)
    {
        weatherImage.Opacity = 0.5;
    }
    private void buttonAddAppointment_Pressed(object sender, EventArgs e)
    {
        buttonAddAppointment.Opacity = 0.5;
    }
    private void Settingbtn_Clicked(object sender, EventArgs e)
    {
        Settingbtn.Opacity = 1.0;
        Mediaelement2.Play();
        SettingPage st = new SettingPage();
        this.ShowPopup(st);
    }
    private void Settingbtn_Pressed(object sender, EventArgs e)
    {
        Settingbtn.Opacity = 0.5;
    }
    private void Pomodoro_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        Pomodoro.Opacity = 1.0;
        Navigation.PushModalAsync(new PomodoroPage(audioManager));
    }
    //set the setting task's day is Now (for tempo)            
    public  DateTime temp = DateTime.Now;
    public void loadAppointments()
    {
        List<Appointment> appointments = App.appointmentRepo.GetAppointments();
        var AppointmentEvents = new ObservableCollection<Appointment>(appointments);
        DayPageScheduler.AppointmentsSource = AppointmentEvents;
    }
    public DayPage(IAudioManager audioManager)
    {
        InitializeComponent();
        
        this.audioManager = audioManager;
        frame_A.FindByName<Label>("whatDay").Text = temp.ToString(" dddd dd/MM/yyyy ");
        loadAppointments();
        Load(temp);
    }

    //Weather
    private string s = "";
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
        Load(DateTime.Now);
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
                    s = "https://img.icons8.com/fluency/96/partly-cloudy-night.png";
                }
                break;
            case 2:

                if (result.current.is_day == 1)
                {
                    s = "https://img.icons8.com/fluency/96/partly-cloudy-day.png";
                    //s = "nighttt.png";
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
        weatherImage.Opacity = 1.0;
        await Navigation.PushModalAsync(new WeatherPage());
    }
    //Weather

    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        buttonAddAppointment.Opacity = 1.0;
        await Shell.Current.GoToAsync(nameof(AddAppointmentPage));
    }
    private DateTime xxx;
    private List<Appointment> appointmenntss = new List<Appointment>();
    public void Load(DateTime current)
    {
        var CurrentAppointment = new ObservableCollection<Appointment>(App.appointmentRepo.GetAppointments());
        List<Appointment> appointmennts = new List<Appointment>();
        foreach (Appointment app in CurrentAppointment)
        {
            if (app.EventStart.Day <= current.Day && current.Day <= app.EventEnd.Day)
            {
                appointmennts.Add(app);
            }
        }
        
        TaskDaily.ItemsSource = appointmennts;
        
    }

   

    private  void Scheduler_Tapped(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        TaskDaily.ItemsSource = null;
        Mediaelement2.Play();
        loadAppointments();
        
        if (e.Element is SchedulerElement.ViewHeader)
        {
            xxx = e.Date.Value;            
            whatDay.Text = xxx.ToString("dddd dd/MM/yyyy");            
            Load(xxx);
            frame_B.FindByName<Label>("TaskTitle").Text = "";
            frame_B.FindByName<Label>("StartTime").Text = "";
            frame_B.FindByName<Label>("EndTime").Text = "";
            frame_B.FindByName<Label>("State").Text = "";            
            frame_B.FindByName<Editor>("Notes").Text = "";
        }
    }

    private Appointment Current;
    int tempo;
    private void TasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        if (TaskDaily.SelectedItem != null)
        {
            tempo = ((Appointment)e.SelectedItem).Id;
            Current = App.appointmentRepo.GetAppointmentByID(tempo);

            frame_B.FindByName<Label>("TaskTitle").Text = Current.Name;
            frame_B.FindByName<Label>("StartTime").Text = Current.EventStart.ToString();
            frame_B.FindByName<Label>("EndTime").Text = Current.EventEnd.ToString();

            if (!Current.IsDone)
            {
                frame_B.FindByName<Label>("State").Text = "Working on it";
            } 
            else
            {
                frame_B.FindByName<Label>("State").Text = "Done";
            }

            frame_B.FindByName<Editor>("Notes").Text = Current.Note;
        }

    }
   

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        if (sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointmentt)
        {
            if(tempo == appointmentt.Id)
            {
                
                    frame_B.FindByName<Label>("TaskTitle").Text = "";
                    frame_B.FindByName<Label>("StartTime").Text = "";
                    frame_B.FindByName<Label>("EndTime").Text = "";
                    frame_B.FindByName<Label>("State").Text = "";
                    frame_B.FindByName<Editor>("Notes").Text = "";
                
            }
            App.appointmentRepo.DeleteAppointment(appointmentt);
            TaskDaily.ItemsSource = null;
            Load(appointmentt.EventStart.Date);
            loadAppointments();
            Load(xxx);   
            
        }
    }
    
   

    

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox != null)
        {
            if (checkbox.IsChecked)
            {
                var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("tick.mp3"));
                player.Play();

                if (!Current.IsDone && Current != null)
                {
                    frame_B.FindByName<Label>("State").Text = "Done";
                }
            }
        }
    }

    private async void MenuItem_Clicked_1(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        if(sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointmenttt)
        {
            int temp = appointmenttt.Id;
            await Shell.Current.GoToAsync($"{nameof(EditAppointmentPage)}?AppId={appointmenttt.Id}");
            TaskDaily.ItemsSource = null;
        }
    }
}