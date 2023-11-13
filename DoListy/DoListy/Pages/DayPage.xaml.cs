namespace DoListy.Pages;
using DoListy.TaskManager;
using System.Collections.ObjectModel;

public partial class DayPage : ContentPage
{
    public static ObservableCollection<Task> TaskToday = new ObservableCollection<Task>();
    public DayPage()
    {
        InitializeComponent();
        BindingContext = this; // Add this line if it's not present

        taskListView.ItemsSource = TaskManager.TaskToday;

        taskListView.ItemTemplate = new DataTemplate(() =>
        {
            var textCell = new TextCell();
            textCell.SetBinding(TextCell.TextProperty, "Title");

            return textCell;
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        taskListView.ItemsSource = TaskManager.TaskToday;
    }


    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateTaskPage());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        
    }
    
}