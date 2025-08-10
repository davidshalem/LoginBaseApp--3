using LoginBaseApp.Service;
using LoginBaseApp.ViewModels;
using LoginBaseApp.Views;
using Microsoft.Extensions.Logging;

namespace LoginBaseApp
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
                    fonts.AddFont("MaterialSymbolsOutlined.ttf","MaterialSymbols");

					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<Views.LoginPage>();
            builder.Services.AddTransient<ViewModels.LoginPageViewModel>();

			builder.Services.AddSingleton<ILoginService, DBMokup>();
            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<RegistrationPage>();
            builder.Services.AddTransient<RegistrationViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ProfilePage>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
