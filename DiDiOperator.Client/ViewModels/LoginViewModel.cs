using CommunityToolkit.Mvvm.Input;
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

        public LoginViewModel(DiDiService diDiService)
        {
            this.diDiService = diDiService;

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
            }catch(Exception ex)
            {
                Debugger.Break();
            }
            
        }
    }
}
