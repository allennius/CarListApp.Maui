using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public ObservableCollection<Car> Cars { get; private set; } = new ();

        public CarListVM()
        {
            Title = "Car List";
            createUpdateButton = createButtonText;
            GetCarList().Wait();
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

                var cars = App.CarService.GetCars();

                foreach (var car in cars) Cars.Add(car);
          
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get cars: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrive list of cars:", "Ok");
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
                await Shell.Current.DisplayAlert("Invalid Data", "rPlease insert valid Data", "Ok");
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
                App.CarService.UpdateCar(car);
                await Shell.Current.DisplayAlert("Updated Car", "Successfully updated car", "Ok");

            }
            else
            {
                App.CarService.AddCar(car);
                await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            }

            await ClearForm();
            await GetCarList();
        }

        [RelayCommand]
        async Task DeleteCar(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please Try again", "Ok");
                return;
            }
            var result = App.CarService.DeleteCar(id);
            if (result == 0)
                await Shell.Current.DisplayAlert("Operation Failed", "Deletion Failed", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Deletion Successful", "Record removed Successfully", "ok");
                await GetCarList();
            }
        }

        [RelayCommand]
        async Task EditCar(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to start editing", "Ok");
                return;
            }

            var result = App.CarService.GetCar(id);
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
        async Task ClearForm()
        {
            CreateUpdateButton = createButtonText;
            CarId = 0;
            Make = string.Empty;
            Model = string.Empty;
            Vin = string.Empty;
        }
    }
}

