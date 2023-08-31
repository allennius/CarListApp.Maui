using CarListApp.Models;
using CarListApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModels
{
    public partial class LoginPageVM : BaseVM
    {
        public LoginPageVM(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        private CarApiService carApiService;

        [RelayCommand]
        async Task Login()
        {
            if(string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await LoginDisplayError("Invalid username or password");
            }
            else
            {
                // call login api
                var loginModel = new LoginModel(Username, Password);

                var response = await carApiService.Login(loginModel);

                await LoginDisplayError(carApiService.StatusMessage);

                if (!string.IsNullOrEmpty(response?.Token))
                {
                    await SecureStorage.SetAsync("Token", response.Token);

                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as
                        JwtSecurityToken;

                    var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value;

                    App.userInfo = new UserInfo
                    {
                        UserName = Username,
                        Role = role
                    };

                    await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                }
                else
                    await LoginDisplayError("Invalid attempt");
            }
        }

        async Task LoginDisplayError(string message)
        {
            await Shell.Current.DisplayAlert("Login Message", message, "OK");
            Password = string.Empty;
        }
    }
}
