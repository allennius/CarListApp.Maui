using System;
using System.Web;
using CarListApp.Models;
using CarListApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]

    public partial class CarDetailsVM : BaseVM, IQueryAttributable
    {
        private readonly CarApiService carApiService;

        public CarDetailsVM(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }

        NetworkAccess accesstype = Connectivity.Current.NetworkAccess;

        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query[nameof(Id)].ToString()));
        }

        public async Task GetCarData()
        {
            if (accesstype == NetworkAccess.Internet)
                Car = await carApiService.GetCar(Id);
            else
                Car = App.CarDatabaseService.GetCar(Id);

        }
    }
}

