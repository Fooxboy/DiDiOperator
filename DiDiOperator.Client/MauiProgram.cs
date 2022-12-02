using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using DiDiOperator.Client.Controls;
using DiDiOperator.Client.Services;
using DiDiOperator.Client.ViewModels;
using DiDiOperator.Client.Views;
using DiDiOperator.SDK.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;

namespace DiDiOperator.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
#if ANDROID && DEBUG
            DiDiOperator.Client.Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
            DiDiOperator.Client.Platforms.Android.DangerousTrustProvider.Register();
#endif


            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler(typeof(Entry), typeof(TextBlockHandler));
                    //handlers.AddHandler(typeof(Button), typeof(CustomButtonHandler));
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("Inter-Black.ttf", "InterBlack");
                    fonts.AddFont("Inter-Bold.ttf", "InterBold");
                    fonts.AddFont("Inter-ExtraBold.ttf", "InterExtraBold");
                    fonts.AddFont("Inter-ExtraLight.ttf", "InterExtraLight");
                    fonts.AddFont("Inter-Light.ttf", "InterLight");
                    fonts.AddFont("Inter-Medium.ttf", "InterMedium");
                    fonts.AddFont("Inter-Regular.ttf", "InterRegular");
                    fonts.AddFont("Inter-SemiBold.ttf", "InterSemiBold");
                    fonts.AddFont("Inter-Thin.ttf", "InterThin");

                });

            builder.Services.AddTransient<TabsPage>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<TariffsPage>();
            builder.Services.AddTransient<TariffsViewModel>();
            builder.Services.AddTransient<PayoutPage>();
            builder.Services.AddTransient<PayoutViewModel>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileViewModel>();

            builder.Services.AddSingleton<NavigationService>();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<DiDiService>();
            return builder.Build();
        }
    }
}