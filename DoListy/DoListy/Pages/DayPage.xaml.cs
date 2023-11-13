namespace DoListy.Pages;

public partial class DayPage : ContentPage
{
    public DayPage()
    {
        InitializeComponent();
    }

    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateTaskPage());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        
    }
}