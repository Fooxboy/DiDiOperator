using DiDiOperator.MobileClient.ViewModels;

namespace DiDiOperator.MobileClient.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _viewModel;
    public HomePage(HomeViewModel vm)
    {
        _viewModel = vm;
        this.BindingContext = _viewModel;
        InitializeComponent();

        this.Loaded += HomePage_Loaded;
    }

    private async void HomePage_Loaded(object sender, EventArgs e)
    {
        await _viewModel.LoadData();
    }

    private void Button_Focused(object sender, FocusEventArgs e)
    {
        if (sender is Button button)
        {
            button.ScaleTo(0.95, 50);
        }
    }

    private void Button_Unfocused(object sender, FocusEventArgs e)
    {
        if (sender is Button button)
        {
            button.ScaleTo(1, 50);
        }
    }
}