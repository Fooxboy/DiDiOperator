using DiDiOperator.SDK.Services;

namespace DiDiOperator.MobileClient.ViewModels
{
    public class HistoryViewModel: ViewModelBase
    {
        private readonly DiDiService diDiService;

        public HistoryViewModel(DiDiService di)
        {
            this.diDiService = di;
        }

        public async Task LoadData()
        {
            //var history = await diDiService.
        }
    }
}
