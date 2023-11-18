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
        taskframestack.Clear();
        if (e.Appointments == null) return;
        if (e.Appointments.Count > 0)
        {
            foreach (Appointment ap in e.Appointments)
            {
                Label appNameLabel = new Label { Text = ap.Name, TextColor = new Color(0, 0, 0) };
                Label appStartEndLabel = new Label { Text = ap.EventStart.ToString() + "-" + ap.EventEnd.ToString(), TextColor = new Color(0, 0, 0), FontSize = 10 };
                StackLayout views = new StackLayout();
                views.Children.Add(appNameLabel);
                views.Children.Add(appStartEndLabel);
                taskframestack.Children.Add(views);
            }
        }

    }
}