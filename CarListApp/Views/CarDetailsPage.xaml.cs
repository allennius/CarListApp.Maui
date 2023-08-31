using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class CarDetailsPage : ContentPage
{
    private readonly CarDetailsVM CarDetailsVM;

    public CarDetailsPage(CarDetailsVM carDetailsVM)
    {
        InitializeComponent();
        BindingContext = carDetailsVM;
        this.CarDetailsVM = carDetailsVM;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarDetailsVM.GetCarData();
    }
}
