namespace DoListy.Pages;

using System.Collections.ObjectModel;

public partial class DayPage : ContentPage
{
   
    public DayPage()
    {
        InitializeComponent();
        BindingContext = this; // Add this line if it's not present

        
    }

    


    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddAppointmentPage());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        
    }
    
}