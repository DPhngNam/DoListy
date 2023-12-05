using DoListy.ViewModel;
using System.Collections.ObjectModel;
using Appointment = DoListy.ViewModel.Appointment;

using Syncfusion.Maui.Scheduler;
using System.Runtime.CompilerServices;
using Plugin.Maui.Audio;
//using AndroidX.Core.View.Accessibility;
//using Foundation;

namespace DoListy.Pages;


public partial class WeekPage : ContentPage
{
    private readonly IAudioManager audioManager;

    public WeekPage(IAudioManager audioManager)
    {
        InitializeComponent();
        TimeRulerTextStyle();
        this.audioManager= audioManager;
        
    }
    public SchedulerAppointmentMapping schedulerAppointmentMapping { get; set; }
    private void TimeRulerTextStyle()
    {
        var timeRulerTextStyle = new SchedulerTextStyle()
        {
            TextColor = Colors.AliceBlue,
            FontSize = 12,
        };
        this.WeekPageScheduler.DaysView.TimeRulerTextStyle = timeRulerTextStyle;
        this.WeekPageScheduler.TimelineView.TimeRulerTextStyle = timeRulerTextStyle;
    }




    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadAppointments();
        Tasklist.ItemsSource = null;
    }
    public void loadAppointments()
    {
        var AppointmentEvents = new ObservableCollection<Appointment>(App.appointmentRepo.GetAppointments());
        WeekPageScheduler.AppointmentsSource = AppointmentEvents;
    }

    private void WeekPageScheduler_AppointmentDrop(object sender, AppointmentDropEventArgs e)
    {
        var dragedApp = e.Appointment;
        if(dragedApp != null)
        {
            int num = Convert.ToInt32(dragedApp.Id);
            Appointment temp = App.appointmentRepo.GetAppointmentByID(num);
            TimeSpan delta = temp.EventEnd - temp.EventStart;
            temp.EventStart = e.DropTime;
            temp.EventEnd = e.DropTime.Add(delta);
            App.appointmentRepo.Update(temp);
        }    
        loadAppointments();
    }
    private async void buttonAddAppointment_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddAppointmentPage));
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
        loadAppointments();
        if (e.Element is SchedulerElement.ViewHeader)
        {
            Tasklist.ItemsSource = null;
            //if (e.Appointments == null)
            //    return;
            //Tasklist.ItemsSource = e.Appointments;
            //loadAppointments();

            var CurrentAppointment = new ObservableCollection<Appointment>(App.appointmentRepo.GetAppointments());
            List<Appointment> appointmennts = new List<Appointment>();
        
            foreach (Appointment app in CurrentAppointment)
            {
                if (app.EventStart.Day <= e.Date.Value.Day && e.Date.Value.Day <= app.EventEnd.Day)
                {
                    appointmennts.Add(app);
                }
            }
            Tasklist.ItemsSource = appointmennts;
            loadAppointments();
        }
    }

    private async void Tasklist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (Tasklist.SelectedItem != null)
        {
            int temp = ((Appointment)e.SelectedItem).Id;
            await Shell.Current.GoToAsync($"{nameof(EditAppointmentPage)}?AppId={((Appointment)Tasklist.SelectedItem).Id}");
            Tasklist.ItemsSource = null;
        }
    }

    private void Tasklist_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Tasklist.SelectedItem = null;

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem && menuItem.CommandParameter is Appointment appointment)
        {
            App.appointmentRepo.DeleteAppointment(appointment);
            loadAppointments();
            Tasklist.ItemsSource = null;
        }
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("tick.mp3"));
        player.Play();


    }
}