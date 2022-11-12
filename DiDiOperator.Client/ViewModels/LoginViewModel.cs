using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using DiDiOperator.Client.Services;
using DiDiOperator.Client.Views;
using DiDiOperator.SDK.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace DiDiOperator.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Login { get; set; }

        public string Password { get; set; }
        public ICommand AuthCommand { get; set; }

        public bool ButtonEnable { get; set; }

        private readonly DiDiService diDiService;
        private readonly NavigationService navigationService;

        public LoginViewModel(DiDiService diDiService, NavigationService navigationService)
        {
            this.diDiService = diDiService;
            this.navigationService = navigationService;

            AuthCommand = new AsyncRelayCommand(Auth);
            this.ButtonEnable = true;
        }


        private async Task Auth()
        {
            try
            {
                ButtonEnable = false;

                RaisePropertyChanged("ButtonEnable");

                if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                {
                    ButtonEnable = true;

                    RaisePropertyChanged("ButtonEnable");

                    return;
                }

                var token = await diDiService.LoginAsync(Login, Password);

                if (token is null)
                {
                    ButtonEnable = true;

                    RaisePropertyChanged("ButtonEnable");

                    return;
                }

                Preferences.Set("token", token.Token);

                await navigationService.NavigateToPage<TabsPage>();
           

            }catch(Exception ex)
            {
                string text = $"Ошибка: {ex.Message}";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(text, duration, fontSize);

                Debugger.Break();
            }
            
        }
    }
}
