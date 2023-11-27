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
        Shell.Current.GoToAsync("..");
    }

    private void buttonCreate_Clicked(object sender, EventArgs e)
    {
        //Brush temp = Brush.Blue;
        //if (ColorEntry.SelectedItem != null)
        //{
        //    switch (ColorEntry.SelectedItem.ToString())
        //    {
        //        case "Blue":
        //            temp = Brush.Blue;
        //            break;
        //        case "Orange":
        //            temp = Brush.Orange;
        //            break;
        //        case "Green":
        //            temp = Brush.Green;
        //            break;
        //        case "Red":
        //            temp = Brush.Red;
        //            break;
        //        case "Purple":
        //            temp = Brush.Purple;
        //            break;
        //    }
        //}

        if (Freg.SelectedItem == null || Freg.SelectedItem.ToString() == "NONE")
        {
            Appointment appointment = new Appointment()
            {
                Name = entrySubject.Text,
                EventStart = pickerDateTime1.SelectedDate,
                EventEnd = pickerDateTime2.SelectedDate,
                //Colorbg = ColorEntry.SelectedItem.ToString(),
            };
            App.appointmentRepo.AddAppointment(appointment);
        }
        else if(Interval.Text != null && Count.Text != null)
        {
            Appointment appointment = new Appointment()
            {
                Name = entrySubject.Text,
                EventStart = pickerDateTime1.SelectedDate,
                EventEnd = pickerDateTime2.SelectedDate,
                Colorbg = ColorEntry.SelectedItem.ToString(),
                Recurrencerule = "FREQ=" + Freg.SelectedItem.ToString() + ";INTERVAL=" + Interval.Text + ";COUNT=" + Count.Text,
            };
            App.appointmentRepo.AddAppointment(appointment);
        }
        //Added by Phuong Nam
        Application.Current.MainPage.DisplayAlert("Success", "Created successfully", "OK");
        //Added by Phuong Nam
        Shell.Current.GoToAsync("..");
    }

    private void entryStartTime_Clicked(object sender, EventArgs e)
    {
        pickerDateTime1.IsOpen = true;
    }

    private void entryEndTime_Clicked(object sender, EventArgs e)
    {
        pickerDateTime2.IsOpen = true;
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
}