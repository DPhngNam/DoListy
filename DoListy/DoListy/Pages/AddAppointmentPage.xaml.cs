namespace DoListy.Pages;

public partial class AddAppointmentPage : ContentPage
{
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple" };
    public AddAppointmentPage()
	{
		InitializeComponent();
        Freg.ItemsSource = freqs;
        ColorEntry.ItemsSource = Colors;
	}

    private async void buttonCancle_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void buttonCreate_Clicked(object sender, EventArgs e)
    {
        Brush temp = Brush.Blue;
        if(ColorEntry.SelectedItem.ToString() == "Blue")
        {
            temp = Brush.Blue;
        }   
        else if(ColorEntry.SelectedItem.ToString() == "Orange")
        {
            temp = Brush.Orange;
        }    
        else if (ColorEntry.SelectedItem.ToString() == "Purple")
        {
            temp = Brush.Purple;
        }
        else if(ColorEntry.SelectedItem.ToString() == "Red")
        {
            temp = Brush.Red;
        }
        else temp = Brush.Green;

        if (Freg.SelectedItem == null)
        {
            ControlViewModel.ControlViewModel.AddAppointment(new ViewModel.Appointment
            {
                Name = entrySubject.Text,
                EventStart = pickerDateTime1.SelectedDate,
                EventEnd = pickerDateTime2.SelectedDate,
                Colorbg = temp,
            });
        }
        else {
            ControlViewModel.ControlViewModel.AddAppointment(new ViewModel.Appointment
            {
                Name = entrySubject.Text,
                EventStart = pickerDateTime1.SelectedDate,
                EventEnd = pickerDateTime2.SelectedDate,
                Colorbg = temp,
                Recurrencerule = "FREQ=" + Freg.SelectedItem.ToString() + ";INTERVAL=" + Interval.Text + ";COUNT=" + Count.Text,
            }); 
        }
        await Navigation.PopModalAsync();
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
}