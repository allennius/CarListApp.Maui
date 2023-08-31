using CarListApp.ViewModels;

namespace CarListApp;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageVM loginVM)
	{
		InitializeComponent();
		BindingContext = loginVM;
	}
}