using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using System.Xml;
using CommunityToolkit.Maui.Core;
using Plugin.Maui.Audio;
using Syncfusion.Maui.Scheduler;

namespace DoListy.Pages;
public partial class MonthPage : ContentPage
{
    private bool checkboz;
    public Brush ColorBG;
    private DateTime pickedDate = DateTime.Now;
    private readonly IAudioManager audioManager;

    public MonthPage(IAudioManager audioManager)
	{
		InitializeComponent();
        TasksList.ItemsSource = null;
        this.audioManager=audioManager;
        checkboz = false;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
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
        var currentTime = DateTime.Now;
        var startTime = e.Reminders[0].Appointment.StartTime;

        if (currentTime > startTime)
        {
            return;
        }

        var reminderTime = startTime - e.Reminders[0].TimeBeforeStart;

        if (currentTime >= reminderTime && currentTime < startTime && !e.Reminders[0].IsDismissed)//xet thoi gia reminder toi luc chua va current time phai be hon start time
        {
            bool snooze = await DisplayAlert("Reminder", e.Reminders[0].Appointment.Subject + " - " + startTime.ToString(), "Snooze", "Dismiss");

            e.Reminders[0].IsDismissed = true;
        }
    }
    
    private void Scheduler_Tapped(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        TasksList.ItemsSource = null;
        if (e.Appointments == null) return;
        TasksList.ItemsSource = e.Appointments;
        loadAppointments();
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        if (sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointment)
        {
            App.appointmentRepo.DeleteAppointment(appointment);
            loadAppointments();
            TasksList.ItemsSource = null;
        }
    }
    
    private async void TasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        
        if(TasksList.SelectedItem != null)
        {
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
        Navigation.PushModalAsync(new PomodoroPage());
    }

    private void PomoButton_Pressed(object sender, EventArgs e)
    {
        PomoButton.Opacity = 0.5;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;

        if (checkbox != null)
        {
            if (checkbox.IsChecked)
            {
                Mediaelement3.Play();
            }
        }
    }
    private void btnSettings_Clicked_1(object sender, EventArgs e)
    {
        
    }
}