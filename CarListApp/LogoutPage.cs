using CarListApp.ViewModels;

namespace CarListApp;

public class LogoutPage : ContentPage
{
	public LogoutPage(LogoutVM logoutVM)
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, 
					Text = "Logging Out"
				}
			}
		};

		BindingContext = logoutVM;
	}
}