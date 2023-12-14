using DoListy.ViewModel;

namespace DoListy.Pages;

public partial class AddAppointmentPage : ContentPage
{
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY", "NONE" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple"};

    public AddAppointmentPage()
	{
		InitializeComponent();
        Freg.ItemsSource = freqs;
        ColorEntry.ItemsSource = Colors;
	}

    private void buttonCancle_Clicked(object sender, EventArgs e)
    {
        buttonCancle.Opacity = 1.0;
        Shell.Current.GoToAsync("..");
    }
    private void buttonCancle_Pressed(object sender, EventArgs e)
    {
        buttonCancle.Opacity = 0.5;
    }

    private void buttonCreate_Clicked(object sender, EventArgs e)
    {
        buttonCreate.Opacity = 1.0;
        Appointment appointment = new Appointment()
        {
            Name = entrySubject.Text,
            EventStart = pickerDateTime1.SelectedDate,
            EventEnd = pickerDateTime2.SelectedDate,
        };
        appointment.colorbgString = "Blue";
        if (ColorEntry.SelectedItem != null)
        {
            appointment.colorbgString = ColorEntry.SelectedItem.ToString();
        }
        if (Interval.Text != null && pickerDateTime3.SelectedDate.ToString() != null && Freg.SelectedItem.ToString() != null)
        {
            appointment.Frequency = Freg.SelectedItem.ToString();
            appointment.Interval = Interval.Text;
            appointment.Until = pickerDateTime3.SelectedDate;
            string until = pickerDateTime3.SelectedDate.ToString("yyyyMMddTHHmmssZ");
            appointment.Recurrencerule = "FREQ=" + Freg.SelectedItem.ToString() + ";INTERVAL=" + Interval.Text + ";UNTIL=" + until;
        }
        if (Note.Text != null)
        {
            appointment.Note = Note.Text;
        }
        appointment.IsDone = false;
        App.appointmentRepo.AddAppointment(appointment);
        //Added by Phuong Nam
        Application.Current.MainPage.DisplayAlert("Success", "Created successfully", "OK");
        //Added by Phuong Nam
        Shell.Current.GoToAsync("..");
    }
    private void buttonCreate_Pressed(object sender, EventArgs e)
    {
        buttonCreate.Opacity = 0.5;
    }

    private void entryStartTime_Clicked(object sender, EventArgs e)
    {
        entryStartTime.Opacity = 1.0;
        pickerDateTime1.IsOpen = true;
    }
    private void entryStartTime_Pressed(object sender, EventArgs e)
    {
        entryStartTime.Opacity = 0.5;
    }

    private void entryEndTime_Clicked(object sender, EventArgs e)
    {
        entryEndTime.Opacity = 1.0;
        pickerDateTime2.IsOpen = true;
    }
    private void entryEndTime_Pressed(object sender, EventArgs e)
    {
        entryEndTime.Opacity = 0.5;
    }

    private void pickerDateTime1_CancelButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime1.IsOpen = false;
    }

    private void pickerDateTime2_CancelButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime2.IsOpen = false;
    }

    private void pickerDateTime2_OkButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime2.IsOpen = false;
        entryEndTime.Text = pickerDateTime2.SelectedDate.ToString();
    }

    private void pickerDateTime1_OkButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime1.IsOpen = false;
        entryStartTime.Text = pickerDateTime1.SelectedDate.ToString();
    }

    private void pickerDateTime3_CancelButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime3.IsOpen = false;
    }

    private void pickerDateTime3_OkButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime3.IsOpen = false;
        Until.Text = pickerDateTime3.SelectedDate.ToString("d");
    }

    private void Until_Clicked(object sender, EventArgs e)
    {
        Until.Opacity = 1.0;
        pickerDateTime3.IsOpen = true;
    }
    private void Until_Pressed(object sender, EventArgs e)
    {
        Until.Opacity = 0.5;
    }
}





