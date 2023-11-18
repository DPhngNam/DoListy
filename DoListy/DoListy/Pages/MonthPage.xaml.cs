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
        var currentTime = DateTime.Now;
        var startTime = e.Reminders[0].Appointment.StartTime;

        if (currentTime > startTime)
        {
            return;
        }

        var reminderTime = startTime - e.Reminders[0].TimeBeforeStart;

        if (currentTime >= reminderTime && currentTime < startTime && !e.Reminders[0].IsDismissed)
        {
            bool snooze = await DisplayAlert("Reminder", e.Reminders[0].Appointment.Subject + " - " + startTime.ToString(), "Snooze", "Dismiss");

            e.Reminders[0].IsDismissed = true;
        }
    }
    
    private void Scheduler_Tapped(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        stacktest.Clear();
        if (e.Appointments == null) return;
        if(e.Appointments.Count > 0)
        {
            foreach(Appointment app in e.Appointments)
            {
            
                Label var = new Label { Text = app.Name + "\n" + app.EventStart , TextColor = new Color(1,1,1) };
                Label label = new Label { Text = app.EventStart.ToString() };
                StackLayout framestack = new StackLayout();
                framestack.Children.Add(var);
                framestack.Children.Add(label);
                Frame frame = new Frame();
                frame.Content = framestack;
              
                stacktest.Children.Add(frame);
            }
        }
        
  

    }
}