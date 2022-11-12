using DiDiOperator.Client.Services;
using DiDiOperator.Client.Views;

namespace DiDiOperator.Client
{
    public partial class MainPage : ContentPage
    {
        private readonly NavigationService _navigationService;

        public MainPage(NavigationService navigationService)
        {
            InitializeComponent();

            this._navigationService= navigationService;
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            if (Preferences.ContainsKey("token"))
            {
              
                return;
            }
            await _navigationService.NavigateToPage<LoginPage>();
        }
    }
}