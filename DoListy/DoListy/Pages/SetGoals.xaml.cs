using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
namespace DoListy.Pages;

public partial class SetGoals : Popup
{

    public SetGoals()
    {
        InitializeComponent();
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

        Close();
    }
    void OnSetGoalsCreateButtonPressed(object sender, EventArgs e)
    {
        setGoalsCreateButton.Opacity = 0.5;
    }
    void OnSetGoalsCreatelButtonClicked(object sender, EventArgs e)
    {
        setGoalsCreateButton.Opacity = 1.0;


        Close();
        if (string.IsNullOrEmpty(goalTitleEntry.Text)) { goalTitleEntry.Text = ""; }
        ((YearPage)Shell.Current.CurrentPage).getCreatedGoal(goalTitleEntry.Text, (int)yearNumericEntry.Value, goalNoteEntry.Text);
    }
}