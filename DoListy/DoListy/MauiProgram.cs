using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using DoListy.Database;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Maui.Audio;
using DoListy.Pages;
using MetroLog.MicrosoftExtensions;
using MetroLog.Operators;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
namespace DoListy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.ConfigureSyncfusionCore();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "IconFontTypes");
                });
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Logging.AddTraceLogger(_ => { });
            builder.Logging.AddInMemoryLogger(_ => { });
            builder.Services.AddTransient<WeekPage>();
            builder.Services.AddTransient<MonthPage>();
            builder.Services.AddTransient<DayPage>();
            builder.Services.AddTransient<YearPage>();

#if WINDOWS
    builder.ConfigureLifecycleEvents(events =>
    {
        events.AddWindows(windowsLifecycleBuilder =>
        {
            windowsLifecycleBuilder.OnWindowCreated(window =>
            {
                window.ExtendsContentIntoTitleBar = false;
                var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                 //var titleBar = appWindow.TitleBar;  
                // titleBar.BackgroundColor=Windows.UI.Color.FromArgb(30,50,100,50);
                // appWindow.TitleBar.BackgroundColor= Windows.UI.Color.FromArgb(30,50,100,50);
                 appWindow.Title="DoListy";
            });
        });
    });
#endif

            string dbpath = Path.Combine(FileSystem.AppDataDirectory, "Appointment.db");
            builder.Services.AddSingleton<AppointmentRepository>(s =>
            ActivatorUtilities.CreateInstance<AppointmentRepository>(s,dbpath));


#if DEBUG
            builder.Logging.AddDebug();
            builder.Logging.AddTraceLogger(
                options =>
                {
                    options.MinLevel = LogLevel.Trace;
                    options.MaxLevel = LogLevel.Critical;
                });

#endif
            builder.Logging.AddInMemoryLogger(
                options =>
                {
                    options.MaxLines = 1024;
                    options.MinLevel = LogLevel.Debug;
                    options.MaxLevel = LogLevel.Critical;
                });
#if RELEASE
            builder.Logging.AddStreamingFileLogger(
                options =>
                {
                    options.RetainDays = 2;
                    options.FolderPath = Path.Combine(
                        FileSystem.CacheDirectory,
                        "MetroLogs");
                });
#endif
            builder.Logging.AddConsoleLogger(
                options =>
                {
                    options.MinLevel = LogLevel.Information;
                    options.MaxLevel = LogLevel.Critical;
                }); // Will write to the Console Output (logcat for android)

            builder.Services.AddSingleton(LogOperatorRetriever.Instance);
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
 
}