using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;

using Syncfusion.Maui.Scheduler;
using System.Runtime.CompilerServices;
using Plugin.Maui.Audio;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using MetroLog;
using Microsoft.Extensions.Logging;
//using AndroidX.Core.View.Accessibility;
//using Foundation;

namespace DoListy.Pages;


public partial class WeekPage : ContentPage
{
    private readonly IAudioManager audioManager;
    ILogger<WeekPage> _logger;
    bool isToggled = App.appointmentRepo.GetSettings().Sound;
    public async void IntitializeSound()
    {
        if(!isToggled)
        {
             Clicked_Sound.Volume = 0;
             CheckBox_Sound.Volume = 0;
        }
        else
        {
            Clicked_Sound.Volume = 1;
            CheckBox_Sound.Volume = 1;
        }

    }

    public WeekPage(IAudioManager audioManager,ILogger<WeekPage> logger)
    {
        InitializeComponent();
        TimeRulerTextStyle();
      
        _logger = logger;
        this.audioManager= audioManager;
        
    }
    public SchedulerAppointmentMapping schedulerAppointmentMapping { get; set; }
    private void TimeRulerTextStyle()
    {
        var timeRulerTextStyle = new SchedulerTextStyle()
        {
            TextColor = Colors.AliceBlue,
            FontSize = 12,
        };
        this.WeekPageScheduler.DaysView.TimeRulerTextStyle = timeRulerTextStyle;
        this.WeekPageScheduler.TimelineView.TimeRulerTextStyle = timeRulerTextStyle;
    }




    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
        Tasklist.ItemsSource = null;
    }
    public void loadAppointments()
    {
        var AppointmentEvents = new ObservableCollection<Appointment>(App.appointmentRepo.GetAppointments());
        WeekPageScheduler.AppointmentsSource = AppointmentEvents;
        
    }

    private void WeekPageScheduler_AppointmentDrop(object sender, AppointmentDropEventArgs e)
    {
        var dragedApp = e.Appointment;
        if(dragedApp != null)
        {
            int num = Convert.ToInt32(dragedApp.Id);
            Appointment temp = App.appointmentRepo.GetAppointmentByID(num);
            TimeSpan delta = temp.EventEnd - temp.EventStart;
            temp.EventStart = e.DropTime;
            temp.EventEnd = e.DropTime.Add(delta);
            App.appointmentRepo.Update(temp);
        }    
        loadAppointments();
    }
    private async void buttonAddAppointment_Clicked(object sender, EventArgs e)
    {
        IntitializeSound();
        Clicked_Sound.Play();
        Opacity = 1;
        await Shell.Current.GoToAsync(nameof(AddAppointmentPage));
    }
    
    private async void btnOpenDeatil_Clicked(object sender, EventArgs e)
    {
        IntitializeSound();
        Clicked_Sound.Play();
        await Shell.Current.GoToAsync("//Day");
        var daypage = (DayPage)Shell.Current.CurrentPage;
        daypage.Load(xxx);
    } 

    private void TaskList_ChildAdded(object sender, ElementEventArgs e)
    {
        throw new NotImplementedException();
    }
    private DateTime xxx;
    private void WeekPageScheduler_Tapped(object sender, SchedulerTappedEventArgs e)
    {
        IntitializeSound();
        if (e.Element is SchedulerElement.ViewHeader)
        {
            Tasklist.ItemsSource = null;

            var CurrentAppointment = new ObservableCollection<Appointment>(App.appointmentRepo.GetAppointments());
            List<Appointment> appointmennts = new List<Appointment>();
            xxx = e.Date.Value;
            foreach (Appointment app in CurrentAppointment)
            {
                if (app.EventStart.Day <= e.Date.Value.Day && e.Date.Value.Day <= app.EventEnd.Day)
                {
                    appointmennts.Add(app);
                }
            }
            if (appointmennts.Count > 0)
            {
                Tasklist.ItemsSource = appointmennts;
                loadAppointments();
            }
            Clicked_Sound.Play();
            
        }
        else if (e.Appointments != null)
        {
            if (e.Appointments.Count == 1)
            {
                Clicked_Sound.Play();
                Shell.Current.GoToAsync($"{nameof(EditAppointmentPage)}?AppId={((Appointment)e.Appointments[0]).Id}");
            }
        }
            
            
    }

    private async void Tasklist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (Tasklist.SelectedItem != null)
        {
         
            int temp = ((Appointment)e.SelectedItem).Id;
            await Shell.Current.GoToAsync($"{nameof(EditAppointmentPage)}?AppId={((Appointment)Tasklist.SelectedItem).Id}");
            Tasklist.ItemsSource = null;
        }
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointment)
        {
            Clicked_Sound.Play();
            App.appointmentRepo.DeleteAppointment(appointment);
            App.appointmentRepo.DeleteReminder(App.appointmentRepo.GetReminderById(appointment.Id));
            loadAppointments();
            List<Appointment> postDeleteAppointment = App.appointmentRepo.GetAppointments(); 
            Tasklist.ItemsSource = postDeleteAppointment ;
        }
    }

    void OnPomoButtonClicked(object sender, EventArgs e)
    {
        IntitializeSound();
        Clicked_Sound.Play();
         WPPomoButton.Opacity = 1;
        Navigation.PushModalAsync(new PomodoroPage(audioManager));
    }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        IntitializeSound();
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox != null)
        {
            if (checkbox.IsChecked)
            {
                CheckBox_Sound.Play();
            }
        }
    }
    //press handlers
    private void Pomodoro_Pressed(object sender, EventArgs e)
    {
        WPPomoButton.Opacity = 0.5;
    }
    private void btnOpenDeatil_Pressed(object sender, EventArgs e)
    {
        btnOpenDeatil.Opacity = 0.5;
    }
    private void buttonAddAppointment_Pressed(object sender, EventArgs e)
    {
        buttonAddAppointment.Opacity = 0.5;
    }
    private void WPPomoButton_Pressed(object sender, EventArgs e)
    {
        WPPomoButton.Opacity= 0.5;
    }
    private void Settingbtn_Clicked(object sender, EventArgs e)
    {
        Settingbtn.Opacity = 1;
        Clicked_Sound.Play();
        SettingPage newSettingPage = new SettingPage();
        this.ShowPopup(newSettingPage);
    }
    private void Settingbtn_Pressed(object sender, EventArgs e)
    {
        Settingbtn.Opacity = 0.5;

    }

    private async void WeekPageScheduler_ReminderAlertOpening(object sender, ReminderAlertOpeningEventArgs e)
    {
        for (int i = 0; i < e.Reminders.Count; i++)
        {
            if (!e.Reminders[i].IsDismissed)
            {
                int id = int.Parse(e.Reminders[i].Appointment.Id.ToString());
                Reminder reminder = App.appointmentRepo.GetReminderByBeforeStartTime(e.Reminders[i].AlertTime, id);
                if (reminder != null && !reminder.IsDismissed)
                {
                    await DisplayAlert("Reminder", e.Reminders[i].Appointment.Subject + " - " + e.Reminders[i].Appointment.StartTime.ToString(" dddd, MMMM dd, yyyy, hh:mm tt"), "OK");
                    Mediaelement4.Play();
                    reminder.IsDismissed = true;
                    App.appointmentRepo.DeleteReminder(reminder);
                }
            }
        }
    }
}