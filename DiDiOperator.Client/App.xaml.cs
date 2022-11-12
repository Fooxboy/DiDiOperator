using DiDiOperator.Client.Services;
using DiDiOperator.Client.ViewModels;
using DiDiOperator.Client.Views;
using DiDiOperator.SDK.Services;

namespace DiDiOperator.Client
{
    public partial class App : Application
    {
        public App(NavigationService navigationService, DiDiService diDiService)
        {
            InitializeComponent();

            MainPage = new NavigationPage();

            if(Preferences.ContainsKey("token"))
            {
                var token = Preferences.Get("token", string.Empty);

                if(string.IsNullOrEmpty(token))
                {
                    navigationService.NavigateToPage<LoginPage>();
                    return;
                }

                diDiService.SetToken(token);
                navigationService.NavigateToPage<TabsPage>();

            }else
            {
                navigationService.NavigateToPage<LoginPage>();
            }
        }
    }
}