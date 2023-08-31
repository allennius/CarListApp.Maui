using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                    await GoToMainPage();
                else
                    await GoToLoginPage();
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
