using CommunityToolkit.Mvvm.Input;
using DiDiOperator.SDK.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DiDiOperator.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly DiDiService diDiService;

        public ICommand LogoutCommand { get; set; }

        public ICommand PayoutCommand { get; set; }

        public ICommand TariffsComamnd { get; set; }

        public ICommand ChangePasswordCommand { get; set; }

        public ICommand NewsCommand { get; set; }

        public string AbonentName { get; set; }

        public string ContractName { get; set; }

        public string BalanceAmount { get; set; }

        public bool IsLoading { get; set; }

        public ObservableCollection<string> CurrentTariffs { get; set; }


        public HomeViewModel(DiDiService diDiService)
        {
            this.diDiService = diDiService;
            this.PayoutCommand = new AsyncRelayCommand(Payout);

            this.CurrentTariffs = new ObservableCollection<string>();
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

            foreach (var tariff in tariffs)
            {
                
            }
             
            IsLoading = false;
            RaisePropertyChanged("IsLoading");
        }

        private async Task Payout()
        {

        }
    }
}
