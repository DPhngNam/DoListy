namespace DoListy.Pages;

public partial class CreateTaskPage : ContentPage
{
    public CreateTaskPage()
    {
        InitializeComponent();
    }
    private async void buttonCancle_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
    private async void buttonCreate_Clicked(object sender, EventArgs e)
    {
        TaskManager.TaskManager.AddTask(new TaskManager.Task
        {
            Title = entryTitle.Text,
            

        });
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