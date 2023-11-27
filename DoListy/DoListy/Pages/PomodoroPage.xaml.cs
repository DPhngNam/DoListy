using System.Collections.Generic;
using System;
using System.Timers;

using System.Windows.Input;

using Microsoft.Maui.Controls;

namespace DoListy.Pages;

public partial class PomodoroPage : ContentPage
{
    System.Timers.Timer countdownTimer;
    TimeSpan totalTime;
    int minutes;
    bool focus;
    int countPomo;

    int pomolength;
    int shortbreak;
    int longbreak;
    int longbreakafter;
    public PomodoroPage()
	{
		InitializeComponent();
		InitializeTimer();
        focus = true;
        countPomo = 0;
        pomolength = (int)pomoLengthEntry.Value;
        shortbreak = (int)shortBreakLengthEntry.Value;
        longbreak = (int)longBreakLengthEntry.Value;
        longbreakafter = (int)longBreakAfterEntry.Value;
        longBreakLengthEntry.Minimum = shortbreak;
        minutes = pomolength;
        totalTime =TimeSpan.FromMinutes(minutes);
        UpdateTimerLabel(totalTime);

    }
    void changeState()
    {
        
        if (focus)
        {
            if (countPomo == (int)longBreakAfterEntry.Value)
            {
                minutes = longbreak;

            }
            else { minutes = shortbreak; }
            focus = false;
            pomoStateLabel.Text = "Taking A Break";
        }
        else
        {
            minutes = pomolength;
            pomoStateLabel.Text = "Focusing";
            focus = true;
        }
    }
    private void InitializeTimer()
    {
        countdownTimer = new System.Timers.Timer(1000); // Use fully qualified name
        countdownTimer.Elapsed += OnTimerElapsed;
    }
    private void OnStartClicked(object sender, EventArgs e)
    {
        startButton.IsVisible = false;
        pauseButton.IsVisible = true;
        stopButton.IsVisible = true;
        countdownTimer.Start();

    }
    private void OnPauseClicked(object sender, EventArgs e)
    {
        countdownTimer.Stop();
        pauseButton.IsVisible = false;
        stopButton.IsVisible = false;
        startButton.IsVisible = true;
    }
    private void OnStopClicked(object sender, EventArgs e)
    {
        countdownTimer.Stop();
        progressBar.Progress = 0;
        pauseButton.IsVisible = false;
        stopButton.IsVisible = false;
        startButton.IsVisible = true;
        changeState();
        totalTime = TimeSpan.FromMinutes(minutes);
        UpdateTimerLabel(totalTime);
    }
    private void OnApplyPomoSettingClicked(object sender, EventArgs e)
    {
        countdownTimer.Stop();
        pauseButton.IsVisible = false;
        stopButton.IsVisible = false;
        startButton.IsVisible = true;
        focus = true;
        countPomo = 0;
        pomolength = (int)pomoLengthEntry.Value;
        shortbreak = (int)shortBreakLengthEntry.Value;
        longbreak = (int)longBreakLengthEntry.Value;
        longbreakafter = (int)longBreakAfterEntry.Value;
        longBreakLengthEntry.Minimum = shortbreak;
        minutes = pomolength;
        totalTime = TimeSpan.FromMinutes(minutes);
        UpdateTimerLabel(totalTime);
    }
    private void OnCancelPomoSettingClicked(Object sender, EventArgs e)
    {

    }
    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        totalTime = totalTime.Subtract(TimeSpan.FromSeconds(1));
        double progress = (100 * 1.0) / (60*minutes);

        // Update UI components on the main thread
        Device.BeginInvokeOnMainThread(() =>
        {
            UpdateTimerLabel(totalTime);

            // Update progress bar
            // Assuming a 25-minute Pomodoro session
            progressBar.Progress += progress;

            // Check if the timer has reached 0
            if (totalTime.TotalSeconds <= 0)
            {
                countdownTimer.Stop();
                ++countPomo;
                changeState();
                totalTime = TimeSpan.FromMinutes(minutes);
                UpdateTimerLabel(totalTime);
                // call a notification function
            }
        });
    }

    private void UpdateTimerLabel(TimeSpan time)
    {
        timerLabel.Text = $"{(int)time.TotalMinutes:D2}:{time.Seconds:D2}";
    }
}
