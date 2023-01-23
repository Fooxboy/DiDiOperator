using CommunityToolkit.Mvvm.Input;
using DiDiOperator.SDK.Services;
using System.Windows.Input;

namespace DiDiOperator.MobileClient.ViewModels
{
    public class PayoutViewModel : ViewModelBase
    {
        public bool VisibleWebView { get; set; }
        public string Url { get; set; }
        public string Amount { get; set; }

        public ICommand PayoutCommand { get; set; }

        private readonly DiDiService diDiService;

        public PayoutViewModel(DiDiService diDiService)
        {
            this.diDiService = diDiService;
            this.PayoutCommand = new AsyncRelayCommand(Payout);

            VisibleWebView = false;
        }

        private async Task Payout()
        {
            if(int.TryParse(Amount, out var amount))
            {
                
                var url = await diDiService.GetPaymentLinkAsync(new SDK.Models.Response.Module() { Id = 2, Name = "sberbank", Title = "sberbank" }, amount);


#if ANDROID
                Launcher.OpenAsync(url.Url);
#endif

#if WINDOWS
                Url = url.Url;
                this.RaisePropertyChanged(nameof(Url));

                VisibleWebView = true;

                this.RaisePropertyChanged(nameof(VisibleWebView));

#endif

            }
        }
    }
}
