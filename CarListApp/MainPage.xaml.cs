using CarListApp.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace CarListApp;

public partial class MainPage : ContentPage
{

    public MainPage(CarListVM carListVM)
    {
        InitializeComponent();

        BindingContext = carListVM;

    }



    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    var customSafe = On<iOS>().SafeAreaInsets();
    //    Padding = customSafe.Bottom = 0;
    //}
}


