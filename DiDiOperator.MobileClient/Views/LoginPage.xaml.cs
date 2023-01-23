using DiDiOperator.MobileClient.ViewModels;

namespace DiDiOperator.MobileClient.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        this.BindingContext = loginViewModel;

        InitializeComponent();

        this.Loaded += LoginPage_Loaded;

    }

    private void LoginPage_Loaded(object sender, EventArgs e)
    {
#if WINDOWS
        LoginGrid.MaximumWidthRequest = 400;
        PasswordGrid.MaximumWidthRequest = 400;
#endif
    }
}