using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MoviesCatalog.Models;
using MoviesCatalog.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesCatalog.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public List<Movie> VisibleMovies { get; private set; } = new List<Movie>();
        public CustomCollection<Movie> Movies { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = Resource.TopRatedFilm;
            Movies = new CustomCollection<Movie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Movie>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Movie;
                Movies.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Movies.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Movies.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        

        public void SearchWithSearchBarText(string searchBarText)
        {
            
        }
    }
}