namespace DoListy.Pages;
using System.Collections.Generic;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

public partial class YearPage : ContentPage
{
    Dictionary<DateTime, List<IView>> goalsList;
    public DateTime CurrentDate { get; set; }
    public YearPage()
    {
        InitializeComponent();
        CurrentDate = DateTime.Now;
        yearLabel.Text = CurrentDate.Year.ToString();
        SetIniDisplayDate(CurrentDate);
        goalsList = new Dictionary<DateTime, List<IView>>(); // khi lam xong Database, goalsList se lay lai latest goalsList chu khong phai new

    }
    private void SetIniDisplayDate(DateTime currentDate)
    {
        janMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 1, 1);
        febMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 2, 1);
        marMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 3, 1);
        aprMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 4, 1);
        mayMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 5, 1);
        junMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 6, 1);
        julMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 7, 1);
        augMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 8, 1);
        sepMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 9, 1);
        octMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 10, 1);
        novMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 11, 1);
        decMonthViewCalendar.DisplayDate = new DateTime(currentDate.Year, 12, 1);

    }
    private void OnLeftArrowButtonClicked(object sender, EventArgs e)
    {
        leftArrowButton.Opacity = 1.0;
        yearLabel.Text = Convert.ToString(Convert.ToInt32(yearLabel.Text) - 1);
        ChangeYearOfDisplayDate(false);
        CurrentDate = janMonthViewCalendar.DisplayDate;
        goalsListGrid.Children.Clear();
        goalsListGrid.RowDefinitions.Clear();
        if (goalsList.ContainsKey(CurrentDate))
        {
            var numOfGoals = goalsList[CurrentDate].Count;
            for (int i = 0; i < numOfGoals; i++)
            {
                goalsListGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
                goalsListGrid.Children.Add(goalsList[CurrentDate][i]);
                goalsListGrid.SetColumn(goalsList[CurrentDate][i], 0);
                goalsListGrid.SetRow(goalsList[CurrentDate][i], goalsListGrid.RowDefinitions.Count - 1);
            }
        }

    }
    private void OnRightArrowButtonClicked(object sender, EventArgs e)
    {

        rightArrowButton.Opacity = 1.0;
        yearLabel.Text = Convert.ToString(Convert.ToInt32(yearLabel.Text) + 1);
        ChangeYearOfDisplayDate(true);
        CurrentDate = janMonthViewCalendar.DisplayDate;
        goalsListGrid.Children.Clear();
        goalsListGrid.RowDefinitions.Clear();
        if (goalsList.ContainsKey(CurrentDate))
        {
            var numOfGoals = goalsList[CurrentDate].Count;
            for (int i = 0; i < numOfGoals; i++)
            {
                goalsListGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
                goalsListGrid.Children.Add(goalsList[CurrentDate][i]);
                goalsListGrid.SetColumn(goalsList[CurrentDate][i], 0);
                goalsListGrid.SetRow(goalsList[CurrentDate][i], goalsListGrid.RowDefinitions.Count - 1);
            }
        }

    }
    private void ChangeYearOfDisplayDate(bool plus)
    {
        int num;
        if (plus) num = 1;
        else num = -1;
        janMonthViewCalendar.DisplayDate = janMonthViewCalendar.DisplayDate.AddYears(num);
        febMonthViewCalendar.DisplayDate = febMonthViewCalendar.DisplayDate.AddYears(num);
        marMonthViewCalendar.DisplayDate = marMonthViewCalendar.DisplayDate.AddYears(num);
        aprMonthViewCalendar.DisplayDate = aprMonthViewCalendar.DisplayDate.AddYears(num);
        mayMonthViewCalendar.DisplayDate = mayMonthViewCalendar.DisplayDate.AddYears(num);
        junMonthViewCalendar.DisplayDate = junMonthViewCalendar.DisplayDate.AddYears(num);
        julMonthViewCalendar.DisplayDate = julMonthViewCalendar.DisplayDate.AddYears(num);
        augMonthViewCalendar.DisplayDate = augMonthViewCalendar.DisplayDate.AddYears(num);
        sepMonthViewCalendar.DisplayDate = sepMonthViewCalendar.DisplayDate.AddYears(num);
        octMonthViewCalendar.DisplayDate = octMonthViewCalendar.DisplayDate.AddYears(num);
        novMonthViewCalendar.DisplayDate = novMonthViewCalendar.DisplayDate.AddYears(num);
        decMonthViewCalendar.DisplayDate = decMonthViewCalendar.DisplayDate.AddYears(num);
    }

    private async void OnJanButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = janMonthViewCalendar.DisplayDate;
    }
    private async void OnFebButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = febMonthViewCalendar.DisplayDate;
    }
    private async void OnMarButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = marMonthViewCalendar.DisplayDate;
    }
    private async void OnAprButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = aprMonthViewCalendar.DisplayDate;
    }
    private async void OnMayButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = mayMonthViewCalendar.DisplayDate;
    }
    private async void OnJunButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = junMonthViewCalendar.DisplayDate;
    }
    private async void OnJulButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = julMonthViewCalendar.DisplayDate;
    }
    private async void OnAugButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = augMonthViewCalendar.DisplayDate;
    }
    private async void OnSepButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = sepMonthViewCalendar.DisplayDate;
    }
    private async void OnOctButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = octMonthViewCalendar.DisplayDate;
    }
    private async void OnNovButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = novMonthViewCalendar.DisplayDate;
    }
    private async void OnDecButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Month");
        var monthPage = (MonthPage)Shell.Current.CurrentPage;
        monthPage.Scheduler.DisplayDate = decMonthViewCalendar.DisplayDate;
    }
    private void OnGoalsPlusButtonClicked(object sender, EventArgs e)
    {
        goalsPlusButton.Opacity = 1.0;
        SetGoals setGoalsPage = new SetGoals();
        setGoalsPage.IniYearNumericEntry(CurrentDate.Year);

        this.ShowPopup(setGoalsPage);
        /*var newGoal = new Label
        {
            Text = "A Goal in " + janMonthViewCalendar.DisplayDate.ToString()
        };
        var currentdate = janMonthViewCalendar.DisplayDate;
        if (goalsList.ContainsKey(currentdate))
        {
            goalsList[currentdate].Add(newGoal);
        }
        else
        {
            var newGoalList = new List<IView>();
            newGoalList.Add(newGoal);
            goalsList.Add(currentdate, newGoalList);
        }
        goalsListStack.Children.Add(newGoal);
        */
    }
    private void OnLeftArrowButtonPressed(object sender, EventArgs e)
    {
        leftArrowButton.Opacity = 0.5;
    }
    private void OnRightArrowButtonPressed(Object sender, EventArgs e)
    {
        rightArrowButton.Opacity = 0.5;
    }
    private void OnGoalsPlusButtonPressed(Object sender, EventArgs e)
    {
        goalsPlusButton.Opacity = 0.5;
    }
    public void getCreatedGoal(string goalName, int year, string note)
    {
        goalsListGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        if (goalName.Length > 19)
        {
            goalName = goalName.Substring(0, 18) + "...";
        }
        var newButton = new Button
        {
            Text = goalName,
            WidthRequest = 175,
            BorderColor = Color.FromHex("#8CABFF"),
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            HeightRequest = 40,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Start
        }; var tempColor = newButton.BorderColor;

        newButton.Pressed += (sender, e) =>
        {
            newButton.BorderColor = Colors.White;
        };
        newButton.Clicked += (sender, e) =>
        {
            newButton.BorderColor = tempColor;
            SetGoals viewGoal = new SetGoals();
            viewGoal.goalTitleEntry.Text = goalName;
            viewGoal.goalTitleEntry.IsEnabled = false;
            viewGoal.yearNumericEntry.Value = year;
            viewGoal.yearNumericEntry.IsEnabled = false;
            viewGoal.goalNoteEntry.Text = note;
            viewGoal.goalNoteEntry.IsEnabled = false;
            viewGoal.setGoalsCancelButton.IsVisible = false;
            viewGoal.setGoalsCreateButton.IsVisible = false;
            this.ShowPopup(viewGoal);
        };
        DateTime goalInYear = new DateTime(year, 1, 1);
        if (goalsList.ContainsKey(goalInYear))
        {
            goalsList[goalInYear].Add(newButton);
        }
        else
        {
            var newGoalList = new List<IView>();
            newGoalList.Add(newButton);
            goalsList.Add(goalInYear, newGoalList);
        }
        if (goalInYear.Year == CurrentDate.Year)
        {
            goalsListGrid.Children.Add(newButton);
            goalsListGrid.SetRow(newButton, goalsListGrid.RowDefinitions.Count - 1);
            goalsListGrid.SetColumn(newButton, 0);
        }
    }
}


