using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesCatalog.Models;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {

        
        public SearchPage()
        {
            InitializeComponent();
            Title = "Поиск";
        }

        private void SearchFilms(object sender, EventArgs e)
        {
            if (EntrySearch.Text != null)
            {
                
                string path = $"{AppSettings.ApiUrl}search/movie?api_key={AppSettings.ApiKey}&language={AppSettings.Language}&query={EntrySearch.Text}&page=1&include_adult=false";
                string str;
                using (StreamReader strr = new StreamReader(WebRequest.Create(path).GetResponse().GetResponseStream()))
                    str = strr.ReadToEnd();
                var info = JsonConvert.DeserializeObject<Movies>(str);

                foreach (var x in info.Results)
                {
                    x.PosterPath = "https://image.tmdb.org/t/p/w500/" + x.PosterPath;
                }

                MyListView.ItemsSource = info.Results;
            }
            else
            {
                DisplayAlert("Warning", "Не корректно введен поиск!", "Ок");
            }

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var movie = args.SelectedItem as Movie;
            if (movie == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(movie)));

            // Manually deselect item.
            MyListView.SelectedItem = null;
        }

    }
}