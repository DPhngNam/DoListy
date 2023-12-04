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
    void OnSetGoalsCancelButton(object sender, EventArgs e)
    {
        Close();
    }
    void OnSetGoalsCreatelButton(object sender, EventArgs e)
    {


        Close();
        if (string.IsNullOrEmpty(goalTitleEntry.Text)) { goalTitleEntry.Text = ""; }
        ((YearPage)Shell.Current.CurrentPage).getCreatedGoal(goalTitleEntry.Text, (int)yearNumericEntry.Value, goalNoteEntry.Text);
    }
}