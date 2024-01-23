using InzynierkaMauiFront.Features;
using InzynierkaMauiFront.Pages;
using Microsoft.Extensions.Logging;
using Refit;

namespace InzynierkaMauiFront
{
    public static class MauiProgram
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5159" : "http://localhost:5159";
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
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseAddress));
            builder.Services.AddRefitClient<ILoginApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseAddress));
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CheckAttendancePage>();
            
            builder.Services.AddTransient(provider => new LoginPage(provider.GetRequiredService<ILoginApi>()));
#if DEBUG
            builder.Logging.AddDebug();
            
#endif
            return builder.Build();

        }
    }
}
