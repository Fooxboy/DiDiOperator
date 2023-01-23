using DiDiOperator.MobileClient.Services;

namespace DiDiOperator.MobileClient.Views;

public partial class TabsPage : TabbedPage
{
    public TabsPage(HomePage homePage, TariffsPage tariffsPage, NavigationService navigationService)
    {
        InitializeComponent();

        NavigationPage.SetHasNavigationBar(homePage, false);
        NavigationPage.SetHasNavigationBar(tariffsPage, false);



        this.Children.Add(new NavigationPage(homePage) { Title = "Главная", IconImageSource = homePage.IconImageSource });
        this.Children.Add(new NavigationPage(tariffsPage) { Title = "Тарифы", IconImageSource = tariffsPage.IconImageSource });

        navigationService.NavigateInTabEvent += NavigationService_NavigateInTabEvent;

    }

    private void NavigationService_NavigateInTabEvent(Page obj)
    {
        NavigationPage.SetHasNavigationBar(obj, false);

        this.CurrentPage.Navigation.PushAsync(obj);
    }
}