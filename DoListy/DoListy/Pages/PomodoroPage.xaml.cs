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
    List<IAudioPlayer> musics {  get; set; }
    List<string> backgrounds {  get; set; }
    List<string> musicPickerList { get; set; }

    int musicSelectedIndex {  get; set; }
    List<string> backgroundPickerList {  get; set; }
    int backgroundSelectedIndex {  get; set; }
    TimeSpan totalTime { get; set; }
    int minutes { get; set; }
    bool focus {  get; set; }
    int countPomo { get; set; }
    int pomolength { get; set; }
    int shortbreak { get; set; }
    int longbreak { get; set; }
    int longbreakafter { get; set; }
    bool settingsFrameIsPulled { get; set; }
    bool workspaceFrameIsPulled { get; set; }
    public PomodoroPage(IAudioManager audioManager)
	{
		InitializeComponent();
		InitializeTimer();
        this.audioManager = audioManager;
        createPlayers();
        iniPicker();
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
        pomoSettingFrame.BackgroundColor = Color.FromRgba(21, 44, 57,190);
        pomoWorkspaceFrame.BackgroundColor = Color.FromRgba(21, 44, 57, 190);
        settingsFrameIsPulled = true;
        workspaceFrameIsPulled = true;
        pullSettingsButton.RotateYTo(180);

    }
    private void iniPicker()
    {
        musicPickerList = new List<string>() {"None", "Jazz", "Raining", "Nature", "Binaural Beats", "Lofi", "Ghibli Music","Classical" };
        backgroundPickerList = new List<string>() { "None", "Morning Brew", "New York City", "Cozy Coffee Shop", "Ho Chi Minh City", "Cozy Library","Cozy Bedroom", "Galaxy", "Ghibli" };
        musicPicker.ItemsSource = musicPickerList; musicPicker.SelectedIndex = 0;
        musicSelectedIndex = 0;
        backgroundPicker.ItemsSource = backgroundPickerList; backgroundPicker.SelectedIndex = 2;
        backgroundSelectedIndex = 2;
        backgrounds = new List<string>() { "morningbrew_pomo.jpg", "nycview_pomo.jpg", "cozycoffeeshop_pomo.jpg", "hcmcity_pomo.jpg", "cozylibrary_pomo.jpg","cozybedroom_pomo.jpg","galaxy_pomo.jpg", "ghibli_pomo.jpg" };
    }
    private async void createPlayers()
    {
        clickPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("click.mp3"));
        musics = new List<IAudioPlayer>();
        IAudioPlayer item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("jazz_pomo.mp3"));
        musics.Add(item);   
        item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("rain_pomo.mp3"));
        musics.Add(item);
        item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("nature_pomo.mp3"));
        musics.Add(item);
        item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("binauralbeats_pomo.mp3"));
        musics.Add(item);
        item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("lofi_pomo.mp3"));
        musics.Add(item);
        item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ghibli_pomo.mp3"));
        musics.Add(item);
        item = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("classical_pomo.mp3"));
        musics.Add(item);
        musics[0].Loop = musics[1].Loop = musics[2].Loop = musics[3].Loop = musics[4].Loop = musics[5].Loop = musics[6].Loop = true;
       
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
        if (musicSelectedIndex > 0) musics[musicSelectedIndex - 1].Play();
        pomoStateLabel.IsVisible = true;
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
        if (musicSelectedIndex > 0 && musics[musicSelectedIndex-1].IsPlaying) musics[musicSelectedIndex - 1].Pause();
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
        if (musicSelectedIndex > 0 && musics[musicSelectedIndex - 1].IsPlaying) musics[musicSelectedIndex - 1].Stop();
        progressBar.Progress = 0;
        pauseButton.IsVisible = false;
        stopButton.IsVisible = false;
        startButton.IsVisible = true;
        changeState();
        totalTime = TimeSpan.FromMinutes(minutes);
        UpdateTimerLabel(totalTime);
        pomoStateLabel.IsVisible = false;

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
        countPomo = 0;
        pomolength = (int)pomoLengthEntry.Value;
        shortbreak = (int)shortBreakLengthEntry.Value;
        longbreak = (int)longBreakLengthEntry.Value;
        longbreakafter = (int)longBreakAfterEntry.Value;
        longBreakLengthEntry.Minimum = shortbreak;
        minutes = pomolength;
        totalTime = TimeSpan.FromMinutes(minutes);
        UpdateTimerLabel(totalTime);
        focus = false;
        pomoStateLabel.IsVisible = false;
        changeState();

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
                pomoStateLabel.IsVisible = false;

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

    void OnBackButtonPressed(object sender, EventArgs e)
    {
        backButton.Opacity = 0.5;
    }
    async void OnBackButtonClicked(object sender, EventArgs e)
    {
        backButton.Opacity = 1.0;
        clickPlayer.Play();
        await Navigation.PopModalAsync();
        countdownTimer.Stop();
        if (musicSelectedIndex > 0 && musics[musicSelectedIndex - 1].IsPlaying) musics[musicSelectedIndex - 1].Stop();
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

    void OnCancelPomoWorkspacePressed(object sender, EventArgs e)
    {
        cancelPomoWorkspaceSettingsButton.Opacity = 0.5;
    }
    void OnCancelPomoWorkspaceClicked(object sender, EventArgs e)
    {
        cancelPomoWorkspaceSettingsButton.Opacity = 1.0;
        clickPlayer.Play();
        musicPicker.SelectedIndex = musicSelectedIndex;
        backgroundPicker.SelectedIndex = backgroundSelectedIndex;
    }

    void OnApplyPomoWorkspacePressed(object sender, EventArgs e)
    {
        applyPomoWorkspaceSettingsButton.Opacity = 0.5;
    }

    void OnApplyPomoWorkspaceClicked(Object sender, EventArgs e)
    {
        applyPomoWorkspaceSettingsButton.Opacity = 1.0;
        clickPlayer.Play();
        if (!startButton.IsVisible && musicSelectedIndex > 0)
        {
            musics[musicSelectedIndex - 1].Stop();
        }
        musicSelectedIndex = musicPicker.SelectedIndex;
        if (musicSelectedIndex > 0 && !startButton.IsVisible) musics[musicSelectedIndex - 1].Play();
        backgroundSelectedIndex = backgroundPicker.SelectedIndex;
        if (backgroundSelectedIndex == 0) this.BackgroundImageSource = "";
         else   this.BackgroundImageSource = backgrounds[backgroundSelectedIndex-1];
    }

    void OnPullWorkplacePressed(object sender, EventArgs e)
    {
        pullWorkspaceSettingsButton.Opacity = 0.5;
    }

    void OnPullWorkplaceClicked(object sender, EventArgs e)
    {
        pullWorkspaceSettingsButton.Opacity = 1.0;
        clickPlayer.Play();
        if (workspaceFrameIsPulled)
        {
            pomoWorkspaceFrame.TranslateTo(-335, 0);
            pullWorkspaceSettingsButton.RotateYTo(180);
            workspaceFrameIsPulled = false;
        }
        else
        {
            pomoWorkspaceFrame.TranslateTo(0, 0);
            pullWorkspaceSettingsButton.RotateYTo(0);
            workspaceFrameIsPulled = true;
        }
    }
   
}
