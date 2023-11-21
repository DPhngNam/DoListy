using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.ControlViewModel;
using Syncfusion.Maui.Scheduler;
using System.Runtime.CompilerServices;
//using Foundation;

namespace DoListy.Pages;


public partial class WeekPage : ContentPage
{
	public WeekPage()
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
        WeekPageScheduler.AppointmentsSource = AppointmentEvents;
    }

    private void WeekPageScheduler_AppointmentDrop(object sender, AppointmentDropEventArgs e)
    {
        loadAppointments();
    }
    private async void buttonAddAppointment_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddAppointmentPage());
    }
    private async void btnOpenDeatil_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Day");
        var daypage = (DayPage)Shell.Current.CurrentPage;
    }


    private void TaskList_ChildAdded(object sender, ElementEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void WeekPageScheduler_Tapped(object sender, SchedulerTappedEventArgs e)
    {
        if (e.Element is SchedulerElement.ViewHeader)
        {
            Tasklist.ItemsSource = null;
            var CurrentAppointment = new ObservableCollection<Appointment>(ControlViewModel.ControlViewModel.GetAppointments());
            List<string> strings = new List<string>();
            foreach (Appointment app in CurrentAppointment)
            {
                if  (app.EventStart.Day <=e.Date.Value.Day && e.Date.Value.Day <=app.EventEnd.Day)
                {
                    strings.Add(app.Name);
                }
            }
            Tasklist.ItemsSource = strings;
        }
    }
}