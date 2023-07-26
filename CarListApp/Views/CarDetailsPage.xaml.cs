using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class CarDetailsPage : ContentPage
{
    public CarDetailsPage(CarDetailsVM carDetailsVM)
    {
        InitializeComponent();
        BindingContext = carDetailsVM;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
