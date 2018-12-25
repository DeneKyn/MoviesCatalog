using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoviesCatalog.Models;
using MoviesCatalog.Views;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var movie = args.SelectedItem as Movie;
            if (movie == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(movie)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void Search_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();            
            viewModel.LoadItemsCommand.Execute(null);
            Title = Resource.TopRatedFilm;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsListView.BeginRefresh();
            viewModel.SearchWithSearchBarText(e.NewTextValue);
            ItemsListView.EndRefresh();
            //ItemsListView.ItemsSource = null;
            //ItemsListView.ItemsSource = viewModel.groupedMovies;
        }

        
    }
}