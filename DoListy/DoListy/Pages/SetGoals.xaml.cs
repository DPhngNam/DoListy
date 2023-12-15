using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;

namespace DoListy.Pages;

public partial class SetGoals : Popup
{
    private readonly IAudioManager audioManager;
    IAudioPlayer clickPlayer { get; set; }

    public SetGoals(IAudioManager audioManager)
    {
        InitializeComponent();
        this.audioManager = audioManager;
        createPlayers();
    }
    private async void createPlayers()
    {
        clickPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("click.mp3"));

    }
    public void IniYearNumericEntry(int num)
    {
        yearNumericEntry.Value = num;
    }
    void OnSetGoalsCancelButtonPressed(object sender, EventArgs e)
    {
        setGoalsCancelButton.Opacity = 0.5;
    }
    void OnSetGoalsCancelButtonClicked(object sender, EventArgs e)
    {
        setGoalsCancelButton.Opacity = 1.0;
        clickPlayer.Play();
        Close();
    }
    void OnSetGoalsCreateButtonPressed(object sender, EventArgs e)
    {
        setGoalsCreateButton.Opacity = 0.5;
    }
    void OnSetGoalsCreatelButtonClicked(object sender, EventArgs e)
    {
        clickPlayer.Play();
        setGoalsCreateButton.Opacity = 1.0;
        Close();
        if (string.IsNullOrEmpty(goalTitleEntry.Text)) { goalTitleEntry.Text = ""; }
        ((YearPage)Shell.Current.CurrentPage).getCreatedGoal(goalTitleEntry.Text, (int)yearNumericEntry.Value, goalNoteEntry.Text);
    }
    void OnEditGoalButtonPressed(object sender, EventArgs e)
    {
        editGoalButton.Opacity = 0.5;
    }
    void OnEditGoalButtonClicked(object sender, EventArgs e)
    {
        clickPlayer.Play();
        editGoalButton.Opacity = 1.0;
        goalTitleEntry.IsEnabled = true;
        yearNumericEntry.IsEnabled = true;
        goalNoteEntry.IsEnabled = true;
        setGoalsSaveButton.IsVisible = true;
        setGoalsCancelButton.IsVisible = true;
    }
  
}