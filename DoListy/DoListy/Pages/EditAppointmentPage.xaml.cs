namespace DoListy.Pages;

public partial class EditAppointmentPage : ContentPage
{
    ViewModel.Appointment AddedAppointment = new ViewModel.Appointment();
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY", "NONE" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple" };
    public EditAppointmentPage(int Id)
	{
		InitializeComponent();
        FreqEdit.ItemsSource = freqs;
        ColorEdit.ItemsSource = Colors;
        ViewModel.Appointment appointment = ControlViewModel.ControlViewModel.GetAppointmentByID(Id);
        if (appointment != null )
        {
            AddedAppointment.Id = appointment.Id;
            editSubject.Text = appointment.Name;
            pickerDateTime1.SelectedDate = appointment.EventStart;
            eidtStartTime.Text = appointment.EventStart.ToString();
            pickerDateTime2.SelectedDate = appointment.EventEnd;
            editEndTime.Text = appointment.EventEnd.ToString();
        }
	}

    private void eidtStartTime_Clicked(object sender, EventArgs e)
    {
        pickerDateTime1.IsOpen = true;
    }

    private void pickerDateTime1_CancelButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime1.IsOpen = false;
    }

    private void pickerDateTime1_OkButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime1.IsOpen = false;
        eidtStartTime.Text = pickerDateTime1.SelectedDate.ToString();
    }

    private void editEndTime_Clicked(object sender, EventArgs e)
    {
        pickerDateTime2.IsOpen = true;
    }

    private void pickerDateTime2_CancelButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime2.IsOpen = false;
    }

    private void pickerDateTime2_OkButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime2.IsOpen = false;
        editEndTime.Text = pickerDateTime2.SelectedDate.ToString();
    }

    private async void buttonCancle1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void buttonSave_Clicked(object sender, EventArgs e)
    {
        Brush temp = Brush.Blue;
        if (ColorEdit.SelectedItem.ToString() == "Blue")
        {
            temp = Brush.Blue;
        }
        else if (ColorEdit.SelectedItem.ToString() == "Orange")
        {
            temp = Brush.Orange;
        }
        else if (ColorEdit.SelectedItem.ToString() == "Purple")
        {
            temp = Brush.Purple;
        }
        else if (ColorEdit.SelectedItem.ToString() == "Red")
        {
            temp = Brush.Red;
        }
        else temp = Brush.Green;

        if (FreqEdit.SelectedItem == null) // xu li cho Freq khong co
        {
            AddedAppointment.Name = editSubject.Text;
            AddedAppointment.EventStart = pickerDateTime1.SelectedDate;
            AddedAppointment.EventEnd  = pickerDateTime2.SelectedDate;
        }
        else if(CountEdit.Text != null && IntervalEdit.Text != null)
        {
            AddedAppointment.Name = editSubject.Text;
            AddedAppointment.EventStart = pickerDateTime1.SelectedDate;
            AddedAppointment.EventEnd = pickerDateTime2.SelectedDate;
            AddedAppointment.Recurrencerule = "FREQ=" + FreqEdit.SelectedItem.ToString() + ";INTERVAL=" + IntervalEdit.Text + ";COUNT=" + CountEdit.Text;
        }
        ControlViewModel.ControlViewModel.Update(AddedAppointment.Id, AddedAppointment);
        await Navigation.PopModalAsync();
    }
}