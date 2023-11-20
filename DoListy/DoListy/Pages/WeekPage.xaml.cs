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
        InitializeDateLabel();
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
    private void InitializeDateLabel()
    {
       DateTime today = DateTime.Today;
       DayOfWeek currentdayOfWeek = today.DayOfWeek;
        DateTime LastMonday = today.AddDays(-(int)currentdayOfWeek);
        string dateRangeString = $"{LastMonday.ToString("dd")}-{today.ToString("dd/MM/yyyy")}";
        WPdateLabel.Text = dateRangeString;

    }
    private void WeekPageScheduler_Tapped(object sender, SchedulerTappedEventArgs e)
    {
        taskframestack.Clear();
        
            if (e.Appointments == null) return;
            foreach (Appointment app in e.Appointments)
            {

                Label var = new Label { Text = app.Name , TextColor = new Color(1, 1, 1) };
                Label label = new Label { Text = app.EventStart.ToString("hh/mm,dd/mm/yy") +"-"+ app.EventEnd.ToString("hh/mm,dd/mm/yy"),TextColor=new Color(0,0,0)};
                StackLayout framestack = new StackLayout();
                framestack.Children.Add(var);
                framestack.Children.Add(label);
                Frame frame = new Frame { BackgroundColor= new Color(255,255,255)};
                frame.Content = framestack;

                taskframestack.Children.Add(frame);
            }

        
    }
}