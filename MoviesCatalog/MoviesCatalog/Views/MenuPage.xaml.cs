using MoviesCatalog.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            //Resource.Culture = new System.Globalization.CultureInfo("be");
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title=Resource.TopRatedFilm, Icon="video.png" },
                new HomeMenuItem {Id = MenuItemType.Favorite, Title=Resource.Bookmarks, Icon="bookmark.png" },
                new HomeMenuItem {Id = MenuItemType.Settings, Title=Resource.Setting, Icon="setting.png" },
                new HomeMenuItem {Id = MenuItemType.About, Title=Resource.Abot, Icon="question.png" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
        
        
        public void kek()
        {
            DisplayAlert("Warning", "MenuPage", "Ok");
        }
    }
}