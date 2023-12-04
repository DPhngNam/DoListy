using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using DoListy.Database;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
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
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "IconFontTypes");
                });
#if WINDOWS
    builder.ConfigureLifecycleEvents(events =>
    {
        // Make sure to add "using Microsoft.Maui.LifecycleEvents;" in the top of the file 
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
#endif

            return builder.Build();
        }
    }
}