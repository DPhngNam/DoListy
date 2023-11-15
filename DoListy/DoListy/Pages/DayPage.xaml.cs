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
        mon.DisplayDate = new DateTime(2023,11, 13);
        tue.DisplayDate = new DateTime(2023, 11, 14);
        wed.DisplayDate = new DateTime(2023, 11, 15);
        thus.DisplayDate= new DateTime(2023, 11, 16);
        fri.DisplayDate = new DateTime(2023, 11, 17);
        sat.DisplayDate = new DateTime(2023, 11, 18);
        sun.DisplayDate = new DateTime(2023, 11, 19);
    }


    private async void buttonAddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddAppointmentPage());
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

    private void Butmon_Clicked(object sender, EventArgs e)
    {
        var currentDate = mon.DisplayDate;
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

    private void Buttue_Clicked(object sender, EventArgs e)
    {
        var currentDate = tue.DisplayDate;
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

    private void Butwed_Clicked(object sender, EventArgs e)
    {
        var currentDate = wed.DisplayDate;
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

    private void Butthus_Clicked(object sender, EventArgs e)
    {
        var currentDate = thus.DisplayDate;
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

    private void Butfri_Clicked(object sender, EventArgs e)
    {
        var currentDate = fri.DisplayDate;
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

    private void Butsat_Clicked(object sender, EventArgs e)
    {
        var currentDate = sat.DisplayDate;
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

    private void Butsun_Clicked(object sender, EventArgs e)
    {
        var currentDate = sun.DisplayDate;
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
}