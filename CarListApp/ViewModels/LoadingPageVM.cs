using CarListApp.Helpers;
using CarListApp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModels
{
    public partial class LoadingPageVM : BaseVM
    {
        public LoadingPageVM()
        {
            CheckUSerLoginDetails();
        }

        private async void CheckUSerLoginDetails()
        {
            // retreive token from internal storage
            var token = await SecureStorage.GetAsync("Token");

            if (string.IsNullOrEmpty(token))
                await GoToLoginPage();
            else
            {
                var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as
                    JwtSecurityToken;

                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    await GoToLoginPage();
                }
                else
                {

                    var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value;

                    App.userInfo = new UserInfo
                    {
                        UserName = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Email))?.Value,
                        Role = role
                    };

                    MenyBuilder.BuildMeny();
                    await GoToMainPage();
                }
            }

            
        }

        private async Task GoToLoginPage()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
    }
}
