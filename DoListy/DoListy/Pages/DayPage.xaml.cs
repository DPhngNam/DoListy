namespace DoListy.Pages;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

public partial class DayPage : ContentPage
{
    private Dictionary<DateTime, List<IView>> TaskDaily;
    public DayPage()
    {
        InitializeComponent();
        SetIniDisplayDate();
        TaskDaily = new Dictionary<DateTime, List<IView>>();
    }

    private void SetIniDisplayDate()
    {
        mon.DisplayDate = new DateTime(2023, 11, 13);
        tue.DisplayDate = new DateTime(2023, 11, 14);
        wed.DisplayDate = new DateTime(2023, 11, 15);
        thus.DisplayDate = new DateTime(2023, 11, 16);
        fri.DisplayDate = new DateTime(2023, 11, 17);
        sat.DisplayDate = new DateTime(2023, 11, 18);
        sun.DisplayDate = new DateTime(2023, 11, 19);
    }


    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        DateTime current = DateTime.Now; // You need to get the actual date/time for the task
        TaskDaily.Add(current, new List<IView>());

        // Adding a new goal
        var newGoal = new Label
        {
            Text = "A Goal in " + current.ToString() // Using the current date
        };

        if (TaskDaily.ContainsKey(current))
        {
            TaskDaily[current].Add(newGoal);
        }
        else
        {
            var newGoalList = new List<IView>();
            newGoalList.Add(newGoal);
            TaskDaily.Add(current, newGoalList);
        }

        TaskDailyStack.Children.Add(newGoal);
    }

    private void LeftimaBut_Clicked(object sender, EventArgs e)
    {
        mon.DisplayDate = mon.DisplayDate.AddDays(-7);
        tue.DisplayDate = tue.DisplayDate.AddDays(-7);
        wed.DisplayDate = wed.DisplayDate.AddDays(-7);
        thus.DisplayDate = thus.DisplayDate.AddDays(-7);
        fri.DisplayDate = fri.DisplayDate.AddDays(-7);
        sat.DisplayDate = sat.DisplayDate.AddDays(-7);
        sun.DisplayDate = sun.DisplayDate.AddDays(-7);
    }

    private void RightimaBut_Clicked(object sender, EventArgs e)
    {
        mon.DisplayDate = mon.DisplayDate.AddDays(7);
        tue.DisplayDate = tue.DisplayDate.AddDays(7);
        wed.DisplayDate = wed.DisplayDate.AddDays(7);
        thus.DisplayDate = thus.DisplayDate.AddDays(7);
        fri.DisplayDate = fri.DisplayDate.AddDays(7);
        sat.DisplayDate = sat.DisplayDate.AddDays(7);
        sun.DisplayDate = sun.DisplayDate.AddDays(7);
    }

    private void AlwaysOnDisplay(DateTime currentDate)
    {
        TaskDailyStack.Children.Clear();
        if (TaskDaily.ContainsKey(currentDate))
        {
            var numOfGoals = TaskDaily[currentDate].Count;
            for (int i = 0; i < numOfGoals; i++)
            {
                TaskDailyStack.Children.Add(TaskDaily[currentDate][i]);
            }
        }
    }

    private void Butmon_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(mon.DisplayDate);

    }

    private void Buttue_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(tue.DisplayDate);

    }

    private void Butwed_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(wed.DisplayDate);

    }

    private void Butthus_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(thus.DisplayDate);

    }

    private void Butfri_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(fri.DisplayDate);

    }

    private void Butsat_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(sat.DisplayDate);

    }

    private void Butsun_Clicked(object sender, EventArgs e)
    {
        AlwaysOnDisplay(sun.DisplayDate);

    }

    private async void NewButton_Clicked(object sender, EventArgs e)
    {
        await frame_A.TranslateTo(-300, 0, 250, Easing.Linear);
        Grid.SetColumn(frame_A, 0);
        Grid.SetRow(frame_A, 1);
        // Scale back to original size

        // Animate the visibility change for frame_B
        frame_B.IsVisible = true;
        await frame_B.FadeTo(1, 500, Easing.SinInOut); // Fade in


    }
}