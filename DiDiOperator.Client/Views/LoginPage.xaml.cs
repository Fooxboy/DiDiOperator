using DiDiOperator.Client.ViewModels;

namespace DiDiOperator.Client.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		this.BindingContext= loginViewModel;

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