using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.ControlViewModel;
using System.Xml;
using CommunityToolkit.Maui.Core;

namespace DoListy.Pages;
public partial class MonthPage : ContentPage
{
    private DateTime pickedDate = DateTime.Now;
	public MonthPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
    }
    public void loadAppointments()
    {
        var AppointmentEvents = new ObservableCollection<Appointment>(ControlViewModel.ControlViewModel.GetAppointments());
        Scheduler.AppointmentsSource = AppointmentEvents;
    }

    private async void buttonAddAppointment_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new AddAppointmentPage());
        await Shell.Current.GoToAsync(nameof(AddAppointmentPage));
    }

    private void Scheduler_AppointmentDrop(object sender, Syncfusion.Maui.Scheduler.AppointmentDropEventArgs e)
    {
        loadAppointments();
    }
    private async void btnOpenDeatil_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Day");
        var daypage = (DayPage)Shell.Current.CurrentPage;
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
}