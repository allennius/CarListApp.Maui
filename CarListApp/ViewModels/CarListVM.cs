using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CarListApp.Helpers;
using CarListApp.Models;
using CarListApp.Services;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels
{
    public partial class CarListVM : BaseVM
    {
        const string editButtonText = "Update Car";
        const string createButtonText = "Save Car";
        private readonly CarApiService carApiService;
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        string message = string.Empty;

        public ObservableCollection<Car> Cars { get; private set; } = new ();

        public CarListVM(CarApiService carApiService)
        {
            Title = "Car List";
            createUpdateButton = createButtonText;
            this.carApiService = carApiService;
            //GetCarList().Wait();
        }

        [ObservableProperty]
        string make;
        [ObservableProperty]
        string model;
        [ObservableProperty]
        string vin;
        [ObservableProperty]
        string createUpdateButton;
        [ObservableProperty]
        int carId;

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        public async Task GetCarList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Cars.Any()) Cars.Clear();
                var cars =  new List<Car> ();
                if (accessType == NetworkAccess.Internet)
                    cars = await carApiService.GetCars();
                else
                    cars = App.CarDatabaseService.GetCars();

                foreach (var car in cars) Cars.Add(car);
          
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get cars: {ex.Message}");
                await ShowAlert("Failed to retreive list of cars");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GetCarDetails(int id)
        {
            if (id == 0) return;

            await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
        }

        [RelayCommand]
        async Task SaveCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await ShowAlert("Please insert valid Data");
                return;
            }
            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin
            };

            if (CarId != 0)
            {
                car.Id = CarId;
                if (accessType == NetworkAccess.Internet)
                {
                    await carApiService.UpdateCar(car.Id, car);
                    message = carApiService.StatusMessage;

                }
                else
                {
                    App.CarDatabaseService.UpdateCar(car);
                    message = App.CarDatabaseService.StatusMessage;
                }

            }
            else
            {
                if(accessType == NetworkAccess.Internet)
                {
                    await carApiService.AddCar(car);
                    message = carApiService.StatusMessage;
                }
                else
                {
                    App.CarDatabaseService.AddCar(car);
                    message = App.CarDatabaseService.StatusMessage;
                }
            }

            await ShowAlert(message);
            await ClearForm();
            await GetCarList();
        }

        [RelayCommand]
        async Task DeleteCar(int id)
        {
            if (id == 0)
            {
                await ShowAlert("Please try again");
                return;
            }
            
            if(accessType == NetworkAccess.Internet)
            {
                await carApiService.DeleteCar(id);
                message = carApiService.StatusMessage;
            }
            else
            {
                App.CarDatabaseService.DeleteCar(id);
                message = App.CarDatabaseService.StatusMessage;
            }
            
            await ShowAlert(message);
            await GetCarList();
            
        }

        [RelayCommand]
        async Task EditCar(int id)
        {
            if (id == 0)
            {
                await ShowAlert("Failed to start editing");
                return;
            }

            //var result = App.CarService.GetCar(id);
            var result = await carApiService.GetCar(id);
            if (result == null)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to load data", "Ok");
                return;
            }

            Make = result.Make;
            Model = result.Model;
            Vin = result.Vin;
            CarId = id;

            CreateUpdateButton = editButtonText;
        }

        [RelayCommand]
        Task ClearForm()
        {
            CreateUpdateButton = createButtonText;
            CarId = 0;
            Make = string.Empty;
            Model = string.Empty;
            Vin = string.Empty;
            return Task.CompletedTask;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}

