using System.Collections.Generic;
using System;
using System.Timers;

using System.Windows.Input;

using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;
namespace DoListy.Pages;

public partial class PomodoroPage : ContentPage
{
    System.Timers.Timer countdownTimer;
    private readonly IAudioManager audioManager;
    IAudioPlayer clickPlayer { get; set; }

    TimeSpan totalTime;
    int minutes;
    bool focus;
    int countPomo;

    int pomolength;
    int shortbreak;
    int longbreak;
    int longbreakafter;
    bool settingsFrameIsPulled { get; set; }
    public PomodoroPage(IAudioManager audioManager)
	{
		InitializeComponent();
		InitializeTimer();
        this.audioManager = audioManager;
        createPlayers();
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
        pomoSettingFrame.BackgroundColor = Color.FromRgba(21, 44, 57,160);
        settingsFrameIsPulled = true;
        pullSettingsButton.RotateYTo(180);

    }

    private async void createPlayers()
    {
        clickPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("click.mp3"));
    }
    void changeState()
    {
        
        if (focus)
        {
            if (countPomo == longbreakafter)
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
    private void OnStartPressed(object sender, EventArgs e)
    {
        startButton.Opacity = 0.5;
    }
    private void OnStartClicked(object sender, EventArgs e)
    {
        clickPlayer.Play();
        startButton.Opacity = 1.0;
        startButton.IsVisible = false;
        pauseButton.IsVisible = true;
        stopButton.IsVisible = true;
        countdownTimer.Start();

    }
    private void OnPausePressed(object sender, EventArgs e)
    {
        pauseButton.Opacity = 0.5;
    }
    private void OnPauseClicked(object sender, EventArgs e)
    {
        countdownTimer.Stop();
        clickPlayer.Play();
        pauseButton.Opacity = 1.0;
        pauseButton.IsVisible = false;
        stopButton.IsVisible = false;
        startButton.IsVisible = true;
    }
    private void OnStopPressed(object sender, EventArgs e)
    {
        stopButton.Opacity = 0.5;
    }
    private void OnStopClicked(object sender, EventArgs e)
    {
        countdownTimer.Stop();
        stopButton.Opacity = 1.0;
        clickPlayer.Play();
        progressBar.Progress = 0;
        pauseButton.IsVisible = false;
        stopButton.IsVisible = false;
        startButton.IsVisible = true;
        changeState();
        totalTime = TimeSpan.FromMinutes(minutes);
        UpdateTimerLabel(totalTime);
    }
    private void OnApplyPomoSettingPressed(object sender, EventArgs e)
    {
        applyPomoSettingsButton.Opacity = 0.5;
    }
    private void OnApplyPomoSettingClicked(object sender, EventArgs e)
    {
        countdownTimer.Stop();
        clickPlayer.Play();
        applyPomoSettingsButton.Opacity = 1.0;
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
    private void OnCancelPomoSettingPressed(Object sender, EventArgs e)
    {
        cancelPomoSettingsButton.Opacity = 0.5;
    }
    private void OnCancelPomoSettingClicked(Object sender, EventArgs e)
    {
        clickPlayer.Play();
        cancelPomoSettingsButton.Opacity = 1.0;
        pomoLengthEntry.Value = pomolength;
        shortBreakLengthEntry.Value = shortbreak;
        longBreakLengthEntry.Value = longbreak;
        longBreakAfterEntry.Value = longbreakafter;
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
    void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    void OnPullSettingsPressed(object sender, EventArgs e)
    {
        pullSettingsButton.Opacity = 0.5;
    }
    void OnPullSettingsClicked(object sender, EventArgs e)
    {
        pullSettingsButton.Opacity = 1.0;
        clickPlayer.Play();
        if (settingsFrameIsPulled) {
            pomoSettingFrame.TranslateTo(335, 0);
            pullSettingsButton.RotateYTo(0);
            settingsFrameIsPulled = false; 
        }
        else {
            pomoSettingFrame.TranslateTo(0, 0);
            pullSettingsButton.RotateYTo(180);
            settingsFrameIsPulled = true; 
        }
    }
}
