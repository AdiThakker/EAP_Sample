using System.Collections.Generic;
using EAP.Xamarin.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EAP.Xamarin.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        List<MainPageMenuItem> menuItems;

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<MainPageMenuItem>
            {
                new MainPageMenuItem {Id = MenuItemType.Home, Title="Home" },
                new MainPageMenuItem {Id = MenuItemType.About, Title="About" }
            };

            MenuItemsListView.ItemsSource = menuItems;
            MenuItemsListView.SelectedItem = menuItems[0];
            MenuItemsListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((MainPageMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}