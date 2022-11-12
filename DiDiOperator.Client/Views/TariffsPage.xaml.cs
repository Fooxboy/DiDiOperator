using DiDiOperator.Client.ViewModels;

namespace DiDiOperator.Client.Views;

public partial class TariffsPage : ContentPage
{
	private readonly TariffsViewModel viewModel;

	public TariffsPage(TariffsViewModel vm)
	{
		this.viewModel = vm;
		this.BindingContext= viewModel;
        this.Loaded += TariffsPage_Loaded;
		InitializeComponent();
	}

    private async void TariffsPage_Loaded(object sender, EventArgs e)
    {
        await viewModel.LoadDataAsync();
    }
}