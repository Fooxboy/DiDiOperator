using CommunityToolkit.Mvvm.Input;
using DiDiOperator.MobileClient.Models;
using DiDiOperator.MobileClient.Services;
using DiDiOperator.MobileClient.Views;
using DiDiOperator.SDK.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DiDiOperator.MobileClient.ViewModels
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

        public ICommand RefreshCommand { get; set; }

        public string AbonentName { get; set; }

        public string ContractName { get; set; }

        public string BalanceAmount { get; set; }

        public bool IsLoading { get; set; }

        public bool IsError { get; set; }

        public ObservableCollection<CurrentTariff> CurrentTariffs { get; set; }

        public HomeViewModel(DiDiService diDiService, NavigationService navigationService)
        {
            this.diDiService = diDiService;
            this.navigationService = navigationService;
            this.PayoutCommand = new AsyncRelayCommand(Payout);
            this.CurrentTariffs = new ObservableCollection<CurrentTariff>();
            this.RefreshCommand = new AsyncRelayCommand(LoadData);

            this.IsError = false;
        }

        public async Task LoadData()
        {
            try
            {
                IsError = false;
                RaisePropertyChanged("IsError");

                IsLoading = true;
                RaisePropertyChanged("IsLoading");

                this.CurrentTariffs.Clear();

                var user = await this.diDiService.GetUserAsync();

                ContractName = user.Title;
                RaisePropertyChanged("ContractName");

                var balance = await this.diDiService.GetBalanceAsync();

                BalanceAmount = Math.Round(balance.CurrentBalance, 2).ToString();
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
                    catch (Exception ex)
                    {

                    }

                    CurrentTariffs.Add(currentTariff);
                }

                IsLoading = false;
                RaisePropertyChanged("IsLoading");

            }catch(Exception ex)
            {
                IsError = true;
                RaisePropertyChanged("IsError");
                IsLoading = false;
                RaisePropertyChanged("IsLoading");
            }
        }

        private async Task Payout()
        {
            await navigationService.NavigateInTab<PayoutPage>();
        }
    }
}
