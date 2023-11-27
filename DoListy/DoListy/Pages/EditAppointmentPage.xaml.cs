using DoListy.ViewModel;
using Syncfusion.Maui.ListView;

namespace DoListy.Pages;

[QueryProperty(nameof(ID), "AppId")]

public partial class EditAppointmentPage : ContentPage
{
    Brush temp;
    Appointment appointment = new Appointment();
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY", "NONE" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple" };

    public async Task SetIDAsync(string value)
    {
        int num = Convert.ToInt32(value);
        appointment = await App.appointmentRepo.GetAppointmentByID(num);
        if (appointment != null)
        {
            temp = appointment.Colorbg;
            editSubject.Text = appointment.Name;
            pickerDateTime1.SelectedDate = appointment.EventStart;
            eidtStartTime.Text = appointment.EventStart.ToString();
            pickerDateTime2.SelectedDate = appointment.EventEnd;
            editEndTime.Text = appointment.EventEnd.ToString();
        }
    }

    public string ID
    {
        set
        {
            SetIDAsync(value).Wait(); // Sử dụng Wait để đợi cho phương thức SetIDAsync hoàn thành
        }
    }
    public EditAppointmentPage()
	{
		InitializeComponent();
        FreqEdit.ItemsSource = freqs;
        ColorEdit.ItemsSource = Colors;
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

    private  void buttonCancle1_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
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

            appointment.Name = editSubject.Text;
            appointment.EventStart = pickerDateTime1.SelectedDate;
            appointment.EventEnd  = pickerDateTime2.SelectedDate;
        }
        else if(CountEdit.Text != null && IntervalEdit.Text != null)
        {
            appointment.Name = editSubject.Text;
            appointment.EventStart = pickerDateTime1.SelectedDate;
            appointment.EventEnd = pickerDateTime2.SelectedDate;
            appointment.Recurrencerule = "FREQ=" + FreqEdit.SelectedItem.ToString() + ";INTERVAL=" + IntervalEdit.Text + ";COUNT=" + CountEdit.Text;
        }
        await App.appointmentRepo.Update(appointment);
        
        await Application.Current.MainPage.DisplayAlert("Success", "Save successfully", "OK");
        Shell.Current.GoToAsync("..");
    }
}