using DiDiOperator.Client.ViewModels;

namespace DiDiOperator.Client.Views;

public partial class TabsPage : TabbedPage
{
	public TabsPage(HomePage homePage, TariffsPage tariffsPage)
	{
		InitializeComponent();

        NavigationPage.SetHasNavigationBar(homePage, false);
        NavigationPage.SetHasNavigationBar(tariffsPage, false);

        this.Children.Add(homePage);
        this.Children.Add(tariffsPage);
    }
}