using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;
using DoListy.ControlViewModel;

namespace DoListy.Pages;
public partial class MonthPage : ContentPage
{
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
    }
}