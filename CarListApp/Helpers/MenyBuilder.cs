using CarListApp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Helpers
{
    internal class MenyBuilder
    {

        public static void BuildMeny()
        {
            Shell.Current.Items.Clear();
            Shell.Current.FlyoutHeader = new FlyOutHeader();

            var role = App.userInfo.Role;

            if (role.Equals("Administrator"))
            {
                var flyOutItem = new FlyoutItem()
                {
                    Title = "Admin Car Managment",
                    Route = nameof(MainPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                            Icon = "dotnet_bot.svg",
                            Title = "Admin page 1",
                            ContentTemplate = new DataTemplate(typeof(MainPage))
                        },
                    }
                };

                if(!Shell.Current.Items.Contains(flyOutItem))
                {
                    Shell.Current.Items.Add(flyOutItem);
                }
            }

            if(role.Equals("User"))
            {
                var flyOutItem = new FlyoutItem()
                {
                    Title = "User Car Managment",
                    Route = nameof(MainPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                            Icon = "dotnet_bot.svg",
                            Title = "User page 1",
                            ContentTemplate = new DataTemplate(typeof(MainPage))
                        },
                    }
                };

                if (!Shell.Current.Items.Contains(flyOutItem))
                {
                    Shell.Current.Items.Add(flyOutItem);
                }
            }

            var logoutFlyoutItem = new FlyoutItem
            {
                Title = "Logout",
                Route = nameof(LogoutPage),
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    new ShellContent
                    {
                        Icon = "dotnet_bot.svg",
                        Title = "Logout",
                        ContentTemplate= new DataTemplate(typeof(LogoutPage))
                    }
                }
            };

            if (!Shell.Current.Items.Contains(logoutFlyoutItem))
            {
                Shell.Current.Items.Add(logoutFlyoutItem);
            }
        }
    }
}
