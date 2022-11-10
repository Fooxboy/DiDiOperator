using DiDiOperator.Client.Services;

namespace DiDiOperator.Client
{
    public partial class App : Application
    {
        public App(NavigationService navigationService)
        {
            InitializeComponent();

            MainPage = new NavigationPage();
            navigationService.NavigateToPage<MainPage>();
        }
    }
}