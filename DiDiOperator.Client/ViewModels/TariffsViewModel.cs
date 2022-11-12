using DiDiOperator.SDK.Models.Response;
using DiDiOperator.SDK.Services;
using System.Collections.ObjectModel;

namespace DiDiOperator.Client.ViewModels
{
    public class TariffsViewModel : ViewModelBase
    {
        private readonly DiDiService diDiService;
        public ObservableCollection<TariffDescription> Tariffs { get; set; }

        public bool IsLoading { get; set; }

        public TariffsViewModel(DiDiService diDiService)
        {
            this.diDiService = diDiService;
            Tariffs = new ObservableCollection<TariffDescription>();
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;

            this.RaisePropertyChanged(nameof(IsLoading));

            var tariffs = await diDiService.GetTariffsAsync();

            foreach(var tariff in tariffs ) 
            {
                Tariffs.Add(tariff);
            }

            IsLoading = false;

            this.RaisePropertyChanged(nameof(IsLoading));
        }
    }
}
