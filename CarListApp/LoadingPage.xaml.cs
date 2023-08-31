using CarListApp.ViewModels;

namespace CarListApp;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageVM loadingVM)
	{
		InitializeComponent();
		this.BindingContext = loadingVM;
	}
}