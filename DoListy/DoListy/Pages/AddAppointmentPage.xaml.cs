namespace DoListy.Pages;

public partial class AddAppointmentPage : ContentPage
{
	public AddAppointmentPage()
	{
		InitializeComponent();
	}

    private async void buttonCancle_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void buttonCreate_Clicked(object sender, EventArgs e)
    {
        ControlViewModel.ControlViewModel.AddAppointment(new ViewModel.Appointment
        {
            Name = entrySubject.Text,
            EventStart = DateTime.Parse(entryStartTime.Text),
            EventEnd = DateTime.Parse(entryEndTime.Text),
        });
        await Navigation.PopModalAsync();
    }
}