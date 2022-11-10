using DiDiOperator.Client.Controls;
using DiDiOperator.Client.Services;
using DiDiOperator.Client.ViewModels;
using DiDiOperator.Client.Views;
using DiDiOperator.SDK.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiDiOperator.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler(typeof(Entry), typeof(TextBlockHandler));
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddSingleton<NavigationService>();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<DiDiService>();
            return builder.Build();
        }
    }
}