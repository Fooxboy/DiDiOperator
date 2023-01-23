using DiDiOperator.MobileClient.ViewModels;

namespace DiDiOperator.MobileClient.Views;

public partial class PayoutPage : ContentPage
{
    private readonly PayoutViewModel viewModel;
    public PayoutPage(PayoutViewModel vm)
    {
        this.viewModel = vm;
        this.BindingContext = viewModel;
        InitializeComponent();
    }

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        if (e.Url.Contains("di-di.ru"))
        {
            WebViewMain.IsVisible = false;
        }
    }
}