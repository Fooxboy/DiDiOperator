using DiDiOperator.Client.ViewModels;

namespace DiDiOperator.Client.Views;

public partial class TabsPage : TabbedPage
{
	public TabsPage(HomePage homePage)
	{
		InitializeComponent();

		this.Children.Add(homePage);
	}
}