using CarListApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarListApp.Services
{
    public class CarApiService
    {
        HttpClient _httpClient;
        public string StatusMessage;

        public CarApiService()
        {
            var baseAdress = GetBaseAdress();
            _httpClient = new HttpClient() { BaseAddress = new Uri(baseAdress) };
        }

        private string GetBaseAdress()
        {
            #if DEBUG
                return DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:8099" : "http://localhost:8099";
            #elif RELEASE
                //azure adress
                return "https://carlistappapi20230907201045.azurewebsites.net";
            #endif
        }

        public async Task <List<Car>> GetCars()
        {
            try
            {
                await SetAuthToken();
                var response = await _httpClient.GetStringAsync("/cars");
                return JsonConvert.DeserializeObject<List<Car>>(response);
            }
            catch 
            {
                StatusMessage = "Failed to retreive data.";
            }

            return null;
        }       
        public async Task <Car> GetCar(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/cars/" + id);
                return JsonConvert.DeserializeObject<Car>(response);
            }
            catch
            {
                StatusMessage = "Failed to retreive data.";
            }

            return null;
        }
        public async Task AddCar(Car car)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/cars/", car);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insertion succesful";
            }
            catch
            {
                StatusMessage = "Failed to retreive data.";
            }
        }
        public async Task DeleteCar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("/cars/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete succesful";
            }
            catch
            {
                StatusMessage = "Failed to Delete data.";
            }
        }

        public async Task UpdateCar(int id, Car car)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("/cars/" + id, car);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update succesful";
            }
            catch
            {
                StatusMessage = "Failed to update data.";
            }
        }

        public async Task<AuthResponseModel> Login(LoginModel loginModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/login", loginModel);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Login Successful";

                return JsonConvert.DeserializeObject<AuthResponseModel>(await
                    response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                StatusMessage = "Failed to login successfully";
                return default;
            }
        }

        public async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

    }
}
