using DoListy.ViewModel;
using Syncfusion.Maui.ListView;

namespace DoListy.Pages;

[QueryProperty(nameof(ID), "AppId")]

public partial class EditAppointmentPage : ContentPage
{
    Appointment appointment = new Appointment();
    List<string> freqs = new List<string>() { "DAILY", "WEEKLY", "MONTHLY", "YEARLY", "NONE" };
    List<string> Colors = new List<string>() { "Blue", "Red", "Green", "Orange", "Purple" };
    List<string> TimeRemind = new List<string>() { "MINUTES", "HOURS", "DAYS", "NONE" };

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
                eidtStartTime.Text = appointment.EventStart.ToString("dd/MM/yyyy HH:mm:ss");
                pickerDateTime2.SelectedDate = appointment.EventEnd;
                editEndTime.Text = appointment.EventEnd.ToString("dd/MM/yyyy HH:mm:ss");
                if(!string.IsNullOrEmpty(appointment.Note))
                {
                    NoteEdit.Text = appointment.Note.ToString();
                }
                if (!appointment.Until.Day.Equals(1/1/0001))
                {
                    UntilEdit.Text = appointment.Until.ToString("dd/MM/yyyy HH:mm:ss");
                    pickerDateTime3.SelectedDate = appointment.Until;
                }
            }
        }
    }
    public EditAppointmentPage()
	{
		InitializeComponent();
        FreqEdit.ItemsSource = freqs;
        ColorEdit.ItemsSource = Colors;
        EditPickerRemnder.ItemsSource = TimeRemind;
    }

    private void eidtStartTime_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        eidtStartTime.Opacity = 1.0;
        pickerDateTime1.IsOpen = true;
    }
    private void eidtStartTime_Pressed(object sender, EventArgs e)
    {
        eidtStartTime.Opacity = 0.5;
    }

    private void pickerDateTime1_CancelButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        pickerDateTime1.IsOpen = false;
    }

    private void pickerDateTime1_OkButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        pickerDateTime1.IsOpen = false;
        eidtStartTime.Text = pickerDateTime1.SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void editEndTime_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        editEndTime.Opacity = 1.0;
        pickerDateTime2.IsOpen = true;
    }
    private void editEndTime_Pressed(object sender, EventArgs e)
    {
        editEndTime.Opacity = 0.5;
    }

    private void pickerDateTime2_CancelButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        pickerDateTime2.IsOpen = false;
    }

    private void pickerDateTime2_OkButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        pickerDateTime2.IsOpen = false;
        editEndTime.Text = pickerDateTime2.SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private  void buttonCancle1_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        Shell.Current.GoToAsync("..");
    }

    private void buttonSave_Clicked(object sender, EventArgs e)
    {
        buttonSave.Opacity = 1.0;
        Mediaelement2.Play();
        appointment.Name = editSubject.Text;
        appointment.EventStart = pickerDateTime1.SelectedDate;
        appointment.EventEnd = pickerDateTime2.SelectedDate;
        if (ColorEdit.SelectedItem != null)
        {
            appointment.colorbgString = ColorEdit.ToString();
        }
        if(pickerDateTime3.SelectedDate.ToString() != null && IntervalEdit.Text != null && FreqEdit.SelectedItem != null)
        {
            appointment.Until = pickerDateTime3.SelectedDate;
            string until = pickerDateTime3.SelectedDate.ToString("yyyyMMddTHHmmssZ");
            appointment.Interval = IntervalEdit.Text;
            string inter = IntervalEdit.Text;
            string freq = FreqEdit.SelectedItem.ToString();
            appointment.Frequency = FreqEdit.SelectedItem.ToString();
            appointment.Recurrencerule = "FREQ=" + freq + ";INTERVAL=" + inter + ";UNTIL=" + until;
        }
        if(!string.IsNullOrEmpty(NoteEdit.Text))
        {
            appointment.Note = NoteEdit.Text;
        }    
        App.appointmentRepo.Update(appointment);
        if(EditReminder.Text != null && EditPickerRemnder.SelectedItem != null)
        {
            Reminder reminder = App.appointmentRepo.GetReminderById(appointment.Id);
            int a = 1;
            if (int.TryParse(EditReminder.Text, out a))
            {
                switch (EditPickerRemnder.SelectedItem.ToString())
                {
                    case "MINUTES":
                        break;
                    case "HOURS":
                        a = a * 60;
                        break;
                    case "DAYS":
                        a = a * 60 * 24;
                        break;
                }
                reminder.TimeBeforeStart = a;
            }
            if (reminder != null)
            {
                App.appointmentRepo.UpdateReminder(reminder);
            }
            else
            {
                Reminder temp2 = new Reminder()
                {
                    IdAppointment = appointment.Id,
                    IsDismissed = false,
                    TimeBeforeStart = a
                };
                App.appointmentRepo.AddReminder(temp2);
            }
        }
        Application.Current.MainPage.DisplayAlert("Success", "Save successfully", "OK");
        Shell.Current.GoToAsync("..");
    }
    private void buttonSave_Pressed(object sender, EventArgs e)
    {
        buttonSave.Opacity = 0.5;
    }

    private void pickerDateTime3_CancelButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        buttonCancle1.Opacity = 1.0;
        pickerDateTime3.IsOpen = false;
    }
    private void buttonCancle1_Pressed(object sender, EventArgs e)
    {
        buttonCancle1.Opacity = 0.5;
    }

    private void pickerDateTime3_OkButtonClicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        pickerDateTime3.IsOpen = false;
        UntilEdit.Text = pickerDateTime3.SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void UntilEdit_Clicked(object sender, EventArgs e)
    {
        Mediaelement2.Play();
        pickerDateTime3.IsOpen = true;
        UntilEdit.Opacity = 1.0;
    }

    private void UntilEdit_Pressed(object sender, EventArgs e)
    {
        UntilEdit.Opacity = 0.5;
    }
}