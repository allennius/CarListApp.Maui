using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModels
{
    public partial class LogoutVM : BaseVM
    {

        public LogoutVM() 
        {
            Logout();
        }

        [RelayCommand]
        async void Logout()
        {
            SecureStorage.Remove("Token");
            App.userInfo = null;
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
    }
}
