using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.ControlViewModel;
using System.Xml;

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
        await Navigation.PushModalAsync(new AddAppointmentPage());
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
        bool snooze = await DisplayAlert("Reminder", Scheduler.AppointmentMapping.Subject + " - " + Scheduler.AppointmentMapping.StartTime.ToString(), "Snooze", "Dismiss");
    }
}