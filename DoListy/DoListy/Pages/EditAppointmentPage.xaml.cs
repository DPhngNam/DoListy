namespace DoListy.Pages;

public partial class EditAppointmentPage : ContentPage
{
    int Temp;
    Brush temp;
    ViewModel.Appointment AddedAppointment = new ViewModel.Appointment(5);
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY", "NONE" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple" };
    public EditAppointmentPage(int Id)
	{
		InitializeComponent();
        FreqEdit.ItemsSource = freqs;
        ColorEdit.ItemsSource = Colors;
        if (ControlViewModel.ControlViewModel.GetAppointmentByID(Id) != null )
        {
            temp = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).Colorbg;
            AddedAppointment.Id = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).Id;
            editSubject.Text = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).Name;
            pickerDateTime1.SelectedDate = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).EventStart;
            eidtStartTime.Text = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).EventStart.ToString();
            pickerDateTime2.SelectedDate = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).EventEnd;
            editEndTime.Text = ControlViewModel.ControlViewModel.GetAppointmentByID(Id).EventEnd.ToString();
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
        if(ColorEdit.SelectedItem != null)
        {
            switch(ColorEdit.SelectedItem.ToString()) 
            {
                case "Blue":
                    temp = Brush.Blue;
                    break;
                case "Orange":
                    temp = Brush.Orange;
                    break;
                case "Green":
                    temp = Brush.Green;
                    break;
                case "Red":
                    temp = Brush.Red;
                    break;
                case "Purple":
                    temp = Brush.Purple;
                    break;
            }
        }    

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
        
        Application.Current.MainPage.DisplayAlert("Success", "Save successfully", "OK");
        Navigation.PopModalAsync();
    }
}