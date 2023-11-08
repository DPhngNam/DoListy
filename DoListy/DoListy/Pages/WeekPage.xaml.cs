using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.ControlViewModel;
using Syncfusion.Maui.Scheduler;

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
}