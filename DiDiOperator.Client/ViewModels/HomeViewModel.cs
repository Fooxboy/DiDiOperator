using CommunityToolkit.Mvvm.Input;
using DiDiOperator.Client.Models;
using DiDiOperator.Client.Services;
using DiDiOperator.Client.Views;
using DiDiOperator.SDK.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DiDiOperator.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly DiDiService diDiService;
        private readonly NavigationService navigationService;

        public ICommand LogoutCommand { get; set; }

        public ICommand PayoutCommand { get; set; }

        public ICommand TariffsComamnd { get; set; }

        public ICommand ChangePasswordCommand { get; set; }

        public ICommand NewsCommand { get; set; }

        public string AbonentName { get; set; }

        public string ContractName { get; set; }

        public string BalanceAmount { get; set; }

        public bool IsLoading { get; set; }

        public ObservableCollection<CurrentTariff> CurrentTariffs { get; set; }

        public HomeViewModel(DiDiService diDiService, NavigationService navigationService)
        {
            this.diDiService = diDiService;
            this.navigationService = navigationService;
            this.PayoutCommand = new AsyncRelayCommand(Payout);

            this.CurrentTariffs = new ObservableCollection<CurrentTariff>();
        }

        public async Task LoadData()
        {
            IsLoading = true;
            RaisePropertyChanged("IsLoading");

            var user = await this.diDiService.GetUserAsync();

            ContractName = user.Title;
            RaisePropertyChanged("ContractName");


            var balance = await this.diDiService.GetBalanceAsync();

            BalanceAmount = balance.CurrentBalance.ToString();
            RaisePropertyChanged("BalanceAmount");

            AbonentName = user.Comment;
            RaisePropertyChanged("AbonentName");

            var tariffs = await this.diDiService.GetCurrentTariffsAsync();

            var status = await this.diDiService.GetStatusAsync();


            foreach (var tariff in tariffs)
            {
                var currentTariff = new CurrentTariff();

                currentTariff.Name = tariff.WebTitle;

                try
                {
                    currentTariff.Status = "Активен";
                    currentTariff.Price = tariff.ConfigPreferences.Map.Price;
                    currentTariff.Speed = tariff.ConfigPreferences.Map.Speed;

                }
                catch(Exception ex)
                {

                }

                CurrentTariffs.Add(currentTariff);
            }
             
            IsLoading = false;
            RaisePropertyChanged("IsLoading");
        }

        private async Task Payout()
        {
            await navigationService.NavigateInTab<PayoutPage>();
        }
    }
}
