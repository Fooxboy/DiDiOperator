using DiDiOperator.Client.Services;

namespace DiDiOperator.Client.Views;

public partial class TabsPage : TabbedPage
{
	public TabsPage(HomePage homePage, TariffsPage tariffsPage, NavigationService navigationService)
	{
		InitializeComponent();

        NavigationPage.SetHasNavigationBar(homePage, false);
        NavigationPage.SetHasNavigationBar(tariffsPage, false);
        


        this.Children.Add(new NavigationPage(homePage) { Title = "Главная"});
        this.Children.Add(new NavigationPage(tariffsPage) { Title = "Тарифы"});

        navigationService.NavigateInTabEvent += NavigationService_NavigateInTabEvent;

    }

    private void NavigationService_NavigateInTabEvent(Page obj)
    {
        NavigationPage.SetHasNavigationBar(obj, false);

        this.CurrentPage.Navigation.PushAsync(obj);
    }
}