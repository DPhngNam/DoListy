using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using DoListy.Database;
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