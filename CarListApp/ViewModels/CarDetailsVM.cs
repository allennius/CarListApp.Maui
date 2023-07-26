using System;
using System.Web;
using CarListApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]

    public partial class CarDetailsVM : BaseVM, IQueryAttributable
    {

        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query[nameof(Id)].ToString()));
            Car = App.CarService.GetCar(Id);
        }
    }
}

