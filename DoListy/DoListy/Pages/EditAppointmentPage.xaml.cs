using DoListy.ViewModel;
using Syncfusion.Maui.ListView;

namespace DoListy.Pages;

[QueryProperty(nameof(ID), "AppId")]

public partial class EditAppointmentPage : ContentPage
{
    Appointment appointment = new Appointment();
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY", "NONE" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple" };

    public string ID
    {
        set
        {
            int num = Convert.ToInt32(value);
            appointment = App.appointmentRepo.GetAppointmentByID(num);
            if (appointment != null)
            {
                //temp = appointment.Colorbg;
                editSubject.Text = appointment.Name;
                pickerDateTime1.SelectedDate = appointment.EventStart;
                eidtStartTime.Text = appointment.EventStart.ToString();
                pickerDateTime2.SelectedDate = appointment.EventEnd;
                editEndTime.Text = appointment.EventEnd.ToString();
            }
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

    private void buttonSave_Clicked(object sender, EventArgs e)
    {   
        if (FreqEdit.SelectedItem == null) // xu li cho Freq khong co
        {
            appointment.Name = editSubject.Text;
            appointment.EventStart = pickerDateTime1.SelectedDate;
            appointment.EventEnd  = pickerDateTime2.SelectedDate;
            if(ColorEdit.SelectedItem != null)
            {
                appointment.colorbgString = ColorEdit.ToString();
            }    
        }
        else if(pickerDateTime3.SelectedDate.ToString() != null && IntervalEdit.Text != null)
        {
            appointment.Name = editSubject.Text;
            appointment.EventStart = pickerDateTime1.SelectedDate;
            appointment.EventEnd = pickerDateTime2.SelectedDate;
            if (ColorEdit.SelectedItem != null)
            {
                appointment.colorbgString = ColorEdit.ToString();
            }
            appointment.Recurrencerule = "FREQ=" + FreqEdit.SelectedItem.ToString() + ";INTERVAL=" + IntervalEdit.Text + ";UNTIL=" + pickerDateTime3.SelectedDate.ToString("yyyyMMddTHHmmssZ");
        }
        App.appointmentRepo.Update(appointment);
        
        Application.Current.MainPage.DisplayAlert("Success", "Save successfully", "OK");
        Shell.Current.GoToAsync("..");
    }

    private void pickerDateTime3_CancelButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime3.IsOpen = false;
    }

    private void pickerDateTime3_OkButtonClicked(object sender, EventArgs e)
    {
        pickerDateTime3.IsOpen = false;
        UntilEdit.Text = pickerDateTime3.SelectedDate.ToString();
    }

    private void UntilEdit_Clicked(object sender, EventArgs e)
    {
        pickerDateTime3.IsOpen = true;
    }
}