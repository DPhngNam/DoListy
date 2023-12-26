using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using System.Xml;
using CommunityToolkit.Maui.Core;
using Plugin.Maui.Audio;
using Syncfusion.Maui.Scheduler;
using CommunityToolkit.Maui.Views;

namespace DoListy.Pages;
public partial class MonthPage : ContentPage
{
    public Brush ColorBG;
    private DateTime pickedDate = DateTime.Now;
    private readonly IAudioManager audioManager;

    public MonthPage(IAudioManager audioManager)
	{
		InitializeComponent();
        TasksList.ItemsSource = null;
        this.audioManager=audioManager;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
        Load(DateTime.Now);
    }
    public void loadAppointments()
    {
        List<Appointment> appointments =  App.appointmentRepo.GetAppointments();
        var AppointmentEvents = new ObservableCollection<Appointment>(appointments);
        Scheduler.AppointmentsSource = AppointmentEvents;
    }

    private async void buttonAddAppointment_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        buttonAddAppointment.Opacity = 1.0;
        //await Navigation.PushModalAsync(new AddAppointmentPage());
        await Shell.Current.GoToAsync(nameof(AddAppointmentPage));
        TasksList.ItemsSource = null;
    }
    private void buttonAddAppointment_Pressed(object sender, EventArgs e)
    {
        buttonAddAppointment.Opacity = 0.5;
    }
    private async void btnOpenDeatil_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        btnOpenDeatil.Opacity = 1.0;
        await Shell.Current.GoToAsync("//Day");
        var daypage = (DayPage)Shell.Current.CurrentPage;
        daypage.Load(xxx);
    }
    private void btnOpenDeatil_Pressed(object sender, EventArgs e)
    {
        btnOpenDeatil.Opacity = 0.5;
    }

    private void Scheduler_SelectionChanged(object sender, Syncfusion.Maui.Scheduler.SchedulerSelectionChangedEventArgs e)
    {
        pickedDate = (DateTime)e.NewValue;
    }

    private async void Scheduler_ReminderAlertOpening(object sender, Syncfusion.Maui.Scheduler.ReminderAlertOpeningEventArgs e)
    {
        for (int i = 0; i < e.Reminders.Count; i++)
        {
            if (!e.Reminders[i].IsDismissed)
            {
                int id = int.Parse(e.Reminders[i].Appointment.Id.ToString());
                Reminder reminder = App.appointmentRepo.GetReminderByBeforeStartTime(e.Reminders[i].AlertTime, id);
                if (reminder != null && !reminder.IsDismissed)
                {
                    Mediaelement4.Play();
                    await DisplayAlert("Reminder", e.Reminders[i].Appointment.Subject + " - " + e.Reminders[i].Appointment.StartTime.ToString(" dddd, MMMM dd, yyyy, hh:mm tt"), "OK");
                    reminder.IsDismissed = true;
                    App.appointmentRepo.DeleteReminder(reminder);
                }
            }
        }
    }

    private void Scheduler_Tapped(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        TasksList.ItemsSource = null;
        if (e.Appointments == null) return;
        TasksList.ItemsSource = e.Appointments;
        
        loadAppointments();
        xxx = e.Date.Value;
        Load(e.Date.Value);
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        if (sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointment)
        {
            App.appointmentRepo.DeleteAppointment(appointment);
            App.appointmentRepo.DeleteReminder(App.appointmentRepo.GetReminderById(appointment.Id));
            loadAppointments();
            TasksList.ItemsSource = null;
        }
    }
    
    private async void TasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        
        if(TasksList.SelectedItem != null)
        {
            Mediaelement1.Play();
            int temp = ((Appointment)e.SelectedItem).Id;
            await Shell.Current.GoToAsync($"{nameof(EditAppointmentPage)}?AppId={((Appointment)TasksList.SelectedItem).Id}");
            TasksList.ItemsSource = null;
        }
    }

    private void TasksList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        TasksList.SelectedItem = null;
    }

    private void PomoButton_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        PomoButton.Opacity = 1.0;
        Navigation.PushModalAsync(new PomodoroPage(audioManager));
    }

    private void PomoButton_Pressed(object sender, EventArgs e)
    {
        PomoButton.Opacity = 0.5;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
            if (checkbox.IsChecked)
            {
                Mediaelement3.Play();
            }
    }
    private void OnSettingsButtonPressed(object sender, EventArgs e)
    {
        btnSettings.Opacity = 0.5;
    }

    private void OnSettingsButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        btnSettings.Opacity = 1.0;
        SettingPage newSettingPage = new SettingPage();
        this.ShowPopup(newSettingPage);
    }
    private DateTime xxx;
    private void Load(DateTime current)
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
        TasksList.ItemsSource = appointmennts;
    }
}