using InzynierkaMauiFront.Features;
using InzynierkaMauiFront.Pages;
using Microsoft.Extensions.Logging;
using Refit;

namespace InzynierkaMauiFront
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddRefitClient<IGetItemsApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7084"));
            
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CheckAttendancePage>();
#if DEBUG
            builder.Logging.AddDebug();
            
#endif
            return builder.Build();

        }
    }
}
